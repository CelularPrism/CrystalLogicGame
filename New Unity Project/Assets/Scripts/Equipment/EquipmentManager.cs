using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerStatic;

public class EquipmentManager : MonoBehaviour
{
    void Update()
    {
        int index = 0;

        foreach (var equip in PlayerStatic.equipmentList)
        {
            if (equip.Value != "")
            {
                DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + equip.Value);
                //Equip(dataLoot);

                transform.GetChild(index).GetComponent<Equipment>().loot = dataLoot;
                transform.GetChild(index).GetComponent<Image>().sprite = dataLoot.img;
                transform.GetChild(index).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
            index++;
        }
    }

    public void Equip(DataLoot dataLoot)
    {
        Transform equipTrans = transform;
        if (dataLoot.lootClass == DataLoot.classLoot.weapon)
        {
            equipTrans = transform.GetChild(0);
            PlayerStatic.equipmentList["weapon"] = dataLoot.name;
        } else if (dataLoot.lootClass == DataLoot.classLoot.shield)
        {
            equipTrans = transform.GetChild(1);
            PlayerStatic.equipmentList["shield"] = dataLoot.name;
        } else
        {
            if (transform.GetChild(2).GetComponent<Equipment>().isEquip == false)
            {
                equipTrans = transform.GetChild(2);
                transform.GetChild(3).GetComponent<Equipment>().isEquip = false;
                PlayerStatic.equipmentList["equip1"] = dataLoot.name;
            }
            else
            {
                equipTrans = transform.GetChild(3);
                transform.GetChild(2).GetComponent<Equipment>().isEquip = false;
                PlayerStatic.equipmentList["equip2"] = dataLoot.name;
            }

            equipTrans.GetComponent<Equipment>().isEquip = true;
        }

        equipTrans.GetComponent<Equipment>().loot = dataLoot;
        equipTrans.GetComponent<Image>().sprite = dataLoot.img;
        equipTrans.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }
}
