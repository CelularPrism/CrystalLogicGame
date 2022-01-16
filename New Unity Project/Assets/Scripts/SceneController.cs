using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerStatic;

public class SceneController : MonoBehaviour
{
    public int maxFuel = 20;
    public int maxHealth = 15;
    public int maxIron = 15;
    public int money = 100;
    public int costFuel = 2;

    public bool moveable = true;
    public bool share = false;

    public Dictionary<string, int> lootList;

    public float health;
    public float iron;
    public float fuel;
    public int damage;

    [SerializeField] private Text healthText;
    [SerializeField] private Text ironText;
    [SerializeField] private Text dmgText;

    [SerializeField] private UIButtons uIButtons;
    [SerializeField] private FightUIManager fightManager;
    [SerializeField] private AudioClip fightClip;

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject Epilogue;

    public GameObject Ivent;

    [SerializeField] private MagazineUIManager magazine;

    void Start()
    {
        lootList = PlayerStatic.lootList;
        fuel = PlayerStatic.fuel;
        health = PlayerStatic.health;
        iron = PlayerStatic.iron;
        money = PlayerStatic.money;
        damage = PlayerStatic.damage;
    }

    void Update()
    {
        if (health <= 0 || fuel <= 0)
        {
            health = 0;
            gameOver.SetActive(true);
        }

        if (GameObject.FindGameObjectsWithTag("Panel").Length == 0 &&
            GameObject.FindGameObjectsWithTag("PanelList").Length == 0)
            moveable = true;
        else
            moveable = false;

        if (dmgText)
            dmgText.text = damage.ToString();

        if (healthText)
            healthText.text = Convert.ToString(health);

        if (ironText)
            ironText.text = Convert.ToString(iron);
    }

    public void UseCard(GameObject card)
    {
        if (card.GetComponent<Card>() == null && PlayerStatic.countLvl.Count < 4)
        {
            uIButtons.OpenMap();
            return;
        }
        else if (PlayerStatic.countLvl.Count == 4)
        {
            Epilogue.SetActive(true);
            return;
        }

        DataCard dataCard = card.GetComponent<Card>().dataCard;
        fuel -= costFuel;
        
        switch (dataCard.card)
        {
            case DataCard.classCard.Enemy:
                fightManager.card = card.GetComponent<Card>();
                fightManager.transform.parent.GetChild(1).GetComponent<AudioSource>().clip = fightClip;
                fightManager.transform.parent.GetChild(1).GetComponent<AudioSource>().volume = 0.5f;
                fightManager.transform.parent.GetChild(1).GetComponent<AudioSource>().Play();

                fightManager.transform.gameObject.SetActive(true);

                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                break;

            case DataCard.classCard.Search:
                lootList = card.GetComponent<Card>().GetLoot(lootList);
                Ivent.GetComponent<Ivent>().Ivents = card.GetComponent<Card>().Ivent;
                break;

            case DataCard.classCard.Baloon:
                card.GetComponent<Card>().GetLootBaloon();
                break;

            case DataCard.classCard.Fuel:
                if (fuel < maxFuel)
                    fuel = card.GetComponent<Card>().GetFuel(fuel);
                break;

            case DataCard.classCard.Courier:
                if (lootList.Count > 0)
                    card.GetComponent<Courier>().Warning();
                break;

            case DataCard.classCard.Magazine:
                magazine.OpenMagazine(this);
                break;
        }

        if (card.transform.parent.parent.childCount >= 1)
        {
            foreach (Transform i in card.transform.parent.parent.GetChild(1))
                i.gameObject.layer = 6;
        }

        Destroy(card.transform.parent.gameObject);
    }
}
