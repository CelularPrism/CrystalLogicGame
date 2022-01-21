using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFarmNoHoul : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        DataLoot[] dataLoots = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");
        List<DataLoot> listData = new List<DataLoot>();
        int num = Random.Range(0, 100);

        if (num < 80) {
            foreach (DataLoot data in dataLoots)
                if (!data.equipment)
                    listData.Add(data);
        }
        else
        {
            foreach (DataLoot data in dataLoots)
                listData.Add(data);
        }

        num = Random.Range(0, listData.Count - 1);
        DataLoot dataLoot = listData[num];

        iventManager.SetAudioClip(dataIvent.audioTextA);
        iventManager.InsertLoot(dataLoot.name, 1);
        iventManager.SetImage(dataLoot.img, 1.ToString());
        iventManager.Final(dataIvent.TextA);
    }
    public void VarB()
    {
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.Final(dataIvent.TextB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Sputnik/NoFarmNoHoul");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
