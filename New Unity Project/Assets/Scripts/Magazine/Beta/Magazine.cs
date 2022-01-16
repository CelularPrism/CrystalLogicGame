using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private Transform panelLoot;
    [SerializeField] private Transform panelMag;

    private List<MagazineItemsOrder> itemsOrder;
    private List<DataLoot> sellDataLoot;

    private Dictionary<DataLoot, int> dataProduct;
    private int money;

    private void Start()
    {
        money = Random.Range(10, 20) * 100;
    }

    public void Delete(MagazineItemsOrder itemOrder)
    {
        itemsOrder.Remove(itemOrder);
    }

    public void InsertOrder(MagazineItemsOrder itemOrder)
    {
        itemsOrder.Add(itemOrder);
    }

    public void Buy()
    {
        int sum = UpdateSum();

        if (sceneController.money + sum >= 0)
        {
            foreach (DataLoot dataLoot in sellDataLoot)
            {
                if (dataLoot.price > 0)
                {
                    if (sceneController.lootList[dataLoot.name] == 1)
                        sceneController.lootList.Remove(dataLoot.name);
                    else
                        sceneController.lootList[dataLoot.name] -= 1;

                    if (dataProduct.ContainsKey(dataLoot))
                        dataProduct[dataLoot] += 1;
                    else
                        dataProduct[dataLoot] = 1;
                } else
                {
                    if (dataProduct[dataLoot] == 1)
                        dataProduct.Remove(dataLoot);
                    else
                        dataProduct[dataLoot] -= 1;

                    if (sceneController.lootList.ContainsKey(dataLoot.name))
                        sceneController.lootList[dataLoot.name] += 1;
                    else
                        sceneController.lootList[dataLoot.name] = 1;
                }
            }
            UpdatePaneLoot();
            UpdatePanelMag();
        }
    }

    private int UpdateSum()
    {
        int sum = 0;
        sellDataLoot = new List<DataLoot>();

        foreach (MagazineItemsOrder item in itemsOrder)
        {
            DataLoot dataLoot = item.GetData();
            sum += dataLoot.price;

            sellDataLoot.Add(dataLoot);
        }
        return sum;
    }

    private void UpdatePaneLoot()
    {
        int index = 0;
        foreach (var loot in sceneController.lootList)
        {
            DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot" + loot.Key);
            Transform transLoot = panelLoot.GetChild(index).GetChild(0);
            transLoot.GetChild(0).GetComponent<Text>().text = dataLoot.price.ToString();
            transLoot.GetChild(1).GetComponent<Image>().sprite = dataLoot.img;
            transLoot.GetChild(2).GetComponent<Text>().text = loot.Value.ToString();

            
            transLoot.GetComponent<MagazineItems>().enabled = true;
            index++;
        }

        while (index <= panelLoot.childCount)
        {
            Transform transLoot = panelLoot.GetChild(index).GetChild(0);
            transLoot.GetComponent<MagazineItems>().enabled = false;
            index++;
        }
    }

    private void UpdatePanelMag()
    {
        int index = 0;
        foreach (var product in dataProduct)
        {
            Transform transLoot = panelMag.GetChild(index).GetChild(0);
            transLoot.GetChild(0).GetComponent<Text>().text = product.Key.price.ToString();
            transLoot.GetChild(1).GetComponent<Image>().sprite = product.Key.img;
            transLoot.GetChild(2).GetComponent<Text>().text = product.Value.ToString();

            MagazineItems magazineItems = transLoot.GetComponent<MagazineItems>();
            transLoot.GetComponent<MagazineItems>().enabled = true;
            magazineItems.dataLoot = product.Key;
            magazineItems.count = product.Value;
            index++;
        }

        while (index <= panelMag.childCount)
        {
            Transform transLoot = panelMag.GetChild(index).GetChild(0);
            transLoot.GetComponent<MagazineItems>().enabled = false;
            index++;
        }
    }
}
