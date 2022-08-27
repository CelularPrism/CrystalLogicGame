using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVLoader : MonoBehaviour
{
    [SerializeField] private string pathFile;
    private TextAsset csvFile;
    private char lineSeperator = '\n';
    private char surround = '"';
    private string[] fieldSeperator = { "\",\"" };

    public void LoadCSV()
    {
        if (pathFile == null)
            pathFile = "Localization/Options";
        csvFile = Resources.Load<TextAsset>(pathFile);
    }

    public Dictionary<string, string> GetDictionaryValues(string attributeId) 
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        string[] lines = csvFile.text.Split(lineSeperator);
        int attributeIndex = -1;
        string[] headers = lines[0].Split(','/*fieldSeperator*/, (char)StringSplitOptions.None);

        for (int i = 0; i < headers.Length; i++)
        {
            if (headers[i].Contains(attributeId))
            {
                attributeIndex = i;
                break;
            }
        }

        /*foreach (string line in lines)
        {
            Debug.Log(line);
        }*/

        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] fields = CSVParser.Split(line);
            //Debug.Log(fields[0]);

            for (int f = 0; f < fields.Length; f++)
            {
                fields[f] = fields[f].TrimStart(' ', surround);
                fields[f] = fields[f].TrimEnd(surround);
                //Debug.Log(fields[f]);
            }

            if (fields.Length > attributeIndex)
            {
                var key = fields[0];

                if (dictionary.ContainsKey(key))
                {
                    continue;
                }
                //Debug.Log(attributeIndex);
                string value = fields[attributeIndex];
                dictionary.Add(key, value);
            }
        }

        return dictionary;
    }
}
