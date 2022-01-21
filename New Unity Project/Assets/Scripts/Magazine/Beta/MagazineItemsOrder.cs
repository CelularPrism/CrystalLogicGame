using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineItemsOrder : MonoBehaviour
{
    [SerializeField] private Magazine magazine;
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

        if (isProductMag)
        {
            magazine.InsertOrder(this, true);
        }
        else
        {
            magazine.InsertOrder(this, false);
        }
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
