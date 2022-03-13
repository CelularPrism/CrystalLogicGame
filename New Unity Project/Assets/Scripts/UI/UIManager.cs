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
            panelLoot.GetComponent<PanelLoot>().isDelivToBase = true;

            panelLoot.gameObject.SetActive(true);
            Transform panel = GameObject.FindGameObjectWithTag("LootList").transform;
            audioListener.clip = audioOpen;
            audioListener.Play();

            panelLoot.GetChild(0).gameObject.SetActive(true);
            panelLoot.GetChild(1).gameObject.SetActive(false);
            panelLoot.GetChild(3).GetChild(0).gameObject.SetActive(true);
            panelLoot.GetChild(3).GetChild(1).gameObject.SetActive(false);
            moneyTxt.text = sceneController.money.ToString();
            int j = 0;

            foreach (var i in sceneController.lootList)
            {
                if (i.Value > 0)
                {
                    DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + i.Key);

                    panel.GetChild(j).GetComponent<DescriptionScript>().dataLoot = dataLoot;
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
                    panel.GetChild(i).GetComponent<DescriptionScript>().dataLoot = null;

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
            panelLoot.GetChild(3).GetChild(0).gameObject.SetActive(false);
            panelLoot.GetChild(3).GetChild(1).gameObject.SetActive(true);
            panelLoot.GetComponent<PanelLoot>().isDelivToBase = false;

            foreach (var i in BaseItems.items)
            {
                if (i.Value > 0)
                {
                    DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + i.Key);

                    panel.GetChild(j).GetComponent<DescriptionScript>().dataLoot = dataLoot;
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
                    panel.GetChild(i).GetComponent<DescriptionScript>().dataLoot = null;

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

    public void UpdateSpecifications(Transform panelSpec)
    {
        for (int i = 0; i < panelSpec.childCount; i++)
        {
            Transform transSlider = panelSpec.GetChild(i).GetChild(1);
            Slider slider = transSlider.GetComponent<Slider>();
            Text text = transSlider.GetChild(3).GetComponent<Text>();

            if (i == 0)
            {
                slider.maxValue = sceneController.maxHealth;
                slider.value = sceneController.health;
                text.text = sceneController.health.ToString();
            }
            else if (i == 1)
            {
                slider.maxValue = sceneController.maxIron;
                slider.value = sceneController.iron;
                text.text = sceneController.iron.ToString();
            }
            else if (i == 2)
            {
                slider.value = sceneController.fuel;
                text.text = (sceneController.fuel / 2).ToString();
            }
        }
    }

    public void UpdateEquipment(Transform panelEquip)
    {
        int index = 0;
        foreach (var equip in PlayerStatic.equipmentList)
        {
            Image imgEquip = panelEquip.GetChild(index).GetChild(0).GetComponent<Image>();
            if (equip.Value == "")
            {
                imgEquip.color = new Color(255, 255, 255, 0);
            } else
            {
                DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + equip.Value);
                imgEquip.sprite = dataLoot.img;
                imgEquip.color = new Color(255, 255, 255, 255);
            }
            index++;
        }
    }
}

// тест 2
