using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteriousContainerLink : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        return;
    }
    public void VarB()
    {
        return;
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Links/MysteriousContainerLink");
        if (iventManager.CheckRes(dataIvent.dataLootA.name, 1))
        {
            iventManager.SetAudioClip(dataIvent.audioTextA);
            iventManager.DeleteLoot(dataIvent.dataLootA.name, 1);
            iventManager.SetImage(dataIvent.dataLootA.img, (-1).ToString());
            iventManager.Final(dataIvent.localisationIvent.textA);
        }
        else
        {
            iventManager.SetAudioClip(dataIvent.audioTextB);
            iventManager.ChangeFuel(-1);
            iventManager.SetImage(dataIvent.lootB, (-1).ToString());
            iventManager.Final(dataIvent.localisationIvent.textB);
        }
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
