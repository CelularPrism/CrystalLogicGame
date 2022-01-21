using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteriousContainer : IventInterface // Отредактировать. Сложен в реализации
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { get; set; }
    public void VarA()
    {
        iventManager.SetAudioClip(dataIvent.audioTextA);
        iventManager.Final(dataIvent.TextA);
    }
    public void VarB()
    {
        iventManager.SetIvent(new MysteriousContainerLink());
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Sputnik/MysteriousContainer");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
