using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BaseItems;
using static PlayerStatic;

public class BuildBase : MonoBehaviour
{
    [SerializeField] private SceneController controller;
    [SerializeField] private Color disabledColor;

    private int nowPos = 0;

    void Start()
    {
        foreach (var build in BaseItems.building)
        {
            Transform buildTrans = controller.transform.GetChild(0).GetChild(1).Find(build.Key);
            
            for (int i = 0; i < transform.GetChild(0).childCount; i++)
            {
                Transform buildBtn = transform.GetChild(0).GetChild(i).GetChild(3).GetChild(1);
                BuildMethod buildMethod = transform.GetChild(0).GetChild(i).GetChild(3).GetComponent<BuildMethod>();

                if (buildMethod.nameBuild == build.Key)
                {
                    buildBtn.GetComponent<Image>().color = disabledColor;
                    buildBtn.GetComponent<Button>().enabled = false;
                    break;
                }
            }

            buildTrans.GetComponent<Animator>().enabled = false;
            buildTrans.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Transform panelResources = transform.GetChild(0).GetChild(i).GetChild(3).GetChild(0);
            BuildMethod buildMethod = transform.GetChild(0).GetChild(i).GetChild(3).GetComponent<BuildMethod>();
            int j = 0;
            Text countRes;

            foreach (var res in buildMethod.listRes)
            {
                countRes = panelResources.GetChild(j).GetChild(1).GetComponent<Text>();
                countRes.text = res.Value.ToString();
                j++;
            }

            if (panelResources.childCount > 0)
            {
                countRes = panelResources.GetChild(j).GetChild(1).GetComponent<Text>();
                countRes.text = buildMethod.price.ToString();
            }
        }
    }

    public void buy(Transform btn)
    {
        BuildMethod buildMethod = btn.parent.GetComponent<BuildMethod>();
        Dictionary<string, int> resPlr = new Dictionary<string, int>();

        foreach (var res in buildMethod.listRes)
        {
            if (BaseItems.items.ContainsKey(res.Key))
                resPlr[res.Key] = BaseItems.items[res.Key];
            else
                resPlr[res.Key] = 0;
        }

        if (buildMethod.Build(resPlr, PlayerStatic.money))
        {
            foreach (var res in resPlr)
                if (BaseItems.items.ContainsKey(res.Key))
                    BaseItems.items[res.Key] -= buildMethod.listRes[res.Key];

            PlayerStatic.money -= buildMethod.price;

            if (BaseItems.building.ContainsKey(buildMethod.nameBuild))
                BaseItems.building[buildMethod.nameBuild] += 1;
            else
                BaseItems.building[buildMethod.nameBuild] = 1;

            transform.parent.gameObject.SetActive(false);
            btn.GetComponent<Image>().color = disabledColor;
            btn.GetComponent<Button>().enabled = false;

            Transform build = controller.transform.GetChild(0).GetChild(1).Find(buildMethod.nameBuild);
            build.gameObject.SetActive(true);
        }
    }

    public void NextBuilds(Transform panel)
    {
        for (int i = 0; i < panel.childCount; i++)
        {
            if (i >= nowPos && i < nowPos + 4)
                panel.GetChild(i).gameObject.SetActive(true);
            else
                panel.GetChild(i).gameObject.SetActive(false);
        }

        if (nowPos + 4 == panel.childCount)
            nowPos = 0;
        else if (nowPos + 4 > panel.childCount)
            nowPos = panel.childCount - 4;
        else
            nowPos += 4;
    }

    public void PrevBuilds(Transform panel)
    {
        for (int i = panel.childCount - 1; i >= 0; i--)
        {
            if (i >= nowPos && i < nowPos + 4)
                panel.GetChild(i).gameObject.SetActive(true);
            else
                panel.GetChild(i).gameObject.SetActive(false);
        }

        if (nowPos - 4 < 0)
            nowPos = panel.childCount - 4;
        else
            nowPos -= 4;
    }
}
