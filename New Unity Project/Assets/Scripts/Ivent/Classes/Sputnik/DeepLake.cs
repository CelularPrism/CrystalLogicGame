using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepLake : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.SetAudioClip(dataIvent.audioTextA);
        if (iventManager.CheckRes(dataIvent.dataLootA.name, 1))
            iventManager.DeleteLoot(dataIvent.dataLootA.name, 1);
        iventManager.Final(dataIvent.TextA);
    }
    public void VarB()
    {
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.SetIvent(new DeepLakeLink());
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Sputnik/DeepLake");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
