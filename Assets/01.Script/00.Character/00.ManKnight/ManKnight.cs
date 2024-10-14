// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;
using UnityEngine.AI;

public class ManKnight : Character
{
    [Header("Component")]
    private Rigidbody rb;
    private Animator animator;
    private NavMeshAgent agent;

    [Header("Camera")]
    [SerializeField] private GameObject cameraParent;
    [SerializeField] private Camera camera;

    [Header("MotionStat")]
    [SerializeField] private float turnSpeed;
    private bool isMotion;

    [Header("Animation")]
    private float motionSmoothTime = 0.1f;
    public float speed;

    [Header("Move")]
    private float horInput;
    private float verInput;

    [Header("MovePosEffect")]
    [SerializeField] private GameObject pointEffect;

    #region ����Ƽ �Լ�
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void Start()
    {
        agent.speed = moveSpeed;
        agent.angularSpeed = turnSpeed;
        base.Start();
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
        speed = agent.velocity.magnitude / agent.speed; // �ӵ� ����
        animator.SetFloat("Speed", speed); // �ӵ�
    }
    #endregion

    #region Ŭ�� ��ȣ�ۿ�
    private void CheckClickInteraction()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.TryGetComponent<InteractionObject>(out InteractionObject io))
                {
                    if (io.targetType == InteractionTargetType.ground || io.targetType == InteractionTargetType.wall)
                    {
                        movement(hit.point);
                        Instantiate(pointEffect, hit.point, Quaternion.identity);
                    }
                    else if (io.targetType == InteractionTargetType.character)
                    {
                        // ĳ���� ���� ��ȣ�ۿ� ���� �߰� ����
                    }
                }
            }
        }
    }
    #endregion

    #region �̵� �Լ�
    public void movement(Vector3 pos)
    {
        agent.SetDestination(pos);
    }
    #endregion
}
