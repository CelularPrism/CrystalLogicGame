using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoundedGasGangerLink : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.Final(dataIvent.localisationIvent.textA);
    }
    public void VarB()
    {
        iventManager.Final(dataIvent.localisationIvent.textB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Links/WoundedGasGangerLink");
        if (iventManager.CheckRes(dataIvent.dataLootA.name, 1))
        {
            iventManager.SetAudioClip(dataIvent.audioTextA);
            iventManager.DeleteLoot(dataIvent.dataLootA.name, 1);
            iventManager.ChangeFuel(2);
            iventManager.SetImage(dataIvent.lootA, 2.ToString());
            iventManager.Final(dataIvent.localisationIvent.textA);
        }
        else
        {
            iventManager.SetAudioClip(dataIvent.audioTextB);
            iventManager.Final(dataIvent.localisationIvent.textB);
        }
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
