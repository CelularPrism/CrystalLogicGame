using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armory : MonoBehaviour, BuildMethod
{
    public Dictionary<string, int> listRes { get; set; } = new Dictionary<string, int> { { "Metal", 50 },
                                                                                         { "Chemicals", 5 },
                                                                                         { "Electronics", 3 },
                                                                                         { "Supplies", 10 } };
    public int price { get; set; } = 1000;
    public string nameBuild { get; } = "Armory";

    public bool Build(Dictionary<string, int> listPlr, int gold)
    {
        foreach (var i in listRes)
            if (listPlr[i.Key] < i.Value || gold < price)
                return false;
        return true;
    }
}
