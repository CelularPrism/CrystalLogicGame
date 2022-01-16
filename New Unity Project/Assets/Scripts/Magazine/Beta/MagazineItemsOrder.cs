using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineItemsOrder : MonoBehaviour
{
    [SerializeField] private Magazine magazine;
    private DataLoot loot;
    private int count;

    public void Insert(DataLoot dataLoot, int count)
    {
        if (loot == null)
        {
            loot = dataLoot;
            this.count = count;
        }
        else
        {
            magazine.Delete(this);
        }

        magazine.InsertOrder(this);
    }

    public DataLoot GetData()
    {
        loot.price = loot.price * count;
        return loot;
    }
}
