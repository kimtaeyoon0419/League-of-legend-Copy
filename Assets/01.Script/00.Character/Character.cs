// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Component")]
    private Rigidbody rb;
    private Animator animator;

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

    [Header("Move")]
    private float horInput;
    private float verInput;

    #region 유니티 함수
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        horInput = Input.GetAxisRaw("Horizontal");
        verInput = Input.GetAxisRaw("Vertical");
    }
    #endregion

    #region 이동 함수

    #endregion
}
