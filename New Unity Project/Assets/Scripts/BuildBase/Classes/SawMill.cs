using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMill : MonoBehaviour, BuildMethod
{
    public Dictionary<string, int> listRes { get; set; } = new Dictionary<string, int> { { "Cloth", 15 },
                                                                                         { "Supplies", 10 } };
    public int price { get; set; } = 100;
    public string nameBuild { get; } = "SawMill";
    public bool Build(Dictionary<string, int> listPlr, int gold)
    {
        foreach (var i in listRes)
            if (listPlr[i.Key] < i.Value || gold < price)
                return false;
        return true;
    }
}
