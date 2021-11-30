using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ivent", menuName = "Scriptable objects/Ivent")]
public class DataIvent : ScriptableObject
{
    public AudioClip audioText;
    public string TextHeader;
    public string Text;

    public AudioClip audioTextA;
    public string VarA;
    public string TextA;
    public DataIvent dataIventA;
    public DataLoot dataLootA;
    public int countA;

    public AudioClip audioTextB;
    public string VarB;
    public string TextB;
    public DataIvent dataIventB;
    public DataLoot dataLootB;
    public int countB;
}
