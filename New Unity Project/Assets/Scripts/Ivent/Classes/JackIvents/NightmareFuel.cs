using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareFuel : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.SetAudioClip(dataIvent.audioTextA);
        iventManager.SetIvent(new NightmareFuelLink());
    }
    public void VarB()
    {
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.Final(dataIvent.localisationIvent.textB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Jack Ivents/NightmareFuel");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
