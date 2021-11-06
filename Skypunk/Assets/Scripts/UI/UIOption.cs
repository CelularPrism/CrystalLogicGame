using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using static MusicSettingsStatic;

[Serializable]
public class UIOption : MonoBehaviour
{
    [SerializeField] private Text SoundTxt;
    [SerializeField] private Text FXTxt;
    [SerializeField] private Text MusicTxt;

    [SerializeField] private Slider SoundSlider;
    [SerializeField] private Slider FXSlider;
    [SerializeField] private Slider MusicSlider;

    [SerializeField] private AudioMixer audio;

    [SerializeField] private MultiLanguage localization;

    void Start()
    {
        SoundSlider.value = MusicSettingsStatic.soundVol + 80;
        MusicSlider.value = MusicSettingsStatic.musicVol + 80;
        FXSlider.value = MusicSettingsStatic.SFXVol + 80;
    }

    void Update()
    {
        SoundTxt.text = SoundSlider.value.ToString() + "%";
        FXTxt.text = FXSlider.value.ToString() + "%";
        MusicTxt.text = MusicSlider.value.ToString() + "%";

        MusicSettingsStatic.soundVol = SoundSlider.value - 80;
        MusicSettingsStatic.musicVol = MusicSlider.value - 80;
        MusicSettingsStatic.SFXVol = FXSlider.value - 80;
    }
}
