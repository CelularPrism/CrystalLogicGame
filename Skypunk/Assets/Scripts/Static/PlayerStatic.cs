using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStatic
{
    public static string lang = "";
    public static Dictionary<string, int> lootList = new Dictionary<string, int>();
    public static List<int> countLvl = new List<int>();

    public static int fuel = 15;
    public static float health = 15f;
    public static float iron = 5f;

    public static bool visitBase = false;
}
