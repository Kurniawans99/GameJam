using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arrow : MonoBehaviour
{
    public static event EventHandler OnEnemyHit;
    public static void ResetStaticData()
    {
        OnEnemyHit = null;
    }

    private Rigidbody rb;
    private float speed;
    private float damage;
    private float burnDamage;
    private float arrowTimer;
    private float arrowTimerMax = 5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        speed = Bow.Instance.speed;
        damage = Bow.Instance.damage;
        burnDamage = Bow.Instance.burnDamage;
        rb.AddForce(transform.forward * -speed, ForceMode.Impulse);

    }

    private void Update()
    {
        arrowTimer += Time.deltaTime;
        if (arrowTimer > arrowTimerMax)
        {
            Destroy(gameObject);
        }
    }

    private void SkillActive(PlayerSkill skill, Enemy enemy)
    {
        skill.SlowEnemy(enemy, 1.2f);
        if (skill.IsPoison())
        {
            enemy.Burning(skill, burnDamage);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out Enemy enemy))
        {
            OnEnemyHit?.Invoke(this, EventArgs.Empty);
            enemy.TakenDamage(damage);
            SkillActive(PlayerSkill.Instance, enemy);
            if (PlayerSkill.Instance.SniperArrow())
            {
                return;
            }
            Destroy(gameObject);
        }
    }



}
