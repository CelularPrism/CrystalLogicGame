using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStatic
{
    public static string lang = "";
    public static List<IventInterface> listIvents = new List<IventInterface>();
    public static Dictionary<string, int> lootList = new Dictionary<string, int>();
    public static Dictionary<string, DataLoot> equipmentList = new Dictionary<string, DataLoot>() {   { "weapon", null },
                                                                                            { "shield", null },
                                                                                            { "equip1", null },
                                                                                            { "equip2", null } };
    public static List<int> countLvl = new List<int>();

    public static float fuel = 15;
    public static int money = 100;
    public static int damage = 3;
    public static float health = 15f;
    public static float iron = 5f;

    public static bool visitBase = false;
}
