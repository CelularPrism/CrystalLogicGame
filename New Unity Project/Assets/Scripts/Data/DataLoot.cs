using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Loot", menuName = "Scriptable objects/Loot")]
public class DataLoot : ScriptableObject
{
    public bool equipment;
    public enum classLoot { weapon, shield, equipment };
    public classLoot lootClass;

    public Sprite img;
    public AudioClip audio;
    public string Name;
    public string Description;
    public int price;

    public int boostHealth = 0;
    public int boostIron = 0;
    public int boostDamage = 0;
    public int boostOil = 1;

}
