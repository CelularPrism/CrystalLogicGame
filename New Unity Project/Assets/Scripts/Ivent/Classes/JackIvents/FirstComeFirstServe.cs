using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstComeFirstServe : IventInterface
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
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.Final(dataIvent.localisationIvent.textB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Jack Ivents/FirstComeFirstServe");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
