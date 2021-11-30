using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerStatic;

public class Sliders : MonoBehaviour
{
    [SerializeField] GameObject gameOver;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            GameObject.FindGameObjectsWithTag("Slide")[GameObject.FindGameObjectsWithTag("Slide").Length - 1].SetActive(false);

            if (GameObject.FindGameObjectsWithTag("Slide").Length == 0 && PlayerStatic.countLvl.Count < 5)
            {
                transform.parent.gameObject.SetActive(false);
            } else if (GameObject.FindGameObjectsWithTag("Slide").Length == 0)
            {
                transform.parent.gameObject.SetActive(false);
                gameOver.SetActive(true);
            }
        }
    }
}
