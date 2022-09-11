using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalisationSystem : MonoBehaviour
{
    public enum Language
    {
        English,
        Russian
    }


    public static Language language = Language.English;

    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedRU;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValues("English");
        localisedRU = csvLoader.GetDictionaryValues("Russian");
        //var languages = Enum.GetValues(typeof(Language));
        isInit = true;
    }

    public static string GetLocalisedValue(string key)
    {
        if (!isInit)
        {
            Init();
        }
        string value = key;
        switch(language)
        {
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                break;

            case Language.Russian:
                localisedRU.TryGetValue(key, out value);
                break;
        }
        return value;
    }

    public static Language GetLanguage()
    {
        return language;
    }

    public void SetLanguage(int num)
    {
        language = (Language)Enum.ToObject(typeof(Language), num);
    }
}
