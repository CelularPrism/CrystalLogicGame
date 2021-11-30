using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Build", menuName = "Scriptable objects/Build")]
public class DataBuild : ScriptableObject
{
    string resName1 { get; }
    int resCount1 { get; set; }
    string resName2 { get; }
    int resCount2 { get; set; }
    int price { get; set; }

    public bool Build(int resPlayer1, int resPlayer2, int gold)
    {
        if (resPlayer1 >= resCount1 && resPlayer2 >= resCount2 && gold >= price)
            return true;
        return false;
    }
}
