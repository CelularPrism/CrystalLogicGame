using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ivent", menuName = "Scriptable objects/Ivents/Ivent")]
public class DataIvent : ScriptableObject
{
    public DataLocalisationIvent localisationIvent;
    public AudioClip audioText;
    public string TextHeader;
    public string Text;

    public AudioClip audioTextA;
    public string VarA;
    public string TextA;
    public DataLoot dataLootA;
    public Sprite lootA;
    public int countA;

    public AudioClip audioTextB;
    public string VarB;
    public string TextB;
    public DataLoot dataLootB;
    public Sprite lootB;
    public int countB;
}
