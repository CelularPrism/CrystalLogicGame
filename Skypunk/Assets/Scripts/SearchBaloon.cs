using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchBaloon : MonoBehaviour
{
    [SerializeField] private Transform panelLoot;
    [SerializeField] private SceneController controller;

    private List<Item> listItem = new List<Item>();
    private DataLoot dataLoot;
    private int countLoot;

    private void Restart()
    {
        for (int i = 0; i < panelLoot.childCount; i++)
        {
            Transform child = panelLoot.GetChild(i);

            child.GetChild(0).gameObject.SetActive(false);
            child.GetChild(1).gameObject.SetActive(false);
            child.GetChild(2).gameObject.SetActive(false);
            child.GetChild(3).gameObject.SetActive(false);
        }
    }

    public void Reward()
    {
        transform.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(true);
        Looting();
        for (int i = 0; i < countLoot; i++)
        {
            if (panelLoot.GetChild(i).GetChild(0).gameObject.activeSelf)
            {
                SelectLoot(panelLoot.GetChild(i));
            }
        }
    }

    public void Looting()
    {
        Restart();
        countLoot = Random.Range(1, 7);

        for (int i = 0; i < countLoot; i++)
        {
            DataLoot[] listLoot = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");
            dataLoot = listLoot[Random.Range(0, listLoot.Length)];

            panelLoot.GetChild(i).GetChild(0).gameObject.SetActive(true);
            panelLoot.GetChild(i).GetChild(1).gameObject.SetActive(true);
            panelLoot.GetChild(i).GetChild(2).gameObject.SetActive(true);

            panelLoot.GetChild(i).GetChild(0).GetComponent<Image>().sprite = dataLoot.img; // Изображение лута
            panelLoot.GetChild(i).GetChild(1).GetComponent<Text>().text = dataLoot.Name; // Название лута
            panelLoot.GetChild(i).GetChild(2).GetComponent<Text>().text = Random.Range(1, 5).ToString(); // Количество лута
        }
    }

    public void SelectLoot(Transform btn)
    {
        if (!btn.GetChild(3).gameObject.activeSelf)
        {
            DataLoot[] listLoot = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");
            foreach (var i in listLoot)
            {
                if (i.Name == btn.GetChild(1).GetComponent<Text>().text)
                {
                    listItem.Add(new Item
                    {
                        index = btn.GetSiblingIndex(),
                        nameItem = i.name,
                        countItem = System.Convert.ToInt32(btn.GetChild(2).GetComponent<Text>().text)
                    });
                    Debug.Log(System.Convert.ToInt32(btn.GetChild(2).GetComponent<Text>().text));
                }
            }
            btn.GetChild(3).gameObject.SetActive(true);
        }
    }

    public void ConfirmLoot()
    {
        if (listItem.Count > 0)
        {
            foreach (var i in listItem)
            {
                if (!controller.lootList.ContainsKey(i.nameItem))
                {
                    controller.lootList[i.nameItem] = i.countItem;
                }
                else
                {
                    controller.lootList[i.nameItem] += i.countItem;
                }
            }
        }
        listItem = new List<Item>();

        transform.gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }
}
