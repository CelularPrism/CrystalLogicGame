using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCheeseLink : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.ChangeFuel(-1);
        iventManager.SetImage(dataIvent.lootA, (-1).ToString());
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
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Links/FreeCheeseLink");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
