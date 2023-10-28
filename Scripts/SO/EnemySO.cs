using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemySO : ScriptableObject
{
    public string difficulty;
    public Transform[] enemyPrefabs;
    public Transform target;
}
