using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventMethod : MonoBehaviour
{
    public void SubtractionResources(SceneController controller, DataLoot dataLoot, int count)
    {
        if (dataLoot != null)
        {
            if (!controller.lootList.ContainsKey(dataLoot.name))
                controller.lootList[dataLoot.name] = count;
            else
                controller.lootList[dataLoot.name] += count;
        }
    }

    public void SubtractionFuel(SceneController controller, DataLoot dataLoot, int count)
    {
        
    }

    public void SubtractionHealth(SceneController controller, DataLoot dataLoot, int count)
    {
        if (dataLoot != null)
        {
            if (!controller.lootList.ContainsKey(dataLoot.name))
                controller.lootList[dataLoot.name] = count;
            else
                controller.lootList[dataLoot.name] += count;
        }
    }
}
