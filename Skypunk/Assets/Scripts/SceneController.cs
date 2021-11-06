using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerStatic;

public class SceneController : MonoBehaviour
{
    public int damage = 3;
    public int maxFuel = 20;
    public int money = 0;
    public bool moveable = true;

    public Dictionary<string, int> lootList;

    public float health;
    public float iron;
    public int fuel;

    [SerializeField] private Text healthText;
    [SerializeField] private Text ironText;
    [SerializeField] private UIButtons uIButtons;
    [SerializeField] private FightUIManager fightManager;

    public GameObject Ivent;

    void Start()
    {
        lootList = PlayerStatic.lootList;
        fuel = PlayerStatic.fuel;
        health = PlayerStatic.health;
        iron = PlayerStatic.iron;
    }

    void Update()
    {
        if (health <= 0 || fuel <= 0)
        {
            health = 0;
            uIButtons.Restart();
        }

        if (GameObject.FindGameObjectsWithTag("Panel").Length == 0)
            moveable = true;
        else
            moveable = false;

        healthText.text = Convert.ToString(health);
        ironText.text = Convert.ToString(iron);
    }

    public void UseCard(GameObject card)
    {
        if (card.GetComponent<Card>() == null) 
        {
            uIButtons.OpenMap();
            return;
        }

        DataCard dataCard = card.GetComponent<Card>().dataCard;
        fuel -= 2;
        
        switch (dataCard.card)
        {
            case DataCard.classCard.Enemy:
                fightManager.card = card.GetComponent<Card>();
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
        }

        if (card.transform.parent.parent.childCount >= 1)
        {
            foreach (Transform i in card.transform.parent.parent.GetChild(1))
                i.gameObject.layer = 6;
        }

        Destroy(card.transform.parent.gameObject);
    }
}
