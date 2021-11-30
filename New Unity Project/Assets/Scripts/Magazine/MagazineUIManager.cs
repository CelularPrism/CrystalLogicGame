using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazineUIManager : MonoBehaviour
{
    public Transform panelMagazine;
    public Text amountText;
    public Text moneyPlayerText;
    public Text moneyMagText;

    private List<Item> listItemMag = new List<Item>();

    private List<Item> listItemBuy = new List<Item>();
    private List<Item> listItemSell = new List<Item>();

    private SceneController sceneController;

    public int amount = 0;
    public int moneyPlayer = 0;
    public int moneyMag = 0;

    private int nowIndex = 6;
    public bool share;

    void Restart()
    {
        listItemBuy = new List<Item>();
        listItemSell = new List<Item>();
        DataLoot dataLoot = new DataLoot();
        panelMagazine.GetChild(11).gameObject.SetActive(false);
        amount = 0;

        for (int i = 0; i < panelMagazine.GetChild(2).childCount; i++)
        {
            Transform itemMag = panelMagazine.GetChild(2).GetChild(i);

            itemMag.GetChild(0).GetComponent<Image>().sprite = null;
            itemMag.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);

            itemMag.GetChild(1).GetComponent<Text>().text = "";
            //itemMag.GetChild(2).GetComponent<Text>().text = "";
            itemMag.GetChild(3).GetComponent<Text>().text = "";
            itemMag.GetChild(4).gameObject.SetActive(false);
        }

        for (int i = 0; i < listItemMag.Count; i++)
        {
            if (i < 6)
            {
                DataLoot[] listData = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");

                for (int k = 0; k < listData.Length; k++)
                {
                    if (listItemMag[i].nameItem == listData[k].Name)
                    {
                        dataLoot = listData[k];
                        break;
                    }
                }

                Transform itemMag = panelMagazine.GetChild(2).GetChild(i);

                itemMag.GetChild(0).GetComponent<Image>().sprite = dataLoot.img;
                itemMag.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);

                itemMag.GetChild(1).GetComponent<Text>().text = dataLoot.Name;
                //itemMag.GetChild(2).GetComponent<Text>().text = listItemMag[i].countItem.ToString();
                itemMag.GetChild(3).GetComponent<Text>().text = dataLoot.price.ToString();
                itemMag.GetChild(4).gameObject.SetActive(false);
            }
        }

        int j = 0;

        foreach (var i in sceneController.lootList)
        {
            if (j < 6)
            {
                Transform itemPlayer = panelMagazine.GetChild(5).GetChild(j);
                dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + i.Key);
                itemPlayer.GetChild(0).GetComponent<Image>().sprite = dataLoot.img;
                itemPlayer.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);

                itemPlayer.GetChild(1).GetComponent<Text>().text = dataLoot.Name;
                itemPlayer.GetChild(2).GetComponent<Text>().text = i.Value.ToString();
                itemPlayer.GetChild(3).GetComponent<Text>().text = dataLoot.price.ToString();
                itemPlayer.GetChild(4).gameObject.SetActive(false);
                j++;
            }
            else
                break;
        }

        for (j = j; j < 6; j++)
        {
            Transform itemPlayer = panelMagazine.GetChild(5).GetChild(j);

            itemPlayer.GetChild(0).GetComponent<Image>().sprite = null;
            itemPlayer.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);

            itemPlayer.GetChild(1).GetComponent<Text>().text = "";
            itemPlayer.GetChild(2).GetComponent<Text>().text = "";
            itemPlayer.GetChild(3).GetComponent<Text>().text = "";
            itemPlayer.GetChild(4).gameObject.SetActive(false);
        }

    }

    void Update()
    {

        if (amount < 0)
        {
            amountText.text = (-amount).ToString();

            panelMagazine.GetChild(3).GetChild(1).gameObject.SetActive(true);
            panelMagazine.GetChild(3).GetChild(2).gameObject.SetActive(true);

            panelMagazine.GetChild(3).GetChild(1).rotation = new Quaternion(0f, 0f, 180f, 0f);
            panelMagazine.GetChild(7).gameObject.SetActive(false);
            panelMagazine.GetChild(8).gameObject.SetActive(true);
        } else if (amount > 0)
        {
            amountText.text = amount.ToString();

            panelMagazine.GetChild(3).GetChild(1).gameObject.SetActive(true);
            panelMagazine.GetChild(3).GetChild(2).gameObject.SetActive(true);

            panelMagazine.GetChild(3).GetChild(1).rotation = new Quaternion(0f, 0f, 0f, 0f);
            panelMagazine.GetChild(7).gameObject.SetActive(true);
            panelMagazine.GetChild(8).gameObject.SetActive(false);
        } else
        {
            panelMagazine.GetChild(3).GetChild(1).gameObject.SetActive(false);
            panelMagazine.GetChild(3).GetChild(2).gameObject.SetActive(false);

            panelMagazine.GetChild(7).gameObject.SetActive(false);
            panelMagazine.GetChild(8).gameObject.SetActive(false);
        }
        moneyPlayerText.text = moneyPlayer.ToString();
        moneyMagText.text = moneyMag.ToString();

        if (Input.GetKeyDown(KeyCode.LeftAlt))
            share = true;
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
            share = false;
    }

    public void SwapLootRight()
    {
        if (sceneController.lootList.Count > 6)
        {
            Swap();
            if (nowIndex + 6 < sceneController.lootList.Count)
                nowIndex += 6;
            else
                nowIndex = 0;
        }
    }

    public void SwapLootLeft()
    {
        if (sceneController.lootList.Count > 6)
        {
            Swap();

            int num = 6 * Convert.ToInt32(Mathf.Ceil(sceneController.lootList.Count / 6));

            if (nowIndex - 6 >= 0)
                nowIndex -= 6;
            else
                nowIndex = num;
        }
    }

    public void OpenMagazine(SceneController controller)
    {
        sceneController = controller;
        moneyPlayer = controller.money;
        moneyMag = UnityEngine.Random.Range(1500, 2000);

        Restart();

        DataLoot[] list = GenerateProduct();
        ShowDataLoot(list);

        panelMagazine.parent.gameObject.SetActive(true);
        panelMagazine.gameObject.SetActive(true);
    }

    public void SelectItem(Transform item)
    {
        Item newItem = new Item()
        {
            index = item.GetSiblingIndex(),
            countItem = Convert.ToInt32(item.GetChild(2).GetComponent<Text>().text),
            nameItem = item.GetChild(1).GetComponent<Text>().text,
            priceItem = Convert.ToInt32(item.GetChild(3).GetComponent<Text>().text)
        };

        if (share)
        {
            MagazineScript magazineScript = panelMagazine.GetChild(12).GetComponent<MagazineScript>();

            magazineScript.Item = newItem;
            magazineScript.transItem = item;

            magazineScript.OpenPanel();
        } 
        else
        {
            if (!item.GetChild(4).gameObject.activeSelf)
                EnabledItem(newItem, item);
            else
                DisabledItem(item);
        }
    }

    public void BuySell()
    {
        if (moneyPlayer + amount >= 0 && moneyMag - amount >= 0)
        {
            sceneController.money += amount;
            moneyPlayer = sceneController.money;
            moneyMag -= amount;

            DataLoot[] listData = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");
            string nameItem = "";

            for (int i = 0; i < listItemBuy.Count; i++)
            {
                for (int j = 0; j < listData.Length; j++)
                {
                    if (listItemBuy[i].nameItem == listData[j].Name)
                    {
                        nameItem = listData[j].name;

                        if (!sceneController.lootList.ContainsKey(nameItem))
                            sceneController.lootList[nameItem] = listItemBuy[i].countItem;
                        else
                            sceneController.lootList[nameItem] += listItemBuy[i].countItem;
                    }
                }

                for (int k = 0; k < listItemMag.Count; k++)
                {
                    if (listItemMag[k].nameItem == listItemBuy[i].nameItem)
                        if (listItemMag[k].countItem - listItemBuy[i].countItem == 0)
                            listItemMag.RemoveAt(k);
                        else
                            listItemMag[k].countItem -= listItemBuy[i].countItem;
                }
            }

            for (int i = 0; i < listItemSell.Count; i++)
            {
                for (int j = 0; j < listData.Length; j++)
                {
                    if (listItemSell[i].nameItem == listData[j].Name)
                    {
                        nameItem = listData[j].name;

                        if (sceneController.lootList[nameItem] - listItemSell[i].countItem == 0)
                            sceneController.lootList.Remove(nameItem);
                        else
                            sceneController.lootList[nameItem] -= listItemSell[i].countItem;

                        /*if (listItemMag.Count > 0)
                        {
                            for (int item = 0; item < listItemMag.Count; item++)
                            {
                                if (listItemMag[item].nameItem == listItemSell[i].nameItem)
                                {
                                    listItemMag[item].countItem += listItemSell[i].countItem;
                                    break;
                                }

                                if (item == listItemMag.Count - 1 && i == listItemSell.Count - 1)
                                {
                                    listItemMag.Add(listItemSell[i]);
                                    break;
                                }
                            }
                        } else
                            listItemMag.Add(listItemSell[i]);*/
                    }
                }
            }

            panelMagazine.GetChild(11).gameObject.SetActive(true);
            Restart();
        }
        else
        {
            panelMagazine.GetChild(11).gameObject.SetActive(true);
        }
    }

    private void Swap()
    {
        int index = 0;
        int j = 0;

        foreach (var i in sceneController.lootList)
        {
            if (j >= nowIndex && j < nowIndex + 6)
            {
                Transform item = panelMagazine.GetChild(5).GetChild(index);
                DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + i.Key);

                item.GetChild(0).GetComponent<Image>().sprite = dataLoot.img;
                item.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);

                item.GetChild(1).GetComponent<Text>().text = dataLoot.Name;
                item.GetChild(2).GetComponent<Text>().text = i.Value.ToString();
                item.GetChild(3).GetComponent<Text>().text = dataLoot.price.ToString();

                foreach (Item k in listItemSell)
                {
                    if (k.nameItem == dataLoot.Name)
                    {
                        item.GetChild(4).gameObject.SetActive(true);
                        break;
                    } else
                    {
                        item.GetChild(4).gameObject.SetActive(false);
                    }
                }
                index++;
            }
            j++;
        }

        while (j < nowIndex + 6)
        {
            Transform item = panelMagazine.GetChild(5).GetChild(index);
            item.GetChild(0).GetComponent<Image>().sprite = null;
            item.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);

            item.GetChild(1).GetComponent<Text>().text = "";
            item.GetChild(2).GetComponent<Text>().text = "";
            item.GetChild(3).GetComponent<Text>().text = "";
            item.GetChild(4).gameObject.SetActive(false);

            index++;
            j++;
        }
    }

    public void EnabledItem(Item newItem, Transform item, int count = -1)
    {
        if (count >= 0)
        {
            newItem.countItem = count;
        }

        if (item.parent.tag == "MagList")
        {
            listItemBuy.Add(newItem);
            amount -= newItem.countItem * newItem.priceItem;

            item.GetChild(4).gameObject.SetActive(true);
        }
        else
        {
            listItemSell.Add(newItem);
            amount += newItem.countItem * newItem.priceItem;

            item.GetChild(4).gameObject.SetActive(true);
        }
    }

    private void DisabledItem(Transform item)
    {
        

        if (item.parent.tag == "MagList")
        {
            foreach (Item newItem in listItemBuy)
            {
                if (item.GetSiblingIndex() == newItem.index)
                {
                    listItemBuy.Remove(newItem);
                    amount += newItem.countItem * newItem.priceItem;

                    item.GetChild(4).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            foreach (Item newItem in listItemSell)
            {
                if (item.GetSiblingIndex() == newItem.index)
                {
                    listItemSell.Remove(newItem);
                    amount -= newItem.countItem * newItem.priceItem;

                    item.GetChild(4).gameObject.SetActive(false);
                }
            }
        }
    }

    private DataLoot[] GenerateProduct()
    {
        listItemMag = new List<Item>();

        int count = UnityEngine.Random.Range(1, 7);

        DataLoot[] dataList = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");
        DataLoot[] dataLoots = new DataLoot[count];

        while(count > 0)
        {
            int numData = UnityEngine.Random.Range(0, dataList.Length);
            DataLoot dataLoot = dataList[numData];

            if (dataLoot.equipment)
            {
                dataLoots[count - 1] = dataLoot;

                listItemMag.Add(new Item
                {
                    index = count - 1,
                    nameItem = dataLoot.Name,
                    countItem = 1,//UnityEngine.Random.Range(1, 6),
                    priceItem = dataLoot.price
                });

                count -= 1;
            }

            List<DataLoot> list = new List<DataLoot>(dataList);
            list.RemoveAt(numData);
            dataList = list.ToArray();
        }
        return dataLoots;
    }

    private void ShowDataLoot(DataLoot[] dataLoots)
    {
        for (int i = 0; i < dataLoots.Length; i++) {
            Transform item = panelMagazine.GetChild(2).GetChild(i);
            int countItem = listItemMag[i].countItem;

            item.GetChild(0).GetComponent<Image>().sprite = dataLoots[i].img;
            item.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);

            item.GetChild(1).GetComponent<Text>().text = dataLoots[i].Name;
            //item.GetChild(2).GetComponent<Text>().text = countItem.ToString();
            item.GetChild(3).GetComponent<Text>().text = dataLoots[i].price.ToString();
        }
    }
}
