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

    [SerializeField] private List<GameObject> ruBtn;
    [SerializeField] private List<GameObject> enBtn;

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
                for (int i = 0; i < enBtn.Count; i++)
                {
                    enBtn[i].GetComponent<Image>().color = activeColor;
                    ruBtn[i].GetComponent<Image>().color = nonActiveColor;

                    enBtn[i].transform.GetChild(0).GetComponent<Text>().color = nonActiveColor;
                    ruBtn[i].transform.GetChild(0).GetComponent<Text>().color = activeColor;
                }
                break;
            case "Russian":
                Language("Russian");
                for (int i = 0; i < enBtn.Count; i++)
                {
                    enBtn[i].GetComponent<Image>().color = nonActiveColor;
                    ruBtn[i].GetComponent<Image>().color = activeColor;

                    enBtn[i].transform.GetChild(0).GetComponent<Text>().color = activeColor;
                    ruBtn[i].transform.GetChild(0).GetComponent<Text>().color = nonActiveColor;
                }
                break;
        }
    }

    public void Language(string language)
    {

        switch (language)
        {
            case "English":
                PlayerStatic.lang = "English";
                for (int i = 0; i < enBtn.Count; i++)
                {
                    enBtn[i].GetComponent<Image>().color = activeColor;
                    ruBtn[i].GetComponent<Image>().color = nonActiveColor;

                    enBtn[i].transform.GetChild(0).GetComponent<Text>().color = nonActiveColor;
                    ruBtn[i].transform.GetChild(0).GetComponent<Text>().color = activeColor;
                }
                break;

            case "Russian":
                PlayerStatic.lang = "Russian";

                for (int i = 0; i < enBtn.Count; i++)
                {
                    enBtn[i].GetComponent<Image>().color = nonActiveColor;
                    ruBtn[i].GetComponent<Image>().color = activeColor;

                    enBtn[i].transform.GetChild(0).GetComponent<Text>().color = activeColor;
                    ruBtn[i].transform.GetChild(0).GetComponent<Text>().color = nonActiveColor;
                }
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
        textToTranslate[38].text = LocalizationManager.Localize("PanelLootBase");

        textToTranslate[39].text = LocalizationManager.Localize("RepairPanelHeader");
        textToTranslate[40].text = LocalizationManager.Localize("RepairPanelText");
        textToTranslate[41].text = LocalizationManager.Localize("RepairPanelBtn");
        textToTranslate[42].text = LocalizationManager.Localize("PanelLootBase");

        textToTranslate[43].text = LocalizationManager.Localize("Prologue0.1");
        textToTranslate[44].text = LocalizationManager.Localize("Prologue0.2");
        textToTranslate[45].text = LocalizationManager.Localize("Prologue0.3");
        textToTranslate[46].text = LocalizationManager.Localize("Prologue1");
        textToTranslate[47].text = LocalizationManager.Localize("Prologue2");
        textToTranslate[48].text = LocalizationManager.Localize("Prologue3");
        textToTranslate[49].text = LocalizationManager.Localize("Prologue4");
        textToTranslate[50].text = LocalizationManager.Localize("Prologue5");
        textToTranslate[51].text = LocalizationManager.Localize("Prologue6");
        textToTranslate[52].text = LocalizationManager.Localize("Prologue7");
        textToTranslate[53].text = LocalizationManager.Localize("Prologue8");
        textToTranslate[54].text = LocalizationManager.Localize("Prologue9");
        textToTranslate[55].text = LocalizationManager.Localize("Prologue10");

        textToTranslate[56].text = LocalizationManager.Localize("Epilogue1");
        textToTranslate[57].text = LocalizationManager.Localize("Epilogue2");
        textToTranslate[58].text = LocalizationManager.Localize("Epilogue3");
        textToTranslate[59].text = LocalizationManager.Localize("Epilogue4");
        textToTranslate[60].text = LocalizationManager.Localize("Epilogue5");
        textToTranslate[61].text = LocalizationManager.Localize("Epilogue6");
        textToTranslate[62].text = LocalizationManager.Localize("Epilogue7");
        textToTranslate[63].text = LocalizationManager.Localize("Epilogue8");
        textToTranslate[64].text = LocalizationManager.Localize("Epilogue9");

        textToTranslate[65].text = LocalizationManager.Localize("OptLanguage");

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
        DataIventToTranslate[0].TextHeader = LocalizationManager.Localize("EasyProfit1");
        DataIventToTranslate[0].Text = LocalizationManager.Localize("EasyProfit2");
        DataIventToTranslate[0].VarA = LocalizationManager.Localize("EasyProfit3");
        DataIventToTranslate[0].VarB = LocalizationManager.Localize("EasyProfit4");
        DataIventToTranslate[0].TextA = LocalizationManager.Localize("EasyProfit5");
        DataIventToTranslate[0].TextB = LocalizationManager.Localize("EasyProfit6");

        DataIventToTranslate[1].TextHeader = LocalizationManager.Localize("EasyMetal1");
        DataIventToTranslate[1].Text = LocalizationManager.Localize("EasyMetal2");
        DataIventToTranslate[1].VarA = LocalizationManager.Localize("EasyMetal3");
        DataIventToTranslate[1].VarB = LocalizationManager.Localize("EasyMetal4");
        DataIventToTranslate[1].TextA = LocalizationManager.Localize("EasyMetal5");
        DataIventToTranslate[1].TextB = LocalizationManager.Localize("EasyMetal6");

        DataIventToTranslate[2].TextHeader = LocalizationManager.Localize("Silhouettes1");
        DataIventToTranslate[2].Text = LocalizationManager.Localize("Silhouettes2");
        DataIventToTranslate[2].VarA = LocalizationManager.Localize("Silhouettes3");
        DataIventToTranslate[2].VarB = LocalizationManager.Localize("Silhouettes4");
        DataIventToTranslate[2].TextA = LocalizationManager.Localize("Silhouettes5");
        DataIventToTranslate[2].TextB = LocalizationManager.Localize("Silhouettes6");

        DataIventToTranslate[3].TextHeader = LocalizationManager.Localize("FirstCome1");
        DataIventToTranslate[3].Text = LocalizationManager.Localize("FirstCome2");
        DataIventToTranslate[3].VarA = LocalizationManager.Localize("FirstCome3");
        DataIventToTranslate[3].VarB = LocalizationManager.Localize("FirstCome4");
        DataIventToTranslate[3].TextA = LocalizationManager.Localize("FirstCome5");
        DataIventToTranslate[3].TextB = LocalizationManager.Localize("FirstCome6");

        DataIventToTranslate[4].TextHeader = LocalizationManager.Localize("CorneredBeast1");
        DataIventToTranslate[4].Text = LocalizationManager.Localize("CorneredBeast2");
        DataIventToTranslate[4].VarA = LocalizationManager.Localize("CorneredBeast3");
        DataIventToTranslate[4].VarB = LocalizationManager.Localize("CorneredBeast4");
        DataIventToTranslate[4].TextA = LocalizationManager.Localize("CorneredBeast5");
        DataIventToTranslate[4].TextB = LocalizationManager.Localize("CorneredBeast6");

        DataIventToTranslate[5].TextHeader = LocalizationManager.Localize("NoHarmNoFoul1");
        DataIventToTranslate[5].Text = LocalizationManager.Localize("NoHarmNoFoul2");
        DataIventToTranslate[5].VarA = LocalizationManager.Localize("NoHarmNoFoul3");
        DataIventToTranslate[5].VarB = LocalizationManager.Localize("NoHarmNoFoul4");
        DataIventToTranslate[5].TextA = LocalizationManager.Localize("NoHarmNoFoul5");
        DataIventToTranslate[5].TextB = LocalizationManager.Localize("NoHarmNoFoul6");

        DataIventToTranslate[6].TextHeader = LocalizationManager.Localize("Vultures1");
        DataIventToTranslate[6].Text = LocalizationManager.Localize("Vultures2");
        DataIventToTranslate[6].VarA = LocalizationManager.Localize("Vultures3");
        DataIventToTranslate[6].VarB = LocalizationManager.Localize("Vultures4");
        DataIventToTranslate[6].TextA = LocalizationManager.Localize("Vultures5");
        DataIventToTranslate[6].TextB = LocalizationManager.Localize("Vultures6");

        DataIventToTranslate[7].TextHeader = LocalizationManager.Localize("VengefulPirate1");
        DataIventToTranslate[7].Text = LocalizationManager.Localize("VengefulPirate2");
        DataIventToTranslate[7].VarA = LocalizationManager.Localize("VengefulPirate3");
        DataIventToTranslate[7].VarB = LocalizationManager.Localize("VengefulPirate4");
        DataIventToTranslate[7].TextA = LocalizationManager.Localize("VengefulPirate5");
        DataIventToTranslate[7].TextB = LocalizationManager.Localize("VengefulPirate6");

        DataIventToTranslate[8].TextHeader = LocalizationManager.Localize("DeadMenNoLies1");
        DataIventToTranslate[8].Text = LocalizationManager.Localize("DeadMenNoLies2");
        DataIventToTranslate[8].VarA = LocalizationManager.Localize("DeadMenNoLies3");
        DataIventToTranslate[8].VarB = LocalizationManager.Localize("DeadMenNoLies4");
        DataIventToTranslate[8].TextA = LocalizationManager.Localize("DeadMenNoLies5");
        DataIventToTranslate[8].TextB = LocalizationManager.Localize("DeadMenNoLies6");

        DataIventToTranslate[9].Text = LocalizationManager.Localize("DeadMenNoLies5");
        DataIventToTranslate[9].VarA = LocalizationManager.Localize("DeadMenNoLies7");
        DataIventToTranslate[9].VarB = LocalizationManager.Localize("DeadMenNoLies8");
        DataIventToTranslate[9].TextA = LocalizationManager.Localize("DeadMenNoLies9");
        DataIventToTranslate[9].TextB = LocalizationManager.Localize("DeadMenNoLies10");

        DataIventToTranslate[10].TextHeader = LocalizationManager.Localize("FreeCheese1");
        DataIventToTranslate[10].Text = LocalizationManager.Localize("FreeCheese2");
        DataIventToTranslate[10].VarA = LocalizationManager.Localize("FreeCheese3");
        DataIventToTranslate[10].VarB = LocalizationManager.Localize("FreeCheese4");
        DataIventToTranslate[10].TextA = LocalizationManager.Localize("FreeCheese5");
        DataIventToTranslate[10].TextB = LocalizationManager.Localize("FreeCheese6");

        DataIventToTranslate[11].Text = LocalizationManager.Localize("FreeCheese5");
        DataIventToTranslate[11].VarA = LocalizationManager.Localize("FreeCheese7");
        DataIventToTranslate[11].VarB = LocalizationManager.Localize("FreeCheese8");
        DataIventToTranslate[11].TextA = LocalizationManager.Localize("FreeCheese9");
        DataIventToTranslate[11].TextB = LocalizationManager.Localize("FreeCheese10");

        DataIventToTranslate[12].TextHeader = LocalizationManager.Localize("NightmareFuel1");
        DataIventToTranslate[12].Text = LocalizationManager.Localize("NightmareFuel2");
        DataIventToTranslate[12].VarA = LocalizationManager.Localize("NightmareFuel3");
        DataIventToTranslate[12].VarB = LocalizationManager.Localize("NightmareFuel4");
        DataIventToTranslate[12].TextA = LocalizationManager.Localize("NightmareFuel5");
        DataIventToTranslate[12].TextB = LocalizationManager.Localize("NightmareFuel6");

        DataIventToTranslate[13].Text = LocalizationManager.Localize("NightmareFuel5");
        DataIventToTranslate[13].VarA = LocalizationManager.Localize("NightmareFuel7");
        DataIventToTranslate[13].VarB = LocalizationManager.Localize("NightmareFuel8");
        DataIventToTranslate[13].TextA = LocalizationManager.Localize("NightmareFuel9");
        DataIventToTranslate[13].TextB = LocalizationManager.Localize("NightmareFuel10");

        DataIventToTranslate[14].TextHeader = LocalizationManager.Localize("DeepLake1");
        DataIventToTranslate[14].Text = LocalizationManager.Localize("DeepLake2");
        DataIventToTranslate[14].VarA = LocalizationManager.Localize("DeepLake3");
        DataIventToTranslate[14].VarB = LocalizationManager.Localize("DeepLake4");
        DataIventToTranslate[14].TextA = LocalizationManager.Localize("DeepLake5");
        DataIventToTranslate[14].TextB = LocalizationManager.Localize("DeepLake6");

        DataIventToTranslate[15].Text = LocalizationManager.Localize("DeepLake6");
        DataIventToTranslate[15].VarA = LocalizationManager.Localize("DeepLake7");
        DataIventToTranslate[15].VarB = LocalizationManager.Localize("DeepLake8");
        DataIventToTranslate[15].TextA = LocalizationManager.Localize("DeepLake9");
        DataIventToTranslate[15].TextB = LocalizationManager.Localize("DeepLake10");

        DataIventToTranslate[16].TextHeader = LocalizationManager.Localize("WoundedGasGanger1");
        DataIventToTranslate[16].Text = LocalizationManager.Localize("WoundedGasGanger2");
        DataIventToTranslate[16].VarA = LocalizationManager.Localize("WoundedGasGanger3");
        DataIventToTranslate[16].VarB = LocalizationManager.Localize("WoundedGasGanger4");
        DataIventToTranslate[16].TextB = LocalizationManager.Localize("WoundedGasGanger5");

        DataIventToTranslate[17].TextA = LocalizationManager.Localize("WoundedGasGanger6");
        DataIventToTranslate[17].TextB = LocalizationManager.Localize("WoundedGasGanger7");

        DataIventToTranslate[18].TextHeader = LocalizationManager.Localize("MysteriousContainer1");
        DataIventToTranslate[18].Text = LocalizationManager.Localize("MysteriousContainer2");
        DataIventToTranslate[18].VarA = LocalizationManager.Localize("MysteriousContainer3");
        DataIventToTranslate[18].VarB = LocalizationManager.Localize("MysteriousContainer4");
        DataIventToTranslate[18].TextA = LocalizationManager.Localize("MysteriousContainer5");

        DataIventToTranslate[19].TextA = LocalizationManager.Localize("MysteriousContainer6");
        DataIventToTranslate[19].TextB = LocalizationManager.Localize("MysteriousContainer7");

        DataIventToTranslate[20].TextHeader = LocalizationManager.Localize("RaysOfKindness1");
        DataIventToTranslate[20].Text = LocalizationManager.Localize("RaysOfKindness2");
        DataIventToTranslate[20].VarA = LocalizationManager.Localize("RaysOfKindness3");
        DataIventToTranslate[20].VarB = LocalizationManager.Localize("RaysOfKindness4");
        DataIventToTranslate[20].TextA = LocalizationManager.Localize("RaysOfKindness5");

        DataIventToTranslate[21].TextA = LocalizationManager.Localize("RaysOfKindness6");
        DataIventToTranslate[21].TextB = LocalizationManager.Localize("RaysOfKindness7");
    }
}
