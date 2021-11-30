using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightEffects : MonoBehaviour
{
    public Transform panel;
    public void AimShield()
    {
        panel.GetChild(2).gameObject.SetActive(true);
    }

    public void Aim()
    {
        panel.GetChild(3).gameObject.SetActive(true);
    }

    public void Destroy()
    {
        panel.GetChild(2).gameObject.SetActive(false);
        panel.GetChild(3).gameObject.SetActive(false);
        panel.parent.parent.GetChild(0).gameObject.SetActive(false);
        panel.parent.parent.GetChild(1).gameObject.SetActive(false);
    }

    public void Damage(int health, int iron)
    {
        if (health > 0)
        {
            panel.parent.parent.GetChild(0).GetChild(0).GetComponent<Text>().text = "-" + health.ToString();
            panel.parent.parent.GetChild(0).gameObject.SetActive(true);
        }

        if (iron > 0)
        {
            panel.parent.parent.GetChild(1).GetChild(0).GetComponent<Text>().text = "-" + iron.ToString();
            panel.parent.parent.GetChild(1).gameObject.SetActive(true);
        }
    }
}
