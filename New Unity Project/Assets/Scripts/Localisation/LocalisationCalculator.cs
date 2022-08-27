using UnityEngine;
using System.Globalization;

class LocalisationCalculator : MonoBehaviour
{
    private void Start()
    {
        CultureInfo ci = CultureInfo.InstalledUICulture;
        if (ci.Name == "en-US")
        {
            LocalisationSystem.language = LocalisationSystem.Language.English;
        } else
        {
            LocalisationSystem.language = LocalisationSystem.Language.Russian;
        }
    }
}
