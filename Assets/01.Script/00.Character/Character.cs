// # System
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


// # Unity
using UnityEngine;

public class Character : InteractionObject
{
    [Header("InGameStat")]
    [SerializeField] protected float adPower;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float criticalProbability;
    [Space(10f)]
    [SerializeField] protected float maxHp;
    protected float currentHp;
    [SerializeField] protected float mana;
    [Space(10f)]
    [SerializeField] protected float adDefense;
    [Space(10f)]
    [SerializeField] protected float moveSpeed;

    protected virtual void Start()
    {
        currentHp = maxHp;
    }

    public virtual void TakeDamage(float damage)
    {
        if (currentHp > 0)
        {
            currentHp -= damage / (1 + (adDefense * 0.01f));
        }
        else if (currentHp <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {

    }
}
