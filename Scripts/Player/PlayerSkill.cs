using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [HideInInspector] public static PlayerSkill Instance { get; private set; }
    private bool freezeArrow = false;
    private bool poisonArrow = false;
    private bool doubleArrow = false;
    private bool sniperArrow = false;
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateSkills(string nameSkill)
    {
        freezeArrow = false;
        poisonArrow = false;
        doubleArrow = false;
        sniperArrow = false;


        switch (nameSkill)
        {
            case "doubleArrow":
                doubleArrow = true;
                break;
            case "sniperArrow":
                sniperArrow = true;
                break;
            case "freezeArrow":
                freezeArrow = true;
                break;
            case "poisonArrow":
                poisonArrow = true;
                break;
            /*case "firerateArrow":
                firerateArrow = true;
                break;*/
            default:
                Debug.Log("ERROR");
                break;
        }
    }

    public void SlowEnemy(Enemy enemy, float percentageSlow)
    {
        if (freezeArrow && enemy.agent.speed >= enemy.speed / 2)
        {
            enemy.agent.speed /= percentageSlow;
        }
    }
    public IEnumerator Poison(Enemy enemy, float burnDamage)
    {
        if (poisonArrow == false) yield break;

        float endTime = Time.time + Bow.Instance.burnDuration;
        while (Time.time < endTime && enemy != null)
        {
            enemy.TakenDamage(burnDamage * Time.deltaTime);
            yield return null;
        }

    }

    public IEnumerator DoubleArrow(Vector3 spawnPos, Transform arrow)
    {
        if (doubleArrow == false) yield break;
        float fireDelay = 0.1f;
        yield return new WaitForSeconds(fireDelay);
        Instantiate(arrow, spawnPos, Quaternion.identity);
    }

    public bool SniperArrow()
    {
        if (sniperArrow == true)
        {
            return true;
        }
        return false;
    }

    public bool IsPoison()
    {
        return poisonArrow;
    }
    public bool IsDoubleArrow()
    {
        return doubleArrow;
    }
}