using System;
using UnityEngine;
using OneClickLocalization.Core;

[Serializable]
public class ChangeLocalization : ScriptableObject, ICloneable
{
    private LocalizationSetup localization;
    public void En()
    {
        //localization = LocalizationSetup.CreateInstance<LocalizationSetup>();
        //LocalizationSetup localization = new LocalizationSetup();
        //localization.SetDefaultLanguage(SystemLanguage.English);
    }

    public void Ru()
    {
        //localization.SetDefaultLanguage(SystemLanguage.Russian);
    }

    public object Clone()
    {
        throw new NotImplementedException();
    }
}
