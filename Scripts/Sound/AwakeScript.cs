using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AwakeScript : MonoBehaviour
{
    private const string VOLUME_BGM = "volume_BGM";
    private const string VOLUME_SFX = "volume_SFX";


    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetFloat(VOLUME_BGM, 1f);
        PlayerPrefs.SetFloat(VOLUME_SFX, 1f);


    }
}
