using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipSO audioClip;
    private float volume = 1f;

    private void Start()
    {
        Arrow.OnEnemyHit += Enemy_Hit;
        Bow.Instance.OnPlayerShoot += Player_OnPlayerShoot;
    }

    private void Player_OnPlayerShoot(object sender, EventArgs e)
    {
        PlaySound(audioClip.fireShoot, Bow.Instance.transform.position);

    }

    private void Enemy_Hit(object sender, EventArgs e)
    {
        Arrow arrow = sender as Arrow;
        PlaySound(audioClip.arrowHit, arrow.transform.position);
    }

    private void PlaySound(AudioClip audio, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audio, position, volumeMultiplier * volume);

    }
}
