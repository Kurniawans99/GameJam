using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AwakeScript : MonoBehaviour
{
    private const string VOLUME_BGM = "volume";

    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetFloat(VOLUME_BGM, 1f);

    }
}
