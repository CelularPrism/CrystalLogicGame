using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static MusicSettingsStatic;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSFX;
    [SerializeField] private AudioSource audioMusic;
    [SerializeField] private AudioSource audioSound;
    [SerializeField] private AudioClip battleClip;
    [SerializeField] private AudioMixer audioMixer;

    void Update()
    {
        audioMixer.SetFloat("soundVol", MusicSettingsStatic.soundVol);
        audioMixer.SetFloat("musicVol", MusicSettingsStatic.musicVol);
        audioMixer.SetFloat("sfxVol", MusicSettingsStatic.SFXVol);
    }

    public void PlayBattleMusic()
    {
        audioSound.clip = battleClip;
        audioSound.Play();
    }

    public void PlaySFXOnClick(AudioClip music)
    {
        audioSFX.clip = music;
        audioSFX.Play();
    }

    public void PlaySoundOnClick(AudioClip music)
    {
        audioSound.clip = music;
        audioSound.Play();
    }

    public void PlayMusicOnClick(AudioClip music)
    {
        audioMusic.clip = music;
        audioMusic.Play();
    }

    public void StopSFXOnClick()
    {
        audioSFX.Stop();
    }

    public void StopSoundOnClick()
    {
        audioSound.Stop();
    }

    public void StopMusicOnClick()
    {
        audioMusic.Stop();
    }
}
