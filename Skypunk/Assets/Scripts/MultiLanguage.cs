using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization;
using static PlayerStatic;

public class MultiLanguage : MonoBehaviour
{
    [SerializeField] private Color activeColor;
    [SerializeField] private Color nonActiveColor;

    [SerializeField] private GameObject ruBtn;
    [SerializeField] private GameObject enBtn;

    public Text[] textToTranslate;
    public DataLoot[] DataLootToTranslate;
    public DataIvent[] DataIventToTranslate;
    private void Start()
    {
        if (PlayerStatic.lang == "")
        {
            switch (Application.systemLanguage)
            {
                case SystemLanguage.English:
                    PlayerStatic.lang = "English";
                    break;

                case SystemLanguage.Russian:
                    PlayerStatic.lang = "Russian";
                    break;
            }
        }

        switch (PlayerStatic.lang)
        {
            case "English":
                Language("English");
                enBtn.GetComponent<Image>().color = activeColor;
                ruBtn.GetComponent<Image>().color = nonActiveColor;
                break;
            case "Russian":
                Language("Russian");
                enBtn.GetComponent<Image>().color = nonActiveColor;
                ruBtn.GetComponent<Image>().color = activeColor;
                break;
        }
    }

    public void Language(string language)
    {

        switch (language)
        {
            case "English":
                PlayerStatic.lang = "English";
                enBtn.GetComponent<Image>().color = activeColor;
                ruBtn.GetComponent<Image>().color = nonActiveColor;
                break;

            case "Russian":
                PlayerStatic.lang = "Russian";
                enBtn.GetComponent<Image>().color = nonActiveColor;
                ruBtn.GetComponent<Image>().color = activeColor;
                break;

        }

        LocalizationManager.Language = language;

        // Panel-PanelOption
        //textToTranslate[0].text = LocalizationManager.Localize("RuBtn");
        //textToTranslate[1].text = LocalizationManager.Localize("EnBtn");
        textToTranslate[0].text = LocalizationManager.Localize("OptMusic");
        textToTranslate[1].text = LocalizationManager.Localize("OptFX");
        textToTranslate[2].text = LocalizationManager.Localize("OptSound");
        textToTranslate[3].text = LocalizationManager.Localize("OptLanguage");

        // Panel-PanelButtons
        textToTranslate[4].text = LocalizationManager.Localize("OptExit");
        textToTranslate[5].text = LocalizationManager.Localize("OptOptions");
        textToTranslate[6].text = LocalizationManager.Localize("OptLoadGame");
        textToTranslate[7].text = LocalizationManager.Localize("OptNewGame");

        // GUI-left-ButtonList
        textToTranslate[8].text = LocalizationManager.Localize("MenuExit");
        textToTranslate[9].text = LocalizationManager.Localize("MenuOptions");
        textToTranslate[10].text = LocalizationManager.Localize("MenuRestart");

        // Search
        textToTranslate[11].text = LocalizationManager.Localize("Searching");
        textToTranslate[12].text = LocalizationManager.Localize("SearchHold");
        textToTranslate[13].text = LocalizationManager.Localize("SearchHeader");

        // Courier & Cargo hold
        textToTranslate[14].text = LocalizationManager.Localize("CourCourier");
        textToTranslate[15].text = LocalizationManager.Localize("CourSend");
        textToTranslate[16].text = LocalizationManager.Localize("CourCargoHold");
        textToTranslate[17].text = LocalizationManager.Localize("ShipHold");
        textToTranslate[18].text = LocalizationManager.Localize("ShipDrop");

        // FightField
        textToTranslate[19].text = LocalizationManager.Localize("PanelAcceptHeader");
        textToTranslate[20].text = LocalizationManager.Localize("PanelAcceptText");
        textToTranslate[21].text = LocalizationManager.Localize("PanelInfoPhase1");
        textToTranslate[22].text = LocalizationManager.Localize("PanelInfoPhase2");
        textToTranslate[23].text = LocalizationManager.Localize("PanelInfoPhase3");
        textToTranslate[24].text = LocalizationManager.Localize("PanelInfoPhase4");
        textToTranslate[25].text = LocalizationManager.Localize("PanelInputInfo1");
        textToTranslate[26].text = LocalizationManager.Localize("PanelInputInfo2");
        textToTranslate[27].text = LocalizationManager.Localize("PanelInputInfo3");
        textToTranslate[28].text = LocalizationManager.Localize("PanelInputInfo4");

        // Base
        textToTranslate[29].text = LocalizationManager.Localize("BaseHeader");
        textToTranslate[30].text = LocalizationManager.Localize("BaseInfo");
        textToTranslate[31].text = LocalizationManager.Localize("BaseBtn");

        // Search Baloon
        textToTranslate[32].text = LocalizationManager.Localize("BaloonHeader");
        textToTranslate[33].text = LocalizationManager.Localize("BaloonBtn");

        // Courier message
        textToTranslate[34].text = LocalizationManager.Localize("PanelWarningHeader");
        textToTranslate[35].text = LocalizationManager.Localize("PanelWarningYes");
        textToTranslate[36].text = LocalizationManager.Localize("PanelWarningNo");
        textToTranslate[37].text = LocalizationManager.Localize("CourierDeckSend");

        // Loot
        DataLootToTranslate[0].Name = LocalizationManager.Localize("LtChemicals");
        DataLootToTranslate[1].Name = LocalizationManager.Localize("LtCloth");
        DataLootToTranslate[2].Name = LocalizationManager.Localize("LtGas");
        DataLootToTranslate[3].Name = LocalizationManager.Localize("LtMetal");
        DataLootToTranslate[4].Name = LocalizationManager.Localize("LtPetroleum");
        DataLootToTranslate[5].Name = LocalizationManager.Localize("LtSupplies");
        DataLootToTranslate[6].Name = LocalizationManager.Localize("LtBook");
        DataLootToTranslate[7].Name = LocalizationManager.Localize("LtBoots");
        DataLootToTranslate[8].Name = LocalizationManager.Localize("LtClockGear");
        DataLootToTranslate[9].Name = LocalizationManager.Localize("LtGear");
        DataLootToTranslate[10].Name = LocalizationManager.Localize("LtHarmonica");
        DataLootToTranslate[11].Name = LocalizationManager.Localize("LtKnife");
        DataLootToTranslate[12].Name = LocalizationManager.Localize("LtMicroscope");
        DataLootToTranslate[13].Name = LocalizationManager.Localize("LtMug");
        DataLootToTranslate[14].Name = LocalizationManager.Localize("LtPills");
        DataLootToTranslate[15].Name = LocalizationManager.Localize("LtRadiator");
        DataLootToTranslate[16].Name = LocalizationManager.Localize("LtSkull");
        DataLootToTranslate[17].Name = LocalizationManager.Localize("LtSpring");
        DataLootToTranslate[18].Name = LocalizationManager.Localize("LtWheel");

        // Events
        DataIventToTranslate[0].TextHeader = LocalizationManager.Localize("DeathLuck1");
        DataIventToTranslate[0].Text = LocalizationManager.Localize("DeathLuck2");
        DataIventToTranslate[0].VarA = LocalizationManager.Localize("DeathLuck3");
        DataIventToTranslate[0].VarB = LocalizationManager.Localize("DeathLuck4");
        DataIventToTranslate[0].TextA = LocalizationManager.Localize("DeathLuck5");
        DataIventToTranslate[0].TextB = LocalizationManager.Localize("DeathLuck6");

        DataIventToTranslate[1].TextHeader = LocalizationManager.Localize("Dinner1");
        DataIventToTranslate[1].Text = LocalizationManager.Localize("Dinner2");
        DataIventToTranslate[1].VarA = LocalizationManager.Localize("Dinner3");
        DataIventToTranslate[1].VarB = LocalizationManager.Localize("Dinner4");
        DataIventToTranslate[1].TextA = LocalizationManager.Localize("Dinner5");
        DataIventToTranslate[1].TextB = LocalizationManager.Localize("Dinner6");

        DataIventToTranslate[2].TextHeader = LocalizationManager.Localize("EasyDeal1");
        DataIventToTranslate[2].Text = LocalizationManager.Localize("EasyDeal2");
        DataIventToTranslate[2].VarA = LocalizationManager.Localize("EasyDeal3");
        DataIventToTranslate[2].VarB = LocalizationManager.Localize("EasyDeal4");
        DataIventToTranslate[2].TextA = LocalizationManager.Localize("EasyDeal5");
        DataIventToTranslate[2].TextB = LocalizationManager.Localize("EasyDeal6");

        DataIventToTranslate[3].TextHeader = LocalizationManager.Localize("LastBreath1");
        DataIventToTranslate[3].Text = LocalizationManager.Localize("LastBreath2");
        DataIventToTranslate[3].VarA = LocalizationManager.Localize("LastBreath3");
        DataIventToTranslate[3].VarB = LocalizationManager.Localize("LastBreath4");
        DataIventToTranslate[3].TextA = LocalizationManager.Localize("LastBreath5");
        DataIventToTranslate[3].TextB = LocalizationManager.Localize("LastBreath6");

        DataIventToTranslate[4].TextHeader = LocalizationManager.Localize("NaturesPower1");
        DataIventToTranslate[4].Text = LocalizationManager.Localize("NaturesPower2");
        DataIventToTranslate[4].VarA = LocalizationManager.Localize("NaturesPower3");
        DataIventToTranslate[4].VarB = LocalizationManager.Localize("NaturesPower4");
        DataIventToTranslate[4].TextA = LocalizationManager.Localize("NaturesPower5");
        DataIventToTranslate[4].TextB = LocalizationManager.Localize("NaturesPower6");

        DataIventToTranslate[5].TextHeader = LocalizationManager.Localize("MyPrecious1");
        DataIventToTranslate[5].Text = LocalizationManager.Localize("MyPrecious2");
        DataIventToTranslate[5].VarA = LocalizationManager.Localize("MyPrecious3");
        DataIventToTranslate[5].VarB = LocalizationManager.Localize("MyPrecious4");
        DataIventToTranslate[5].TextA = LocalizationManager.Localize("MyPrecious5");
        DataIventToTranslate[5].TextB = LocalizationManager.Localize("MyPrecious6");

        DataIventToTranslate[6].TextHeader = LocalizationManager.Localize("Pyromaniac1");
        DataIventToTranslate[6].Text = LocalizationManager.Localize("Pyromaniac2");
        DataIventToTranslate[6].VarA = LocalizationManager.Localize("Pyromaniac3");
        DataIventToTranslate[6].VarB = LocalizationManager.Localize("Pyromaniac4");
        DataIventToTranslate[6].TextA = LocalizationManager.Localize("Pyromaniac5");
        DataIventToTranslate[6].TextB = LocalizationManager.Localize("Pyromaniac6");

        DataIventToTranslate[7].TextHeader = LocalizationManager.Localize("Silhouettes1");
        DataIventToTranslate[7].Text = LocalizationManager.Localize("Silhouettes2");
        DataIventToTranslate[7].VarA = LocalizationManager.Localize("Silhouettes3");
        DataIventToTranslate[7].VarB = LocalizationManager.Localize("Silhouettes4");
        DataIventToTranslate[7].TextA = LocalizationManager.Localize("Silhouettes5");
        DataIventToTranslate[7].TextB = LocalizationManager.Localize("Silhouettes6");

        DataIventToTranslate[8].TextHeader = LocalizationManager.Localize("PropheticTraveler1");
        DataIventToTranslate[8].Text = LocalizationManager.Localize("PropheticTraveler2");
        DataIventToTranslate[8].VarA = LocalizationManager.Localize("PropheticTraveler3");
        DataIventToTranslate[8].VarB = LocalizationManager.Localize("PropheticTraveler4");
        DataIventToTranslate[8].TextA = LocalizationManager.Localize("PropheticTraveler5");
        DataIventToTranslate[8].TextB = LocalizationManager.Localize("PropheticTraveler6");

        DataIventToTranslate[9].TextHeader = LocalizationManager.Localize("NotAThief1");
        DataIventToTranslate[9].Text = LocalizationManager.Localize("NotAThief2");
        DataIventToTranslate[9].VarA = LocalizationManager.Localize("NotAThief3");
        DataIventToTranslate[9].VarB = LocalizationManager.Localize("NotAThief4");
        DataIventToTranslate[9].TextA = LocalizationManager.Localize("NotAThief5");
        DataIventToTranslate[9].TextB = LocalizationManager.Localize("NotAThief6");

        DataIventToTranslate[10].TextHeader = LocalizationManager.Localize("ThornyPath1");
        DataIventToTranslate[10].Text = LocalizationManager.Localize("ThornyPath2");
        DataIventToTranslate[10].VarA = LocalizationManager.Localize("ThornyPath3");
        DataIventToTranslate[10].VarB = LocalizationManager.Localize("ThornyPath4");
        DataIventToTranslate[10].TextA = LocalizationManager.Localize("ThornyPath5");
        DataIventToTranslate[10].TextB = LocalizationManager.Localize("ThornyPath6");

        DataIventToTranslate[11].TextHeader = LocalizationManager.Localize("CarelessWanderers1");
        DataIventToTranslate[11].Text = LocalizationManager.Localize("CarelessWanderers2");
        DataIventToTranslate[11].VarA = LocalizationManager.Localize("CarelessWanderers3");
        DataIventToTranslate[11].VarB = LocalizationManager.Localize("CarelessWanderers4");
        DataIventToTranslate[11].TextA = LocalizationManager.Localize("CarelessWanderers5");
        DataIventToTranslate[11].TextB = LocalizationManager.Localize("CarelessWanderers6");
    }
}
