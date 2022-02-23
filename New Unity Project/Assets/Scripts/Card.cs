using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public DataCard dataCard;
    public int Health;
    public int Iron = 0;
    public int Damage;

    private Text header;
    private Text text;
    private Text VarA;
    private Text VarB;

    [SerializeField] private Text textHealth;
    [SerializeField] private Text textDamage;
    [SerializeField] private Transform panelMagazine;

    public DataIvent Ivent;
    public Transform panelIvent;
    public GameObject search;

    void Start()
    {
        if (dataCard.card == DataCard.classCard.Enemy)
        {
            Iron = 0;

            Health = Random.Range(dataCard.minHealth, dataCard.maxHealth);
            textHealth.text = Health.ToString();

            Damage = Random.Range(dataCard.minDamage, dataCard.maxDamage);
            textDamage.text = System.Convert.ToString(Damage);
        }

        if (Ivent != null)
        {
            header = panelIvent.GetChild(0).GetComponent<Text>();
            text = panelIvent.GetChild(2).GetComponent<Text>();
            VarA = panelIvent.GetChild(3).GetChild(0).GetComponent<Text>();
            VarB = panelIvent.GetChild(4).GetChild(0).GetComponent<Text>();
        }
    }

    public Dictionary<string, int> GetLoot(Dictionary<string, int> list)
    {
        if (Random.Range(0, 100) < 50)
        {
            search.GetComponent<Search>().Restart();
            search.SetActive(true);
            search.transform.GetChild(0).gameObject.SetActive(true);

        } else if (Ivent != null)
        {
            GameObject audioSound = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0).gameObject;
            GameObject audioMusic = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(1).gameObject;

            AudioSource audioSource = audioSound.GetComponent<AudioSource>();
            audioSource.clip = Ivent.audioText;
            audioSource.Play();

            audioSource = audioMusic.GetComponent<AudioSource>();
            audioSource.volume = 0.3f;

            /*header.text = Ivent.TextHeader;
            text.text = Ivent.Text;
            VarA.text = Ivent.VarA;
            VarB.text = Ivent.VarB;*/

            panelIvent.parent.gameObject.SetActive(true);
            panelIvent.gameObject.SetActive(true);
        }

        return list;
    }

    public void GetLootBaloon()
    {
        search.SetActive(true);
        search.transform.GetChild(0).gameObject.SetActive(false);
        search.transform.GetChild(1).gameObject.SetActive(true);
        search.transform.GetChild(1).GetComponent<SearchBaloon>().Looting();
    }

    public float GetFuel(float fuel)
    {
        fuel += Random.Range(4, 9);
        return fuel;
    }
}
