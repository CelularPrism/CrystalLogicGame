using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazineItemsOrder : MonoBehaviour
{
    [SerializeField] private Magazine magazine;
    [SerializeField] private Color lightOnColor;
    [SerializeField] private Color lightOffColor;
    private DataLoot loot;
    private int count;
    private int price;
    private bool isProductMag;

    public void Insert(DataLoot dataLoot, int count, int price, bool isProductMag)
    {
        if (loot == null)
        {
            loot = dataLoot;
            this.count = count;
            this.price = price;
            this.isProductMag = isProductMag;
        }
        else
        {
            if (this.isProductMag)
            {
                magazine.Delete(this, true);
            }
            else
            {
                magazine.Delete(this, false);
            }

            loot = dataLoot;
            this.count = count;
            this.price = price;
            this.isProductMag = isProductMag;
        }
        //Debug.Log(isProductMag);
        if (isProductMag)
        {
            magazine.InsertOrder(this, true);
        }
        else
        {
            this.price /= 2;
            magazine.InsertOrder(this, false);
        }
    }

    public void LightOn()
    {
        transform.GetChild(0).GetComponent<Image>().color = lightOnColor;
    }

    public void LightOff()
    {
        transform.GetChild(0).GetComponent<Image>().color = lightOffColor;
    }

    public bool IsProductMag()
    {
        return isProductMag;
    }
    public int GetCount()
    {
        return count;
    }
    public int GetPrice()
    {
        return price;
    }
    public DataLoot GetData()
    {
        return loot;
    }

    public void Clear()
    {
        loot = null;
        count = 0;
    }
}
