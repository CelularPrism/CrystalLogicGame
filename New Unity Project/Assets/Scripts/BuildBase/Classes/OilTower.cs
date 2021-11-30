using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilTower : MonoBehaviour, BuildMethod
{
    public Dictionary<string, int> listRes { get; set; } = new Dictionary<string, int> { { "Metal", 10 },
                                                                                         { "Chemicals", 10 },
                                                                                         { "Electronics", 1 } };
    public int price { get; set; } = 100;
    public string nameBuild { get; } = "OilTower";

    public bool Build(Dictionary<string, int> listPlr, int gold)
    {
        foreach (var i in listRes)
            if (listPlr[i.Key] < i.Value || gold < price)
                return false;
        return true;
    }
}
