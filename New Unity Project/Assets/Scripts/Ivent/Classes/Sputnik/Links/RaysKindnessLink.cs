using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaysKindnessLink : IventInterface
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
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Links/RaysKindnessLink");
        if (iventManager.CheckRes(dataIvent.dataLootA.name, 1))
        {
            iventManager.SetAudioClip(dataIvent.audioTextA);
            iventManager.DeleteLoot(dataIvent.dataLootA.name, 1);
            iventManager.SetImage(dataIvent.lootA, (-1).ToString());
            iventManager.Final(dataIvent.TextA);
        }
        else
        {
            iventManager.SetAudioClip(dataIvent.audioTextB);
            iventManager.ChangeHealth(-5);
            iventManager.SetImage(dataIvent.lootB, (-5).ToString());
            iventManager.Final(dataIvent.TextB);
        }
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
