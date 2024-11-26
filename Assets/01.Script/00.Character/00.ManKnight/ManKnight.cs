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
    [SerializeField] private Camera playerCam;

    [Header("KeySetting")]
    [SerializeField] KeyCode InteractionKey = KeyCode.J;

    [Header("MotionStat")]
    [SerializeField] private float turnSpeed;
    private bool isMotion;

    [Header("Animation")]
    private float motionSmoothTime = 0.1f;
    public float speed;

    [Header("MovePosEffect")]
    [SerializeField] private GameObject pointEffect;

    [Header("InteractionKeyUI")]
    [SerializeField] private GameObject interactionKeyUI;

    [Header("Shop")]
    [SerializeField] private bool isShop;
    [SerializeField] private GameObject shopCanvas;

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

    private void Update()
    {
        cameraParent.transform.position = new Vector3(transform.position.x, cameraParent.transform.position.y, transform.position.z);
        CheckClickInteraction();
        speed = agent.velocity.magnitude / agent.speed; // �ӵ� ����
        animator.SetFloat("Speed", speed); // �ӵ�

        InteractionKeyUITrigger();
        ShopUIInteraction();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Shop"))
        {
            isShop = true;
        }
        else
        {
            // �ٸ� ��ü�� �����ϰ� isShop ���¸� ����
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shop"))
        {
            isShop = false;
            CloseShop();
        }
    }

    #endregion

    #region Ŭ�� ��ȣ�ۿ�
    private void CheckClickInteraction()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.TryGetComponent<InteractionObject>(out InteractionObject io))
                {
                    if (io.targetType == InteractionTargetType.ground || io.targetType == InteractionTargetType.wall)
                    {
                        movement(hit.point);
                        Instantiate(pointEffect, hit.point, Quaternion.identity);
                        break; // �̹� ó���� ����̸� ���� ����
                    }
                    else if (io.targetType == InteractionTargetType.character)
                    {
                        // ĳ���� ���� ��ȣ�ۿ� ���� �߰� ����
                        break;
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

    #region ��ȣ�ۿ� �Լ�
    private void InteractionKeyUITrigger()
    {
        if (isShop)
        {
            interactionKeyUI.SetActive(true);
        }
        else
        {
            interactionKeyUI.SetActive(false);
        }
    }

    private void ShopUIInteraction()
    {
        if (isShop && Input.GetKeyDown(InteractionKey) && !shopCanvas.activeSelf)
        {
            shopCanvas.SetActive(true);
        }
        else if (isShop && Input.GetKeyDown(InteractionKey) && shopCanvas.activeSelf)
        {
            CloseShop();
        }
    }

    private void CloseShop()
    {
        shopCanvas.SetActive(false);
    }
    #endregion
}
