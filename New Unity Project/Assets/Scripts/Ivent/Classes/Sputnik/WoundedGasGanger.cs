using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoundedGasGanger : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.SetIvent(new WoundedGasGangerLink());
    }
    public void VarB()
    {
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.Final(dataIvent.localisationIvent.textB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Sputnik/WoundedGasGanger");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
