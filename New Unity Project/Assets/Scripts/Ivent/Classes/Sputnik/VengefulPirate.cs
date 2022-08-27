using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VengefulPirate : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.Battle();
        iventManager.SetAudioClip(dataIvent.audioTextA);
        iventManager.Final(dataIvent.localisationIvent.textA);
        // Начало боя
    }
    public void VarB()
    {
        iventManager.ChangeFuel(-3);
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.SetImage(dataIvent.lootB, (-3).ToString());
        iventManager.Final(dataIvent.localisationIvent.textB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Sputnik/VengefulPirate");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
