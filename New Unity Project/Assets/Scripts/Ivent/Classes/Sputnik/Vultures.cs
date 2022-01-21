using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vultures : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.SetAudioClip(dataIvent.audioTextA);
        iventManager.Final(dataIvent.TextA);
    }
    public void VarB()
    {
        DataLoot[] dataLoots = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");
        List<DataLoot> listLoot = new List<DataLoot>();
        int num = Random.Range(0, 100);

        if (num < 80)
        {
            foreach (DataLoot data in dataLoots)
                if (!data.equipment)
                    listLoot.Add(data);
        }
        else
        {
            foreach (DataLoot data in dataLoots)
                listLoot.Add(data);
        }

        num = Random.Range(0, listLoot.Count - 1);
        DataLoot dataLoot = listLoot[num];

        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.InsertLoot(dataLoot.name, 1);
        iventManager.ChangeFuel(1);
        iventManager.SetImage(dataLoot.img, 1.ToString());
        iventManager.Final(dataIvent.TextB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Sputnik/Vultures");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
