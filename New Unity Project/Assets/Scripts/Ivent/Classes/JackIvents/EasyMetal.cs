using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMetal : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.ChangeHealth(-2);
        iventManager.SetAudioClip(dataIvent.audioTextA);
        iventManager.SetImage(dataIvent.lootA, (-2).ToString());
        iventManager.Final(dataIvent.TextA);
    }

    public void VarB()
    {
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.Final(dataIvent.TextB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Jack Ivents/EasyMetal");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}