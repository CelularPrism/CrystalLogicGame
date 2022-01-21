using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IventInterface
{
    public DataIvent dataIvent { get; set; }
    public IventManager iventManager { set; }
    public void VarA();
    public void VarB();

    public void StartIvent();

    public void SetIventManager(IventManager iventManager);
}
