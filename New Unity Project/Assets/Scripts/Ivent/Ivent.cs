using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ivent : MonoBehaviour
{
    // Testing
    public GameObject Scene;
    [SerializeField] private Transform panelIvent;
    
    public DataIvent Ivents;
    public Sprite lootBox;
    private IventMethod iventMethod;

    public void Close(GameObject gameObject)
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        gameObject.SetActive(false);
        panelIvent.GetChild(3).gameObject.SetActive(true);
        panelIvent.GetChild(4).gameObject.SetActive(true);

        panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = lootBox;
        panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = "";
        panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = "";

        panelIvent.GetChild(6).gameObject.SetActive(false);

        GameObject audioSound = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0).gameObject;
        GameObject audioMusic = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(1).gameObject;
        
        AudioSource audioSource = audioMusic.GetComponent<AudioSource>();
        audioSource.volume = 1f;

        audioSource = audioSound.GetComponent<AudioSource>();
        audioSource.Stop();
    }

    public void VarA(GameObject gameObject)
    {
        SceneController controller = Scene.GetComponent<SceneController>();
        GameObject audioSound = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0).gameObject;
        AudioSource audioSource = audioSound.GetComponent<AudioSource>();

        if (Ivents.dataIventA != null)
        {
            audioSource.clip = Ivents.audioTextA;
            audioSource.Play();

            Ivents = Ivents.dataIventA;
            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.Text;
            panelIvent.GetChild(3).GetChild(0).GetComponent<Text>().text = Ivents.VarA;
            panelIvent.GetChild(4).GetChild(0).GetComponent<Text>().text = Ivents.VarB;
            if (Ivents.name == "WoundedGasGangerLink")
            {
                if (controller.lootList.ContainsKey(Ivents.dataLootA.name))
                {
                    controller.lootList[Ivents.dataLootA.name] += Ivents.countA;
                    controller.fuel += 2;

                    panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextA;

                    panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = Ivents.dataLootA.img;
                    panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = Ivents.dataLootA.Name;
                    panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = Ivents.countA.ToString();
                    audioSource.clip = Ivents.audioTextA;
                    audioSource.Play();
                }
                else
                {
                    panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextB;
                    audioSource.clip = Ivents.audioTextB;
                    audioSource.Play();
                }

                panelIvent.GetChild(3).GetChild(0).gameObject.SetActive(false);
                panelIvent.GetChild(4).GetChild(0).gameObject.SetActive(false);
                panelIvent.GetChild(6).gameObject.SetActive(true);
            }

        }
        else if (Ivents.name == "EasyProfit" || Ivents.name == "Silhouettes" || Ivents.name == "FreeCheeseLink")
        {
            controller.fuel -= 1;
            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextA;
            panelIvent.GetChild(3).gameObject.SetActive(false);
            panelIvent.GetChild(4).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);
            audioSource.clip = Ivents.audioTextA;
            audioSource.Play();
        } 
        else if (Ivents.name == "EasyMetal" || Ivents.name == "FirstComeFirstServe" || Ivents.name == "NightmareFuelLink")
        {
            controller.health -= 2;
            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextA;
            panelIvent.GetChild(3).gameObject.SetActive(false);
            panelIvent.GetChild(4).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);
            audioSource.clip = Ivents.audioTextA;
            audioSource.Play();
        }
        else if (Ivents.name == "DeepLake")
        {
            if (controller.lootList.ContainsKey(Ivents.dataLootA.name))
            {
                controller.lootList[Ivents.dataLootA.name] -= 1;

                panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = Ivents.dataLootA.img;
                panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = Ivents.dataLootA.Name;
                panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = "-1";
            }

            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextA;
            panelIvent.GetChild(3).gameObject.SetActive(false);
            panelIvent.GetChild(4).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);

            audioSource.clip = Ivents.audioTextA;
            audioSource.Play();
        }
        else if (Ivents.name == "DeepLakeLink")
        {
            controller.fuel += 1;
            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextA;
            panelIvent.GetChild(3).gameObject.SetActive(false);
            panelIvent.GetChild(4).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);

            audioSource.clip = Ivents.audioTextA;
            audioSource.Play();
        }
        else if (Ivents.name == "NoFarmNoHoul")
        {
            DataLoot[] listLoot = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");
            DataLoot dataLoot = listLoot[Random.Range(0, listLoot.Length)];

            while (dataLoot.equipment)
                dataLoot = listLoot[Random.Range(0, listLoot.Length)];

            if (controller.lootList.ContainsKey(dataLoot.name))
                controller.lootList[dataLoot.name] += 1;
            else
                controller.lootList[dataLoot.name] = 1;

            panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = dataLoot.img;
            panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = dataLoot.Name;
            panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = "1";

            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextA;
            panelIvent.GetChild(3).gameObject.SetActive(false);
            panelIvent.GetChild(4).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);

            audioSource.clip = Ivents.audioTextA;
            audioSource.Play();
        }
        else if (Ivents.name == "NoFarmNoHoul")
        {

        }
        else if (Ivents.dataLootA != null)
        {
            iventMethod = new IventMethod();
            iventMethod.SubtractionResources(controller, Ivents.dataLootA, Ivents.countA);

            panelIvent.GetChild(3).GetChild(0).gameObject.SetActive(false);
            panelIvent.GetChild(4).GetChild(0).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);
        }
        else
        {
            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextA;
            panelIvent.GetChild(3).gameObject.SetActive(false);
            panelIvent.GetChild(4).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);

            audioSource.clip = Ivents.audioTextA;
            audioSource.Play();
        }

        #region oldMethod
        /*panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextA;
        if (Ivents.dataLootA != null)
        {
            panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = Ivents.dataLootA.img;
            panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = Ivents.dataLootA.Name;
            panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = Ivents.countA.ToString();

            if (!Scene.GetComponent<SceneController>().lootList.ContainsKey(Ivents.dataLootA.name))
                Scene.GetComponent<SceneController>().lootList[Ivents.dataLootA.name] = Ivents.countA;
            else
                Scene.GetComponent<SceneController>().lootList[Ivents.dataLootA.name] += Ivents.countA;

        } else if (Ivents.name == "Dinner" || Ivents.name == "EasyNavar" || Ivents.name == "Wanderers")
        {
            Scene.GetComponent<SceneController>().fuel -= 2;
        } else if (Ivents.name == "Precious" || Ivents.name == "TaleTraveler" || Ivents.name == "ThornyPath")
        {
            for (int i = 0; i < 2; i++)
            {
                if (Scene.GetComponent<SceneController>().iron > 0)
                    Scene.GetComponent<SceneController>().iron -= 1;
                else
                    Scene.GetComponent<SceneController>().health -= 1;
            }
        }

        panelIvent.GetChild(3).gameObject.SetActive(false);
        panelIvent.GetChild(4).gameObject.SetActive(false);

        panelIvent.GetChild(6).gameObject.SetActive(true);*/
        #endregion
    }

    public void VarB(GameObject gameObject)
    {

        SceneController controller = Scene.GetComponent<SceneController>();
        GameObject audioSound = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0).gameObject;
        AudioSource audioSource = audioSound.GetComponent<AudioSource>();

        if (Ivents.dataIventB != null)
        {
            audioSource.clip = Ivents.audioTextB;
            audioSource.Play();

            Ivents = Ivents.dataIventB;
            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.Text;
            panelIvent.GetChild(3).GetChild(0).GetComponent<Text>().text = Ivents.VarA;
            panelIvent.GetChild(4).GetChild(0).GetComponent<Text>().text = Ivents.VarB;

            if (Ivents.name == "MysteriousContainerLink")
            {
                if (controller.lootList.ContainsKey(Ivents.dataLootB.name))
                {
                    controller.lootList[Ivents.dataLootB.name] += Ivents.countB;

                    panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextB;

                    panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = Ivents.dataLootB.img;
                    panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = Ivents.dataLootB.Name;
                    panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = Ivents.countB.ToString();

                    audioSource.clip = Ivents.audioTextB;
                    audioSource.Play();
                }
                else
                {
                    controller.fuel -= 1;
                    panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextA;

                    audioSource.clip = Ivents.audioTextA;
                    audioSource.Play();
                }

                panelIvent.GetChild(3).GetChild(0).gameObject.SetActive(false);
                panelIvent.GetChild(4).GetChild(0).gameObject.SetActive(false);
                panelIvent.GetChild(6).gameObject.SetActive(true);
            }

            if (Ivents.name == "RaysKindnessLink")
            {
                if (controller.lootList.ContainsKey(Ivents.dataLootB.name))
                {
                    controller.lootList[Ivents.dataLootB.name] += Ivents.countB;

                    panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextB;

                    panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = Ivents.dataLootB.img;
                    panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = Ivents.dataLootB.Name;
                    panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = Ivents.countB.ToString();

                    audioSource.clip = Ivents.audioTextB;
                    audioSource.Play();
                }
                else
                {
                    controller.health -= 5;
                    panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextA;

                    audioSource.clip = Ivents.audioTextA;
                    audioSource.Play();
                }

                panelIvent.GetChild(3).gameObject.SetActive(false);
                panelIvent.GetChild(4).gameObject.SetActive(false);
                panelIvent.GetChild(6).gameObject.SetActive(true);
            }

        }
        else if (Ivents.name == "CorneredBeast")
        {
            controller.health -= 2;
            controller.fuel -= 5;

            if (controller.lootList.ContainsKey(Ivents.dataLootB.name))
            {
                controller.lootList[Ivents.dataLootB.name] += 5;
            }
            else
            {
                controller.lootList[Ivents.dataLootB.name] = 5;
            }

            panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = Ivents.dataLootB.img;
            panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = Ivents.dataLootB.Name;
            panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = "5";

            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextB;
            panelIvent.GetChild(3).gameObject.SetActive(false);
            panelIvent.GetChild(4).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);

            audioSource.clip = Ivents.audioTextB;
            audioSource.Play();
        }
        else if (Ivents.name == "VengefulPirate")
        {
            controller.fuel -= 3;

            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextB;
            panelIvent.GetChild(3).gameObject.SetActive(false);
            panelIvent.GetChild(4).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);

            audioSource.clip = Ivents.audioTextB;
            audioSource.Play();
        }
        else if (Ivents.name == "Vultures")
        {
            controller.fuel += 1;

            DataLoot[] listLoot = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");
            DataLoot dataLoot = listLoot[Random.Range(0, listLoot.Length)];

            while (dataLoot.equipment)
                dataLoot = listLoot[Random.Range(0, listLoot.Length)];

            if (controller.lootList.ContainsKey(dataLoot.name))
                controller.lootList[dataLoot.name] += 1;
            else
                controller.lootList[dataLoot.name] = 1;

            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextB;
            panelIvent.GetChild(3).gameObject.SetActive(false);
            panelIvent.GetChild(4).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);

            panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = dataLoot.img;
            panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = dataLoot.Name;
            panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = "1";

            audioSource.clip = Ivents.audioTextB;
            audioSource.Play();
        }
        else if (Ivents.name == "NightmareFuelLink")
        {
            controller.fuel += 2;
            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextB;
            panelIvent.GetChild(3).gameObject.SetActive(false);
            panelIvent.GetChild(4).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);

            audioSource.clip = Ivents.audioTextB;
            audioSource.Play();
        }
        else if (Ivents.dataLootB != null)
        {
            iventMethod = new IventMethod();
            iventMethod.SubtractionResources(controller, Ivents.dataLootB, Ivents.countB);

            panelIvent.GetChild(3).GetChild(0).gameObject.SetActive(false);
            panelIvent.GetChild(4).GetChild(0).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);
        }
        else
        {
            panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextB;
            panelIvent.GetChild(3).gameObject.SetActive(false);
            panelIvent.GetChild(4).gameObject.SetActive(false);
            panelIvent.GetChild(6).gameObject.SetActive(true);

            audioSource.clip = Ivents.audioTextB;
            audioSource.Play();
        }

        #region oldMethod
        /* //DataIvent thisEvent = Scene.GetComponentInChildren<Search>().GetComponent<DataIvent>();
         panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextB;
         if (Ivents.dataLootB != null)
         {
             panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = Ivents.dataLootB.img;
             panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = Ivents.dataLootB.Name;
             panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = Ivents.countB.ToString();

             if (!Scene.GetComponent<SceneController>().lootList.ContainsKey(Ivents.dataLootB.name)) 
                 Scene.GetComponent<SceneController>().lootList[Ivents.dataLootB.name] = Ivents.countB;
             else
                 Scene.GetComponent<SceneController>().lootList[Ivents.dataLootB.name] += Ivents.countB;

             if (Ivents.name == "Wanderers")
             {
                 Scene.GetComponent<SceneController>().fuel -= 1;
             }
         } else if (Ivents.name == "DeathLuck" || Ivents.name == "ThornyPath")
         {
             Scene.GetComponent<SceneController>().fuel += 2;
         } else if (Ivents.name == "Silhouettes")
         {
             Scene.GetComponent<SceneController>().fuel -= 2;
         }

         panelIvent.GetChild(3).gameObject.SetActive(false);
         panelIvent.GetChild(4).gameObject.SetActive(false);

         panelIvent.GetChild(6).gameObject.SetActive(true);*/
        #endregion
    }
}
