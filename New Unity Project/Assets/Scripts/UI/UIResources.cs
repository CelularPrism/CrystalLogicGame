using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BaseItems;
using static PlayerStatic;

public class UIResources : MonoBehaviour
{
    void Update()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            int obj = 0;
            if (BaseItems.items.ContainsKey(transform.GetChild(i).name))
                obj = BaseItems.items[transform.GetChild(i).name];
            Text text = transform.GetChild(i).GetChild(1).GetComponent<Text>();
            text.text = obj.ToString();
        }

        transform.GetChild(transform.childCount - 1).GetChild(1).GetComponent<Text>().text = PlayerStatic.money.ToString();
    }
}
