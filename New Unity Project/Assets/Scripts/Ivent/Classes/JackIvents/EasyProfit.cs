using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyProfit : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.ChangeFuel(-1);
        iventManager.SetAudioClip(dataIvent.audioTextA);
        iventManager.SetImage(dataIvent.lootA, (-1).ToString());
        iventManager.Final(dataIvent.TextA);
    }
    public void VarB()
    {
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.Final(dataIvent.TextB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Jack Ivents/EasyProfit");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
