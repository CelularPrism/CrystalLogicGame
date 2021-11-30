using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour, BuildMethod
{
    public Dictionary<string, int> listRes { get; set; } = new Dictionary<string, int> { { "Wood", 1 } };
    public int price { get; set; } = 100;
    public string nameBuild { get; } = "Farm";

    public bool Build(Dictionary<string, int> listPlr, int gold)
    {
        foreach (var i in listRes)
            if (listPlr[i.Key] < i.Value || gold < price)
                return false;
        return true;
    }
}
