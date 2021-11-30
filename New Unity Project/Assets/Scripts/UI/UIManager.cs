using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private Transform panelFuel;
    [SerializeField] private Transform panelLoot;
    [SerializeField] private Text moneyTxt;
    [SerializeField] private AudioSource audioListener;
    [SerializeField] private AudioClip audioOpen;

    public Transform dropBtn;

    // Update is called once per frame
    void Update()
    {
        if (sceneController != null)
            for (int i = 0; i < sceneController.maxFuel; i++)
            {
                if (i < sceneController.fuel)
                    panelFuel.GetChild(i).gameObject.SetActive(true);
                else
                    panelFuel.GetChild(i).gameObject.SetActive(false);
            }


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenPanelLoot();
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameObject.FindGameObjectsWithTag("Panel").Length > 0)
                GameObject.FindGameObjectWithTag("Panel").SetActive(false);

            if (GameObject.FindGameObjectsWithTag("PanelList").Length > 0)
            {
                Transform panelWarning = GameObject.FindGameObjectWithTag("PanelList").transform.GetChild(3);

                panelWarning.gameObject.SetActive(true);
            }    
        }
    }

    public void OpenPanelLoot()
    {
        if (GameObject.FindGameObjectsWithTag("Panel").Length == 0)
        {
            dropBtn.GetChild(0).gameObject.SetActive(true);
            dropBtn.GetChild(1).gameObject.SetActive(false);

            int j = 0;
            panelLoot.gameObject.SetActive(true);
            Transform panel = GameObject.FindGameObjectWithTag("LootList").transform;
            audioListener.clip = audioOpen;
            audioListener.Play();

            panelLoot.GetChild(0).gameObject.SetActive(true);
            panelLoot.GetChild(1).gameObject.SetActive(false);
            moneyTxt.text = sceneController.money.ToString();

            foreach (var i in sceneController.lootList)
            {
                if (i.Value > 0)
                {
                    DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + i.Key);

                    panel.GetChild(j).GetChild(0).GetComponent<Text>().text = dataLoot.Name;
                    panel.GetChild(j).GetChild(1).GetComponent<Text>().text = i.Value.ToString();

                    Image lootImg = panel.GetChild(j).GetChild(2).GetComponent<Image>();

                    lootImg.sprite = dataLoot.img;
                    lootImg.color = new Color(lootImg.color.r, lootImg.color.g, lootImg.color.b, 1);
                    j++;
                }
            }

            for (int i = 0; i < panel.childCount; i++)
            {
                if (i >= sceneController.lootList.Count)
                {
                    panel.GetChild(i).GetComponent<Button>().enabled = false;

                    panel.GetChild(i).GetChild(0).GetComponent<Text>().text = "";
                    panel.GetChild(i).GetChild(1).GetComponent<Text>().text = "";
                    panel.GetChild(i).GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 0);
                }
                else
                {
                    panel.GetChild(i).GetComponent<Button>().enabled = true;
                }

                panel.GetChild(i).GetChild(3).gameObject.SetActive(false);
            }

            Text money = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();
            money.text = sceneController.money.ToString();
        }
    }

    public void OpenPanelBase()
    {
        if (GameObject.FindGameObjectsWithTag("Panel").Length == 0)
        {
            int j = 0;
            panelLoot.gameObject.SetActive(true);
            Transform panel = GameObject.FindGameObjectWithTag("LootList").transform;
            audioListener.clip = audioOpen;
            audioListener.Play();

            panelLoot.GetChild(0).gameObject.SetActive(false);
            panelLoot.GetChild(1).gameObject.SetActive(true);

            foreach (var i in BaseItems.items)
            {
                if (i.Value > 0)
                {
                    DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + i.Key);

                    panel.GetChild(j).GetChild(0).GetComponent<Text>().text = dataLoot.Name; //i.Key;
                    panel.GetChild(j).GetChild(1).GetComponent<Text>().text = i.Value.ToString();

                    Image lootImg = panel.GetChild(j).GetChild(2).GetComponent<Image>();

                    lootImg.sprite = dataLoot.img;
                    lootImg.color = new Color(lootImg.color.r, lootImg.color.g, lootImg.color.b, 1);
                    j++;
                }
            }

            for (int i = 0; i < panel.childCount; i++)
            {
                if (i >= BaseItems.items.Count)
                {
                    panel.GetChild(i).GetComponent<Button>().enabled = false;

                    panel.GetChild(i).GetChild(0).GetComponent<Text>().text = "";
                    panel.GetChild(i).GetChild(1).GetComponent<Text>().text = "";
                    panel.GetChild(i).GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 0);
                }
                else
                {
                    panel.GetChild(i).GetComponent<Button>().enabled = true;
                }

                panel.GetChild(i).GetChild(3).gameObject.SetActive(false);
            }

            Text money = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();
            money.text = sceneController.money.ToString();
        }
    }
}

// тест 2
