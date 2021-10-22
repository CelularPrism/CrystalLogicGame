using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using OneClickLocalization.Core;

public class UIOption : MonoBehaviour
{
    [SerializeField] private Text SoundTxt;
    [SerializeField] private Text FXTxt;
    [SerializeField] private Text MusicTxt;

    [SerializeField] private Slider SoundSlider;
    [SerializeField] private Slider FXSlider;
    [SerializeField] private Slider MusicSlider;

    [SerializeField] private AudioMixer audio;

    [SerializeField] private LocalizationSetup localization;

    private void Awake()
    {
        Debug.Log(Time.time);
    }

    void Update()
    {
        SoundTxt.text = SoundSlider.value.ToString() + "%";
        FXTxt.text = FXSlider.value.ToString() + "%";
        MusicTxt.text = MusicSlider.value.ToString() + "%";

        audio.SetFloat("soundVol", SoundSlider.value - 80);
        audio.SetFloat("musicVol", MusicSlider.value - 80);
        audio.SetFloat("sfxVol", FXSlider.value - 80);
    }

    public void EuLang()
    {
        /*localization.defaultLanguage = SystemLanguage.English;
        localization.SetDefaultLanguage(SystemLanguage.English);*/
    }

    public void RuLang()
    {
        /*localization.defaultLanguage = SystemLanguage.Russian;
        localization.SetDefaultLanguage(SystemLanguage.Russian);*/
    }
}