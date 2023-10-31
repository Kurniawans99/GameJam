using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public event EventHandler OnPlayerShoot;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private Transform projectile;
    public static Bow Instance { get; private set; }
    public float fireRate;
    public float fireRateMax = 0.3f;

    [HideInInspector] public float speed = 50f;
    [HideInInspector] public float damage = 25f;
    [HideInInspector] public float burnDamage = 5f;
    public float burnDuration = 2f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AttackPower.OnPowerChanged += OnPowerChanged; // Subscribe to the event

    }

    private void OnPowerChanged(object sender, EventArgs e)
    {
        // Increase the damage by 10 when AttackPower changes
        damage += 2;
    }
    private void Update()
    {
        fireRate += Time.deltaTime;
    }

    public void Fire()
    {
        if (fireRate > fireRateMax)
        {
            OnPlayerShoot?.Invoke(this, EventArgs.Empty);

            Transform arrow = Instantiate(projectile, projectileSpawn);
            arrow.SetParent(null);
            if (PlayerSkill.Instance.IsDoubleArrow())
            {
                StartCoroutine(PlayerSkill.Instance.DoubleArrow(transform.position, projectile));
            }
            fireRate = 0f;
        }

    }
}