//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CameraController : MonoBehaviour
//{
//    public Transform character; // ĳ���� Transform
//    public LayerMask obstacleLayer; // ��ֹ� ���̾� (������ ���̾� ����)
//    public float smoothSpeed = 5f; // ī�޶� �̵� �ӵ�
//    public float cameraOffsetDistance = 0.5f; // ��ü �տ��� ������ �Ÿ�

//    private Vector3 originalPosition; // ī�޶��� ���� ��ġ ����
//    private bool isObstacleDetected = false; // ��ֹ� ���� ����
//    private Vector3 desiredPosition; // ��ǥ ��ġ

//    private void Start()
//    {
//        ī�޶��� �ʱ� ��ġ ����
//        originalPosition = transform.position;
//        desiredPosition = originalPosition;
//    }

//    private void LateUpdate()
//    {
//        ī�޶�� ĳ���� ������ ���� ���
//       Vector3 directionToCharacter = character.position - transform.position;
//        RaycastHit hit;

//        ����ĳ��Ʈ�� ��ֹ� ����(��ֹ� ���̾ ����)
//        if (Physics.Raycast(character.position, -directionToCharacter.normalized, out hit, directionToCharacter.magnitude, obstacleLayer))
//        {
//            ��ֹ��� ������ ī�޶� ��ü�� �������� �̵�
//            Vector3 hitPoint = hit.point; // ��ü�� �浹�� ����
//            Vector3 moveDirection = (character.position - hitPoint).normalized; // ��ü �������� �̵��� ����
//            desiredPosition = hitPoint - moveDirection * cameraOffsetDistance; // ��ֹ� �������� ī�޶� ��ġ ����
//            isObstacleDetected = true;
//        }
//        else
//        {
//            ��ֹ��� ������ �ٽ� ���� ��ġ�� ����
//            if (isObstacleDetected)
//            {
//                desiredPosition = originalPosition; // ���� ��ġ�� ���ư��� ����
//                isObstacleDetected = false;
//            }
//        }

//        ī�޶� �ε巴�� �̵�(Lerp ���)
//        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
//    }
//}
