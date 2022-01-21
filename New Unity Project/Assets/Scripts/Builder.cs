using System;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    private enum num { Enemy, Fuel, Search, Magazine };
    private Vector2 center = new Vector2(-1.71f, -0.5f);

    [SerializeField] private Transform floors;

    [SerializeField] private Transform courier;
    [SerializeField] private Transform panelWarning;
    [SerializeField] private UIManager panelLoot;
    [SerializeField] private PanelLoot loot;

    [SerializeField] private Transform panelIvent;
    [SerializeField] private GameObject search;

    bool first = true;

    void Start()
    {
        int floorsCount = UnityEngine.Random.Range(9, 16);
        
        for (int i = 1; i <= floorsCount + 1; i++)
        {
            
            GameObject gameObject = new GameObject("Floor " + i.ToString());
            gameObject.transform.SetParent(floors);
            gameObject.transform.localPosition = new Vector3(0f, center.y);
            gameObject.transform.localScale = Vector3.one;
            
            //Instantiate(gameObject);

            if (i == 1)
                gameObject.layer = 6;

            /*if (i % (floorsCount / 2 + 1) == 0 && i < floorsCount - 3)
            {
                BuildCourier(center, gameObject);
                center = new Vector2(center.x, center.y + 6f);
                continue;
            }*/

            if (i % (floorsCount / 2 + 1) == 0 && i < floorsCount - 3)
            {
                string classcard = num.Magazine.ToString();
                Build(center, gameObject, classcard, i);
                center = new Vector2(center.x, center.y + 6f);
                continue;
            }
                

            if (i == floorsCount + 1)
            {
                GameObject lastLevel = Resources.Load<GameObject>("Prefabs/LastFloor/LastFloor") as GameObject;
                Instantiate(lastLevel, gameObject.transform.TransformPoint(new Vector3(-1.71f, 0f)), Quaternion.identity, gameObject.transform);
                break;
            }

            for (int j = -1; j <= 1; j++)
            {
                center = new Vector2(-1.71f + 7.89f * j, center.y);
                int probability = UnityEngine.Random.Range(0, 100);
                string classCard = "";

                if (probability < 50)
                    classCard = num.Search.ToString();
                else if (probability < 75)
                    classCard = num.Enemy.ToString();
                else
                    classCard = num.Fuel.ToString();

                Build(center, gameObject, classCard, i);
            }

            center = new Vector2(-1.71f, center.y + 6f);
            
        }
    }

    void Build(Vector2 pos, GameObject parent, string typeChild, int num)
    {
        GameObject enemy = Resources.Load<GameObject>("Prefabs/" + typeChild + "/" + typeChild) as GameObject;

        DataCard[] listData = Resources.LoadAll<DataCard>("ScriptableObjects/Cards/" + typeChild);
        DataCard dataCard = listData[UnityEngine.Random.Range(0, listData.Length - 1)];

        enemy.GetComponent<Card>().dataCard = dataCard;
        enemy.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = dataCard.img;

        if (typeChild == "Search")
        {
            DataIvent[] listIvent = Resources.LoadAll<DataIvent>("ScriptableObjects/Ivents");
            int random = UnityEngine.Random.Range(0, listIvent.Length - 1);
            enemy.GetComponent<Card>().Ivent = listIvent[random];
            enemy.GetComponent<Card>().panelIvent = panelIvent;
            enemy.GetComponent<Card>().search = search;
        }

        if (num == 1)
            enemy.layer = 6;
        else
            enemy.layer = 0;

        Instantiate(enemy, parent.transform.TransformPoint(new Vector3(pos.x, 0f)), Quaternion.identity, parent.transform);
    }

    void BuildCourier(Vector2 pos, GameObject parent)
    {
        GameObject enemy = Resources.Load<GameObject>("Prefabs/Courier/Courier");

        enemy.GetComponent<Courier>().loot = loot;
        enemy.GetComponent<Courier>().panelWarning = panelWarning;
        enemy.GetComponent<Courier>().panelCourier = courier;
        enemy.GetComponent<Courier>().panelLoot = panelLoot;

        Instantiate(enemy, parent.transform.TransformPoint(new Vector3(pos.x, 0f)), Quaternion.identity, parent.transform);
    }
}
