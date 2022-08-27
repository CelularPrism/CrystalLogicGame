using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaysKindness : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.Battle();
        iventManager.SetAudioClip(dataIvent.audioTextA);
        iventManager.Final(dataIvent.localisationIvent.textA);
    }
    public void VarB()
    {
        iventManager.SetIvent(new RaysKindnessLink());
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Sputnik/RaysKindness");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
