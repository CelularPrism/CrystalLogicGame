using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMenTellNoLiesLink : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.SetAudioClip(dataIvent.audioTextA);
        iventManager.Final(dataIvent.localisationIvent.textA);
    }
    public void VarB()
    {
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.Final(dataIvent.localisationIvent.textB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Links/DeadMenTellNoLiesLink");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
