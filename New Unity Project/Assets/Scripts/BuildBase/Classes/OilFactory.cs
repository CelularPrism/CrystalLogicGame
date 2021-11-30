using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilFactory : MonoBehaviour, BuildMethod
{
    public Dictionary<string, int> listRes { get; set; } = new Dictionary<string, int> { { "Metal", 60 },
                                                                                         { "Supplies", 5 }, 
                                                                                         { "Petroleum", 10 }, 
                                                                                         { "Electronics", 1 } };
    public int price { get; set; } = 100;
    public string nameBuild { get; } = "OilFactory";

    public bool Build(Dictionary<string, int> listPlr, int gold)
    {
        foreach (var i in listRes)
            if (listPlr[i.Key] < i.Value || gold < price)
                return false;
        return true;
    }
}
