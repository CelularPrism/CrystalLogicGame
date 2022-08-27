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
        iventManager.Final(dataIvent.localisationIvent.textA);
    }
    public void VarB()
    {
        float iron = iventManager.GetIron();
        int dmgHealth = 0;
        int dmgIron = 2;
        while (iron < dmgIron) {
            dmgIron--;
            dmgHealth++;
        }

        iventManager.ChangeIron(dmgIron);
        iventManager.ChangeHealth(dmgHealth);

        iventManager.ChangeFuel(-2);
        iventManager.InsertLoot(dataIvent.dataLootB.name, 5);
        iventManager.SetAudioClip(dataIvent.audioTextB);
        iventManager.SetImage(dataIvent.dataLootB.img, 5.ToString());
        iventManager.Final(dataIvent.localisationIvent.textB);
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
