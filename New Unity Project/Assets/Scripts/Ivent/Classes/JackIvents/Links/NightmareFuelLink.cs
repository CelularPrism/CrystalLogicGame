using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareFuelLink : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.ChangeHealth(-2);
        iventManager.SetAudioClip(dataIvent.audioTextA);
        iventManager.SetImage(dataIvent.lootA, (-2).ToString());
        iventManager.Final(dataIvent.localisationIvent.textA);
    }
    public void VarB()
    {
        iventManager.ChangeFuel(2);
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.SetImage(dataIvent.lootB, 2.ToString());
        iventManager.Final(dataIvent.localisationIvent.textB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Links/NightmareFuelLink");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
