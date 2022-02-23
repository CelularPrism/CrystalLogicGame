using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private Transform panelLoot;
    [SerializeField] private Transform panelMag;
    [SerializeField] private Transform salePanel;
    [SerializeField] private Transform saleBtn;
    [SerializeField] private GameObject textError;

    [SerializeField] private Text textMoney;
    [SerializeField] private Text textMoneyMag;
    [SerializeField] private Text textMoneyLoot;

    private List<MagazineItemsOrder> itemsOrder = new List<MagazineItemsOrder>();

    private Dictionary<DataLoot, int> dataProduct  = new Dictionary<DataLoot, int>();
    private int moneyMag = 0;

    private void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();

        moneyMag = Random.Range(10, 20) * 100;
        textMoneyMag.text = moneyMag.ToString();
        textMoneyLoot.text = sceneController.money.ToString();

        //GenerateLoot();
        GenerateMagazine();
        GenerateSaleProduct();
    }

    private void Update()
    {
        bool isActive = false;
        for (int index = 0; index < panelLoot.childCount; index++)
        {
            if (panelLoot.GetChild(index).GetChild(0).position.z > 0)
            {
                isActive = true;
                DisabledScript(index, false);
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            }

            if (panelMag.GetChild(index).GetChild(0).position.z > 0)
            {
                isActive = true;
                DisabledScript(index, true);
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            }
        }

        if (isActive == false && itemsOrder.Count == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }

        if (isActive == false)
        {
            EnabledScript();
        }
    }

    public void Delete(MagazineItemsOrder itemOrder, bool isProduct)
    {
        itemsOrder.Remove(itemOrder);

        if (isProduct)
            dataProduct[itemOrder.GetData()] = itemOrder.GetCount();
        else
            sceneController.lootList[itemOrder.GetData().name] = itemOrder.GetCount();

        UpdateCart();
        UpdatePanelMag();
        UpdatePanelLoot();
    }

    public void InsertOrder(MagazineItemsOrder itemOrder, bool isProduct)
    {
        //Debug.Log(isProduct);
        itemsOrder.Add(itemOrder);
        if (isProduct)
            dataProduct.Remove(itemOrder.GetData());
        else
            sceneController.lootList.Remove(itemOrder.GetData().name);

        UpdateCart();
        UpdatePanelMag();
        UpdatePanelLoot();
    }

    public void Cancel()
    {
        foreach (MagazineItemsOrder item in itemsOrder)
        {
            DataLoot dataLoot = item.GetData();
            int count = item.GetCount();

            if (item.IsProductMag())
                dataProduct[dataLoot] = count;
            else
                sceneController.lootList[dataLoot.name] = count;
        }

        itemsOrder = new List<MagazineItemsOrder>();

        UpdateCart();
        UpdatePanelLoot();
        UpdatePanelMag();
        UpdateTextSum();
    }

    public void BuySell()
    {
        int sum = UpdateSum();
        textError.SetActive(false);

        if (sceneController.money + sum >= 0)
        {
            textError.SetActive(false);
            foreach (MagazineItemsOrder item in itemsOrder)
            {
                DataLoot dataLoot = item.GetData();
                int count = item.GetCount();
                if (!item.IsProductMag())
                {
                    if (dataProduct.ContainsKey(dataLoot))
                        dataProduct[dataLoot] += count;
                    else
                        dataProduct[dataLoot] = count;
                } else
                {
                    if (sceneController.lootList.ContainsKey(dataLoot.name))
                        sceneController.lootList[dataLoot.name] += count;
                    else
                        sceneController.lootList[dataLoot.name] = count;
                }
                item.Clear();
            }
            itemsOrder = new List<MagazineItemsOrder>();

            moneyMag -= sum;
            sceneController.money += sum;

            textMoneyMag.text = moneyMag.ToString();
            textMoneyLoot.text = sceneController.money.ToString();

            UpdateCart();
            UpdatePanelLoot();
            UpdatePanelMag();
            UpdateTextSum();
        } else
        {
            textError.SetActive(true);
        }
    }

    public void BuySaleProduct(MagazineItems magazineItems)
    {
        if (sceneController.money > magazineItems.GetPrice())
        {
            salePanel.GetChild(0).gameObject.SetActive(false);
            salePanel.GetChild(1).gameObject.SetActive(false);
            salePanel.GetChild(2).gameObject.SetActive(false);
            sceneController.lootList[magazineItems.GetData().name] = magazineItems.GetCount();

            moneyMag += magazineItems.GetPrice();
            sceneController.money -= magazineItems.GetPrice();

            textMoneyMag.text = moneyMag.ToString();
            textMoneyLoot.text = sceneController.money.ToString();
            
            textError.SetActive(false);
            UpdatePanelLoot();
        }
        else
        {
            textError.SetActive(true);
        }
    }

    private void GenerateMagazine()
    {
        int countItem = Random.Range(10, 16);
        DataLoot[] dataLootList = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");

        List<DataLoot> dataList = new List<DataLoot>();

        foreach (DataLoot data in dataLootList)
            //if (data.equipment)
                dataList.Add(data as DataLoot);

        for (int index = 0; index < countItem; index++)
        {
            int num = Random.Range(0, dataList.Count - 1);

            DataLoot dataLoot = dataList[num];

            if (dataLoot.price < 0)
                dataLoot.price = -dataLoot.price;
            dataProduct[dataLoot] = 1;

            dataList.Remove(dataLoot);
        }
        UpdatePanelMag();
        UpdatePanelLoot();
    }

    private void GenerateSaleProduct()
    {
        DataLoot[] dataLoots = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");
        List<DataLoot> listData = new List<DataLoot>();

        foreach (DataLoot data in dataLoots)
            if (data.equipment)
                listData.Add(data);

        int num = Random.Range(0, listData.Count - 1);
        DataLoot dataLoot = listData[num];

        salePanel.GetChild(0).GetComponent<Text>().text = "1";
        salePanel.GetChild(1).GetComponent<SpriteRenderer>().sprite = dataLoot.img;
        salePanel.GetChild(2).GetComponent<Text>().text = dataLoot.price.ToString();

        salePanel.GetChild(0).gameObject.SetActive(true);
        salePanel.GetChild(1).gameObject.SetActive(true);
        salePanel.GetChild(2).gameObject.SetActive(true);

        float percent = Random.Range(0.2f, 0.5f);
        int price = Mathf.RoundToInt(dataLoot.price * percent);

        Transform parent = salePanel.parent.parent;

        parent.GetChild(2).GetChild(1).GetComponent<Text>().text = price.ToString();
        salePanel.GetComponent<MagazineItems>().SetData(dataLoot, 1, price, true);
    }

    private void GenerateLoot()
    {
        int countItem = Random.Range(1, 9);
        DataLoot[] dataLootList = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");

        List<DataLoot> dataList = new List<DataLoot>();
        sceneController.lootList = new Dictionary<string, int>();

        foreach (DataLoot data in dataLootList)
            if (!data.equipment)
                dataList.Add(data);

        for (int index = 0; index < countItem; index++)
        {
            int num = Random.Range(0, dataList.Count - 1);

            DataLoot dataLoot = dataList[num];

            if (dataLoot.price < 0)
                dataLoot.price = -dataLoot.price;

            sceneController.lootList[dataLoot.name] = Random.Range(1, 10);

            dataList.Remove(dataLoot);
        }
        UpdatePanelLoot();
    }

    private void UpdateCart()
    {
        /*MagazineSlider magazineSlider = itemsOrder[0].transform.parent.GetComponent<MagazineSlider>();
        Dictionary<string, int> dict = magazineSlider.ListToDict(itemsOrder);
        magazineSlider.UpdatePanel(dict, 1);*/


        foreach (MagazineItemsOrder item in itemsOrder)
        {
            Transform panel = item.transform.GetChild(0);
            DataLoot dataLoot = item.GetData();

            panel.GetChild(0).GetComponent<Text>().text = item.GetPrice().ToString();

            panel.GetChild(1).GetComponent<SpriteRenderer>().sprite = dataLoot.img;
            panel.GetChild(2).GetComponent<Text>().text = item.GetCount().ToString();

            panel.GetChild(0).gameObject.SetActive(true);
            panel.GetChild(1).gameObject.SetActive(true);
            panel.GetChild(2).gameObject.SetActive(true);
        }

        foreach (Transform trans in transform.GetChild(1))
        {
            bool isEmpty = true;
            foreach (MagazineItemsOrder item in itemsOrder)
                if (item.transform == trans)
                {
                    isEmpty = false;
                    break;
                }

            if (isEmpty)
            {
                trans.GetChild(0).GetChild(0).gameObject.SetActive(false);
                trans.GetChild(0).GetChild(1).gameObject.SetActive(false);
                trans.GetChild(0).GetChild(2).gameObject.SetActive(false);
            }
        }
        UpdateTextSum();
    }

    private int UpdateSum()
    {
        int sum = 0;

        foreach (MagazineItemsOrder item in itemsOrder)
        {
            DataLoot dataLoot = item.GetData();

            if (item.IsProductMag())
                sum -= dataLoot.price * item.GetCount();
            else
                sum += (dataLoot.price / 2) * item.GetCount();
        }

        return sum;
    }

    private void UpdateTextSum()
    {
        int sum = UpdateSum();

        if (sum > 0)
        {
            saleBtn.GetChild(0).gameObject.SetActive(true);
            saleBtn.GetChild(1).gameObject.SetActive(false);
        } else
        {
            saleBtn.GetChild(0).gameObject.SetActive(false);
            saleBtn.GetChild(1).gameObject.SetActive(true);
        }

        textMoney.text = sum.ToString();
    }

    private void UpdatePanelLoot()
    {
        //int index = 0;

        panelLoot.GetComponent<MagazineSlider>().UpdatePanel(sceneController.lootList, 2, false);

        /*foreach (var loot in sceneController.lootList)
        {
            if (index < panelLoot.childCount)
            {
                DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + loot.Key);
                Transform transLoot = panelLoot.GetChild(index).GetChild(0);
                transLoot.GetChild(0).GetComponent<Text>().text = (dataLoot.price / 2).ToString();
                transLoot.GetChild(1).GetComponent<SpriteRenderer>().sprite = dataLoot.img;
                transLoot.GetChild(2).GetComponent<Text>().text = loot.Value.ToString();

                transLoot.GetChild(0).gameObject.SetActive(true);
                transLoot.GetChild(1).gameObject.SetActive(true);
                transLoot.GetChild(2).gameObject.SetActive(true);

                MagazineItems magazineItems = transLoot.GetComponent<MagazineItems>();
                magazineItems.enabled = true;
                magazineItems.SetData(dataLoot, loot.Value, dataLoot.price / 2, false);
                index++;
            }
        }

        while (index < panelLoot.childCount)
        {
            Transform transLoot = panelLoot.GetChild(index).GetChild(0);

            transLoot.position = Vector3.zero;
            transLoot.GetComponent<MagazineItems>().DeleteDataLoot();
            transLoot.GetComponent<MagazineItems>().enabled = false;

            transLoot.GetChild(0).gameObject.SetActive(false);
            transLoot.GetChild(1).gameObject.SetActive(false);
            transLoot.GetChild(2).gameObject.SetActive(false);
            index++;
        }*/
    }

    private void UpdatePanelMag()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach (var product in dataProduct)
            dict[product.Key.name] = product.Value;

        panelMag.GetComponent<MagazineSlider>().UpdatePanel(dict, 1, true);

        /*int index = 0;
        foreach (var product in dataProduct)
        {
            if (index < panelMag.childCount)
            {
                Transform transLoot = panelMag.GetChild(index).GetChild(0);
                transLoot.GetChild(0).GetComponent<Text>().text = product.Key.price.ToString();
                transLoot.GetChild(1).GetComponent<SpriteRenderer>().sprite = product.Key.img;
                transLoot.GetChild(2).GetComponent<Text>().text = product.Value.ToString();

                transLoot.GetChild(0).gameObject.SetActive(true);
                transLoot.GetChild(1).gameObject.SetActive(true);
                transLoot.GetChild(2).gameObject.SetActive(true);

                MagazineItems magazineItems = transLoot.GetComponent<MagazineItems>();
                magazineItems.enabled = true;
                magazineItems.SetData(product.Key, product.Value, product.Key.price, true);
                index++;
            }
        }

        while (index < panelMag.childCount)
        {
            Transform transLoot = panelMag.GetChild(index).GetChild(0);

            transLoot.position = Vector3.zero;
            transLoot.GetComponent<MagazineItems>().DeleteDataLoot();
            transLoot.GetComponent<MagazineItems>().enabled = false;

            transLoot.GetChild(0).gameObject.SetActive(false);
            transLoot.GetChild(1).gameObject.SetActive(false);
            transLoot.GetChild(2).gameObject.SetActive(false);
            index++;
        }*/
    }

    private void EnabledScript()
    {
        for (int index = 0; index < panelLoot.childCount; index++)
        {
            panelMag.GetChild(index).GetChild(0).GetComponent<MagazineItems>().enabled = true;
            panelLoot.GetChild(index).GetChild(0).GetComponent<MagazineItems>().enabled = true;
        }
    }

    private void DisabledScript(int index, bool isMagazine)
    {
        if (isMagazine)
        {
            for (int i = 0; i < panelMag.childCount; i++)
            {
                if (i != index)
                {
                    panelLoot.GetChild(i).GetChild(0).GetComponent<MagazineItems>().enabled = false;
                    panelMag.GetChild(i).GetChild(0).GetComponent<MagazineItems>().enabled = false;
                } else
                {
                    panelLoot.GetChild(i).GetChild(0).GetComponent<MagazineItems>().enabled = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < panelLoot.childCount; i++)
            {
                if (i != index)
                {
                    panelLoot.GetChild(i).GetChild(0).GetComponent<MagazineItems>().enabled = false;
                    panelMag.GetChild(i).GetChild(0).GetComponent<MagazineItems>().enabled = false;
                } else
                {
                    panelMag.GetChild(i).GetChild(0).GetComponent<MagazineItems>().enabled = false;
                }
            }
        }
    }
}
