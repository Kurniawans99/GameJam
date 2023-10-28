using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 target;
    private float speed;
    private float damage;
    private float burnDamage;
    private Vector3 direction;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = Player.Instance.targetPos;
    }

    private void Start()
    {
        speed = Bow.Instance.speed;
        damage = Bow.Instance.damage;
        burnDamage = Bow.Instance.burnDamage;
        direction = (target - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * speed, ForceMode.Impulse);

        transform.LookAt(target);
        transform.Rotate(0, 180, 0);
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
            enemy.TakenDamage(damage);
            SkillActive(PlayerSkill.Instance, enemy);
            Destroy(gameObject);
        }
    }


}
