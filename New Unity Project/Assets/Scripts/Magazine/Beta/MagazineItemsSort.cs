using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineItemsSort : MonoBehaviour
{
    [SerializeField] private Transform[] arrayItems;
    [SerializeField] private bool isActive;
    public void SortItems(bool isMagazine)
    {
        if (isActive)
        {
            for (int index = 0; index < arrayItems.Length - 1; index++)
            {
                MagazineItems magazineItem = arrayItems[index].GetComponent<MagazineItems>();
                MagazineItems magazineItemNext = arrayItems[index + 1].GetComponent<MagazineItems>();
                if (magazineItem.GetData() == null)
                {
                    DataLoot dataLoot = magazineItemNext.GetData();
                    int count = magazineItemNext.GetCount();
                    int price = magazineItemNext.GetPrice();
                    magazineItem.SetData(dataLoot, count, price, isMagazine);

                    magazineItemNext.SetData(null, 0, 0, isMagazine);
                }
            }
        }
    }
}
