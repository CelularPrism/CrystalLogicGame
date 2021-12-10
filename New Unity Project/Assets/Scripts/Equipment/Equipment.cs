using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerStatic;

public class Equipment : MonoBehaviour
{
    public DataLoot loot;
    public bool isEquip = false;

    [SerializeField] private SceneController controller;

    void Update()
    {
        if (loot != null)
        {
            if (loot.lootClass == DataLoot.classLoot.weapon)
                controller.damage = loot.boostDamage;

            if (controller.costFuel == 2)
            {
                controller.costFuel /= loot.boostOil;
            }
        }
    }

    public void UseItem()
    {
        controller.health += loot.boostHealth;
        controller.iron += loot.boostIron;

        string key = "";

        foreach (var i in PlayerStatic.equipmentList)
        {
            if (i.Value == loot.name)
            {
                key = i.Key;
                break;
            }
        }

        if (key.Length > 0)
        {
            PlayerStatic.equipmentList[key] = "";
        }

        loot = null;
        transform.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
}
