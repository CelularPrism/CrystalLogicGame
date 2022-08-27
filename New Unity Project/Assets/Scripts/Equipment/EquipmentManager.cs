using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerStatic;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private Transform[] arrayEquip;

    private void Start()
    {
        UpdateEquipmentPanel();
    }

    void UpdateEquipmentPanel()
    {
        int index = 0;

        foreach (var equip in PlayerStatic.equipmentList)
        {
            if (equip.Value != null)
            {
                Debug.Log(equip);
                DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + equip.Value.name);
                //Equip(dataLoot);

                arrayEquip[index].GetComponent<Equipment>().loot = dataLoot;
                arrayEquip[index].GetComponent<Image>().sprite = dataLoot.img;
                arrayEquip[index].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
            index++;
        }
    }

    public void Equip(DataLoot dataLoot)
    {
        Transform equipTrans = arrayEquip[0];
        if (dataLoot.lootClass == DataLoot.classLoot.weapon)
        {
            equipTrans = arrayEquip[0];
            PlayerStatic.equipmentList["weapon"] = dataLoot;
            Debug.Log("weapon " + PlayerStatic.equipmentList["weapon"]);
        } else if (dataLoot.lootClass == DataLoot.classLoot.shield)
        {
            equipTrans = arrayEquip[1];
            PlayerStatic.equipmentList["shield"] = dataLoot;
            Debug.Log("shield " + PlayerStatic.equipmentList["shield"]);
        } else
        {
            if (arrayEquip[2].GetComponent<Equipment>().isEquip == false)
            {
                equipTrans = arrayEquip[2];
                arrayEquip[3].GetComponent<Equipment>().isEquip = false;
                PlayerStatic.equipmentList["equip1"] = dataLoot;
                Debug.Log("equip1 " + PlayerStatic.equipmentList["equip1"]);
            }
            else
            {
                equipTrans = arrayEquip[3];
                arrayEquip[2].GetComponent<Equipment>().isEquip = false;
                PlayerStatic.equipmentList["equip2"] = dataLoot;
                Debug.Log("equip2 " + PlayerStatic.equipmentList["equip2"]);
            }

            equipTrans.GetComponent<Equipment>().isEquip = true;
        }

        equipTrans.GetComponent<Equipment>().loot = dataLoot;
        equipTrans.GetComponent<Image>().sprite = dataLoot.img;
        equipTrans.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }
}
