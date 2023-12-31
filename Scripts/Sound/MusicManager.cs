using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicManager : MonoBehaviour
{

    public static MusicManager Instance;

    public AudioSource bgmAudioSource;
    public AudioClip bgmClip;
    public Toggle bgmToggle;
    private const string VOLUME_BGM = "volume_BGM";
  

    void Start()
    {

     
        bgmToggle.onValueChanged.AddListener(OnMusicToggleChanged);
        bgmAudioSource.clip = bgmClip;

        bgmAudioSource.volume =PlayerPrefs.GetFloat(VOLUME_BGM);

        bgmToggle.isOn = bgmAudioSource.volume > 0.0f;

        bgmAudioSource.Play();


    }

    void OnMusicToggleChanged(bool isOn)
    {
        bgmAudioSource.volume = isOn ? 0.1f : 0.0f;

        PlayerPrefs.SetFloat(VOLUME_BGM, bgmAudioSource.volume);

    }
}
