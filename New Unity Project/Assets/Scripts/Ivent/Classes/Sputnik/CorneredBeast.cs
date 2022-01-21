using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorneredBeast : IventInterface
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
        float iron = iventManager.GetIron();
        if (iron > 2)
            iventManager.ChangeIron(-2);
        else
        {
            iventManager.ChangeIron(-1);
            iventManager.ChangeHealth(-1);
        }

        iventManager.ChangeFuel(-2);
        iventManager.InsertLoot(dataIvent.dataLootB.name, 5);
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.SetImage(dataIvent.dataLootB.img, 5.ToString());
        iventManager.Final(dataIvent.TextB);
    }

    public void StartIvent()
    {
        dataIvent = Resources.Load<DataIvent>("ScriptableObjects/Ivents/Sputnik/CorneredBeast");
    }

    public void SetIventManager(IventManager iventManager)
    {
        this.iventManager = iventManager;
    }
}
