using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PlayerStatic;

public class UIButtons : MonoBehaviour
{
    [SerializeField] private Transform panelMap;
    [SerializeField] private Transform panelOption;
    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        PlayerStatic.lootList = new Dictionary<string, int>();
        PlayerStatic.countLvl = new List<int>();

        PlayerStatic.fuel = 15;
        PlayerStatic.health = 15f;
        PlayerStatic.iron = 5f;
        PlayerStatic.damage = 3;

        SceneManager.LoadScene("1");
    }

    public void OpenMap()
    {
        panelMap.parent.gameObject.SetActive(true);
        panelOption.gameObject.SetActive(false);
        panelMap.gameObject.SetActive(true);
    }

    public void OpenOption()
    {
        if (panelOption.gameObject.activeSelf)
        {
            panelOption.gameObject.SetActive(false);
        }
        else
        {
            panelOption.parent.gameObject.SetActive(true);
            panelOption.gameObject.SetActive(true);
            if (panelMap != null)
                panelMap.gameObject.SetActive(false);
        }
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(Transform child)
    {
        child.parent.gameObject.SetActive(false);
    }
}
