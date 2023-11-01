using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private const string PLAYER_SHOOT = "Shoot";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Player.Instance.OnPlayerShoot += Player_OnShoot;
    }

    private void Player_OnShoot(object sender, EventArgs e)
    {
        animator.SetTrigger(PLAYER_SHOOT);
    }


}
