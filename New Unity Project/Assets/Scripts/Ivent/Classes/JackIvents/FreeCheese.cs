using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCheese : IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.SetAudioClip(dataIvent.audioTextA);
        iventManager.SetIvent(new FreeCheeseLink());
    }
    public void VarB()
    {
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.Final(dataIvent.TextB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Jack Ivents/FreeCheese");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
