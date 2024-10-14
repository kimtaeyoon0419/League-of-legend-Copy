// # System
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


// # Unity
using UnityEngine;

public enum DamageType
{
    ad,
    ap,
    _true
}

public class Character : InteractionObject
{
    [Header("InGameStat")]
    [SerializeField] protected float adPower;
    [SerializeField] protected float apPower;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float criticalProbability;
    [Space(10f)]
    [SerializeField] protected float maxHp;
    protected float currentHp;
    [SerializeField] protected float mana;
    [Space(10f)]
    [SerializeField] protected float adDefense;
    [SerializeField] protected float apDefense;
    [Space(10f)]
    [SerializeField] protected float moveSpeed;

    protected virtual void Start()
    {
        currentHp = maxHp;
    }

    public virtual void TakeDamage(float damage, DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.ad:
                currentHp -= damage / (1 + (adDefense * 0.01f));
                break;
            case DamageType.ap:
                currentHp -= damage / (1 + (apDefense * 0.01f));
                break;
            case DamageType._true:
                currentHp -= damage;
                break;
        }
        if(currentHp <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {

    }
}
