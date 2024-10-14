// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("InStat")]
    [SerializeField] protected float adPower;
    [SerializeField] protected float apPower;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float criticalProbability;
    [Space(10f)]
    [SerializeField] protected float maxHp;
    [SerializeField] protected float mana;
    [Space(10f)]
    [SerializeField] protected float adDefense;
    [SerializeField] protected float apDefense;

    [Header("MotionStat")]
    [SerializeField] private float turnSpeed;
}
