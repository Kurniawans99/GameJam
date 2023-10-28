using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfxButton;
    public AudioClip sfxCorrect;
    public AudioClip sfxWrong;

    public static AudioManager Instance;
    private const string VOLUME_SFX = "volume";

    public Toggle sfxToggle;


    private void Start()
    {
        src.volume = PlayerPrefs.GetFloat(VOLUME_SFX);

        sfxToggle.onValueChanged.AddListener(OnSFXToggleChanged);
    }

    public void PlayButtonClickSound()
    {
        src.clip = sfxButton;
        src.Play();
    }

    public void Play_Wrong()
    {
        src.clip = sfxWrong;
        src.Play();
    }
    public void Play_Correct()
    {
        src.clip = sfxCorrect;
        src.Play();
    }
    void OnSFXToggleChanged(bool isOn)
    {
        src.volume = isOn ? 1.0f : 0.0f;
        PlayerPrefs.SetFloat(VOLUME_SFX, src.volume);

    }
}
