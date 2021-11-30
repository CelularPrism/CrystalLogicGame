using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static PlayerStatic;
using static BaseItems;

public class LvlGeneration : MonoBehaviour
{
    [SerializeField] private Sprite lockImg;
    [SerializeField] private SceneController controller;
    [SerializeField] private GameObject panelInform;
    void Start()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;

        Vector2 nowPosLvl = transform.GetChild(indexScene - 1).position;
        Transform nowPosHold = transform.GetChild(transform.childCount - 1);

        nowPosHold.position = new Vector2(nowPosLvl.x, nowPosLvl.y + 15f);

        foreach (var i in PlayerStatic.countLvl)
        {
            //transform.GetChild(i - 1).GetComponent<Button>().enabled = false;
            transform.GetChild(i - 1).GetComponent<Image>().sprite = lockImg;
        }

        transform.GetChild(SceneManager.GetActiveScene().buildIndex - 1).GetComponent<Button>().enabled = false;
        transform.GetChild(SceneManager.GetActiveScene().buildIndex - 1).GetComponent<Image>().sprite = lockImg;
    }
    public void LoadNewLevel(int sceneIndex)
    {
        if (SceneManager.GetActiveScene().name != "Base")
        {
            PlayerStatic.countLvl.Add(SceneManager.GetActiveScene().buildIndex);

            if (!PlayerStatic.visitBase)
            {
                PlayerStatic.lootList = controller.lootList;
                PlayerStatic.fuel = controller.fuel;
                PlayerStatic.health = controller.health;
                PlayerStatic.iron = controller.iron;
                PlayerStatic.money = controller.money;
                PlayerStatic.damage = controller.damage;
            }

            PlayerStatic.visitBase = false;
        }
        SceneManager.LoadScene(sceneIndex);
    }

    public void Base()
    {
        foreach (var i in PlayerStatic.lootList)
        {
            if (!BaseItems.items.ContainsKey(i.Key))
                BaseItems.items[i.Key] = i.Value;
            else
                BaseItems.items[i.Key] += i.Value;
        }

        PlayerStatic.lootList = new Dictionary<string, int>();
        PlayerStatic.money = controller.money;
        PlayerStatic.fuel = 15;
        PlayerStatic.health = 15f;
        PlayerStatic.iron = 5f;

        PlayerStatic.visitBase = true;

        //panelInform.SetActive(true);
    }

}
