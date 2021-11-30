using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseItems;

public class BaseBuilding : MonoBehaviour
{
    void Update()
    {
        foreach (var build in BaseItems.building)
        {
            Transform buildTransform = transform.Find(build.Key);
            buildTransform.gameObject.SetActive(true);
        }
    }
}
