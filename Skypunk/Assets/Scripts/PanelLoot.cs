using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BaseItems;

public class Item
{
    public int index { get; set; }
    public string nameItem { get; set; }
    public int countItem { get; set; }
}

public class PanelLoot : MonoBehaviour
{
    private List<Item> listLoot = new List<Item>();

    [SerializeField] private SceneController controller;
    [SerializeField] private Transform panelLoot;
    [SerializeField] private Transform courierList;

    public bool isDelete = true;

    public void SelectItem(Transform parent)
    {
        int maxCount = 6;
        string Name = "";
        int Count = 0;

        if (isDelete)
            maxCount = parent.parent.childCount;

        if (!parent.GetChild(3).gameObject.activeSelf && listLoot.Count < maxCount && controller.lootList.Count > 0)
        {
            foreach (var i in controller.lootList)
            {
                DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + i.Key);
                if (dataLoot.Name == parent.GetChild(0).GetComponent<Text>().text)
                {
                    Name = dataLoot.name;
                    Count = Convert.ToInt32(parent.GetChild(1).GetComponent<Text>().text); 
                    parent.GetChild(3).gameObject.SetActive(true);
                    listLoot.Add(new Item() { index = parent.GetSiblingIndex(), nameItem = Name, countItem = Count });
                }
            }            
        }
    }

    public void Check()
    {
        if (isDelete)
        {
            DeleteItem();
        }
        else
        {
            Delivery();
        }
    }

    public void DeleteItem()
    {
        foreach (Item i in listLoot)
        {
            Transform item = panelLoot.GetChild(i.index);
            item.GetChild(0).GetComponent<Text>().text = "";
            item.GetChild(1).GetComponent<Text>().text = "";
            item.GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 0);
            item.GetChild(3).gameObject.SetActive(false);

            controller.lootList.Remove(i.nameItem);
        }
        listLoot = new List<Item>();
        transform.gameObject.SetActive(false);
    }

    public void Delivery()
    {
        foreach (var i in listLoot)
        {
            BaseItems.items[i.nameItem] = i.countItem;
            controller.lootList.Remove(i.nameItem);
        }

        for (var i = 0; i < listLoot.Count; i++)
        {
            DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + listLoot[i].nameItem);

            courierList.GetChild(i).GetChild(0).GetComponent<Image>().sprite = dataLoot.img;
            courierList.GetChild(i).GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 1);

            courierList.GetChild(i).GetChild(1).GetComponent<Text>().text = dataLoot.Name;
            courierList.GetChild(i).GetChild(2).GetComponent<Text>().text = listLoot[i].countItem.ToString();
        }

        foreach (var i in BaseItems.items)
        {
            Debug.Log(i.Key + " " + i.Value);
        }

        listLoot = new List<Item>();
        isDelete = true;
        transform.gameObject.SetActive(false);
    }
}
