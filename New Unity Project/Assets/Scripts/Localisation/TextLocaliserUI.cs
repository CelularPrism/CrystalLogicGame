using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextLocaliserUI : MonoBehaviour
{
    [SerializeField] private bool dynamicValue;

    private Text textField;
    
    private LocalisationSystem.Language _language;

    public string key;

    private void Start()
    {
        textField = GetComponent<Text>();
        _language = LocalisationSystem.GetLanguage();
        string value = LocalisationSystem.GetLocalisedValue(key);
        textField.text = value;
    }

    private void Update()
    {
        LocalisationSystem.Language lang = LocalisationSystem.GetLanguage();
        if (_language != lang || dynamicValue)
        {
            _language = lang;
            string value = LocalisationSystem.GetLocalisedValue(key);
            textField.text = value;
        }
    }
}
