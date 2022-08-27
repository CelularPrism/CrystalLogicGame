using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Localisation", menuName = "Scriptable objects/Ivents/Localisation")]
public class DataLocalisationIvent : ScriptableObject
{
    [Header("Keys")]
    public string iventHeader;
    public string text;
    public string varA;
    public string textA;
    public string varB;
    public string textB;
}
