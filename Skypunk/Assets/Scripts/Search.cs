using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Search : MonoBehaviour
{
    private float speedA = 51f;

    private float i = 0f;

    private Image imgHold;
    private Image imgHoldBG;

    private bool closePanel = false;
    private bool search = false;

    [SerializeField] private List<Sprite> dictImg = new List<Sprite>(4);
    //[SerializeField] private List<DataLoot> listLoot;
    [SerializeField] private Transform lootPanel;
    [SerializeField] private Transform imgPanel;
    [SerializeField] private SceneController controller;
    [SerializeField] private Image btn;
    

    private void Start()
    {
        imgHoldBG = imgPanel.GetChild(0).GetComponent<Image>();
        imgHold = imgPanel.GetChild(1).GetComponent<Image>();
    }

    public void Restart()
    {
        imgPanel.gameObject.SetActive(true);
        imgPanel.GetChild(0).gameObject.SetActive(true);
        imgPanel.GetChild(1).gameObject.SetActive(true);

        imgHoldBG = imgPanel.GetChild(0).GetComponent<Image>();
        imgHold = imgPanel.GetChild(1).GetComponent<Image>();

        imgHold.fillAmount = 1;
        imgHold.color = new Color(imgHold.color.r, imgHold.color.g, imgHold.color.b, 255);
        imgHoldBG.color = new Color(imgHoldBG.color.r, imgHoldBG.color.g, imgHoldBG.color.b, 255);
        
        btn.sprite = dictImg[3];
        search = false;
        closePanel = false;

        foreach (Transform i in lootPanel)
        {
            i.GetChild(0).GetComponent<Image>().sprite = dictImg[1];
            i.GetChild(1).GetComponent<Text>().text = "";
            i.GetChild(2).GetComponent<Text>().text = "";
        }
    }

    public void ClosePanel(Transform child)
    {
        if (closePanel)
            child.parent.gameObject.SetActive(false);
    }

    public void OnPointerDown()
    {
        search = true;
    }

    public void OnPointerUp()
    {
        if (imgHold.fillAmount == 0 && !closePanel)
        {
            imgHold.gameObject.SetActive(false);
            imgHoldBG.gameObject.SetActive(false);
            btn.sprite = dictImg[2];
            search = true;
            Looting();
        }
        else
        {
            search = false;
        }
    }

    private void FixedUpdate()
    {
        if (search && imgHold.fillAmount > 0)
        {
            imgHold.fillAmount -= speedA * Time.deltaTime * Time.deltaTime / 2f;
        }
        else if (!search && imgHold.fillAmount > 0)
        {
            imgHold.fillAmount += speedA * Time.deltaTime * Time.deltaTime / 2f;
        } else if (imgHold.fillAmount == 0)
        {
            imgHoldBG.color = new Color(imgHoldBG.color.r, imgHoldBG.color.g, imgHoldBG.color.b, imgHoldBG.color.a - speedA * Time.deltaTime * Time.deltaTime / 2f);
        }
    }

    private void Looting()
    {
        int countLoot = Random.Range(0, 4);
        closePanel = true;
        for (int i = 0; i < 4; i++)
        {
            Transform panel = lootPanel.GetChild(i);
            if (i < countLoot) {
                DataLoot[] listLoot = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");
                DataLoot dataLoot = listLoot[Random.Range(0, listLoot.Length)];

                int kolvo = Random.Range(1, 3);

                panel.GetChild(0).GetComponent<Image>().sprite = dataLoot.img;
                panel.GetChild(1).GetComponent<Text>().text = dataLoot.Name;
                panel.GetChild(2).GetComponent<Text>().text = kolvo.ToString();


                if (!controller.lootList.ContainsKey(dataLoot.name))
                {
                    controller.lootList.Add(dataLoot.name, kolvo);
                }
                else
                {
                    controller.lootList[dataLoot.name] += kolvo;
                }
            } else
            {
                panel.GetChild(0).GetComponent<Image>().sprite = dictImg[0];
            }

        }
    }
}
