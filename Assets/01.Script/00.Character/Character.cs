// # System
using System;
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [Header("Component")]
    private Rigidbody rb;
    private Animator animator;
    private NavMeshAgent agent;

    [Header("Camera")]
    [SerializeField] private GameObject cameraParent;
    [SerializeField] private Camera camera;

    [Header("InGameStat")]
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
    [Space(10f)]
    [SerializeField] protected float moveSpeed;

    [Header("MotionStat")]
    [SerializeField] private float turnSpeed;
    private bool isMotion;

    [Header("Animation")]
    private float motionSmoothTime = 0.1f;
    public float speed;

    [Header("Move")]
    private float horInput;
    private float verInput;

    [Header("Type")]
    public Team team;
    public InteractionTargetType targetType;

    #region 유니티 함수
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.speed = moveSpeed;
        agent.angularSpeed = turnSpeed;
    }

    private void FixedUpdate()
    {
        horInput = Input.GetAxisRaw("Horizontal");
        verInput = Input.GetAxisRaw("Vertical");
    }

    private void Update()
    {
        cameraParent.transform.position = new Vector3(transform.position.x, cameraParent.transform.position.y, transform.position.z);
        CheckClickInteraction();
        speed = agent.velocity.magnitude / agent.speed; //속도지정
        animator.SetFloat("Speed", speed); //속도
    }
    #endregion

    #region 클릭 상호작용
    private void CheckClickInteraction()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                movement(hit.point);
            }            
        }
    }

    #endregion

    #region 이동 함수
    public void movement(Vector3 pos)
    {
        agent.SetDestination(pos);
    }
    #endregion
}
