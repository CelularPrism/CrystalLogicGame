using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseItems;

public class BaseBuilding : MonoBehaviour
{
    private int countBuild;

    private void Start()
    {
        countBuild = BaseItems.building.Count;
        foreach (var build in BaseItems.building)
        {
            Transform buildTransform = transform.Find(build.Key);
            buildTransform.GetComponent<Animator>().enabled = false;
            buildTransform.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (BaseItems.building.Count > countBuild)
            foreach (var build in BaseItems.building)
            {
                Transform buildTransform = transform.Find(build.Key);
                buildTransform.gameObject.SetActive(true);
            }
    }
}
