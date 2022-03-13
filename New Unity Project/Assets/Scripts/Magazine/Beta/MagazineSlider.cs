using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MagazineSlider : MonoBehaviour
{
    [SerializeField] private int countStep;

    private Dictionary<string, int> dictItems;
    private int index = 0;
    private int multiplier = 0;

    public void UpdatePanel(Dictionary<string, int> dictionary, int multiplier, bool isProductMag)
    {
        //Debug.Log(transform.name + " " + dictionary.Count);

        int indexProduct = 0;
        int nowIndex = 0;
        dictItems = dictionary;
        this.multiplier = multiplier;
        foreach (var item in dictItems)
        {
            if (nowIndex >= index && nowIndex < index + countStep)
            {
                DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + item.Key);
                Transform product = transform.GetChild(indexProduct).GetChild(0);

                product.GetChild(0).gameObject.SetActive(true);
                product.GetChild(1).gameObject.SetActive(true);
                product.GetChild(2).gameObject.SetActive(true);

                product.parent.GetComponent<DescriptionScript>().dataLoot = dataLoot;
                product.parent.GetComponent<DescriptionScript>().dataLoot = dataLoot;
                product.GetChild(0).GetComponent<Text>().text = (dataLoot.price / multiplier).ToString();
                //product.GetChild(1).GetComponent<SpriteRenderer>().sprite = dataLoot.img;
                product.GetChild(1).GetComponent<Image>().sprite = dataLoot.img;
                product.GetChild(2).GetComponent<Text>().text = item.Value.ToString();

                MagazineItems magazineItems = product.GetComponent<MagazineItems>();
                magazineItems.enabled = true;
                magazineItems.SetData(dataLoot, item.Value, dataLoot.price / multiplier, isProductMag);
                magazineItems.SetIndex(indexProduct);

                indexProduct++;
            }
            nowIndex++;
        }

        while (indexProduct < transform.childCount)
        {
            Transform product = transform.GetChild(indexProduct).GetChild(0);
            product.position = Vector3.zero;
            //Debug.Log(product.name + " " + indexProduct);

            MagazineItems magazineItems = product.GetComponent<MagazineItems>();
            magazineItems.DeleteDataLoot();
            magazineItems.SetIndex(indexProduct);
            magazineItems.enabled = false;

            product.parent.GetComponent<DescriptionScript>().dataLoot = null;
            product.GetChild(0).GetComponent<Text>().text = "";
            product.GetChild(2).GetComponent<Text>().text = "";

            //product.GetChild(0).gameObject.SetActive(false);
            product.GetChild(1).gameObject.SetActive(false);
            //product.GetChild(2).gameObject.SetActive(false);

            indexProduct++;
        }
    }

    public void SlideRight(bool isProductMag)
    {
        index += countStep;

        if (index >= dictItems.Count)
            index = 0;

        UpdatePanel(dictItems, multiplier, isProductMag);
    }

    public void SlideLeft(bool isProductMag)
    {
        index -= countStep;

        if (index < 0)
            index = (dictItems.Count / countStep) * countStep;

        UpdatePanel(dictItems, multiplier, isProductMag);
    }

    public Dictionary<string, int> ListToDict(List<MagazineItemsOrder> list)
    {
        dictItems = list.ToDictionary(x => x.GetData().name, x => x.GetCount());

        foreach (var item in dictItems)
            Debug.Log(item.Key);

        return dictItems;
    }
}
