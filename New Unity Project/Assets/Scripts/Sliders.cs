using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerStatic;

public class Sliders : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] AudioSource audioMusic;

    public void CloseSlide(GameObject gameObject)
    {

        if (gameObject.transform.GetSiblingIndex() == 0 && PlayerStatic.countLvl.Count == 4)
        {
            gameObject.transform.parent.parent.gameObject.SetActive(false);
            gameOver.transform.gameObject.SetActive(true);
        } else if (gameObject.transform.GetSiblingIndex() == 0)
        {
            gameObject.transform.parent.parent.gameObject.SetActive(false);
            audioMusic.Play();
        } else
        {
            gameObject.SetActive(false);
            gameObject.transform.parent.GetChild(gameObject.transform.GetSiblingIndex() - 1).gameObject.SetActive(true);
        }
    }
}
