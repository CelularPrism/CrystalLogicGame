using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalFactory : MonoBehaviour, BuildMethod
{
    public Dictionary<string, int> listRes { get; set; } = new Dictionary<string, int> { { "Metal", 5 },
                                                                                         { "Chemicals", 10 } };
    public int price { get; set; } = 100;
    public string nameBuild { get; } = "ChemicalFactory";
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
