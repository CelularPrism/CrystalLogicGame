using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Docks : MonoBehaviour, BuildMethod
{
    public Dictionary<string, int> listRes { get; set; } = new Dictionary<string, int> { };
    public int price { get; set; } = 0;
    public string nameBuild { get; } = "Docks";
    public bool Build(Dictionary<string, int> listPlr, int gold)
    {
        if (gold < price)
            return false;

        foreach (var i in listRes)
            if (listPlr[i.Key] < i.Value)
                return false;
        return true;
    }
}
