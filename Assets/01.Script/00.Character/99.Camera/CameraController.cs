//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CameraController : MonoBehaviour
//{
//    public Transform character; // 캐릭터 Transform
//    public LayerMask obstacleLayer; // 장애물 레이어 (감지할 레이어 설정)
//    public float smoothSpeed = 5f; // 카메라 이동 속도
//    public float cameraOffsetDistance = 0.5f; // 물체 앞에서 유지할 거리

//    private Vector3 originalPosition; // 카메라의 원래 위치 저장
//    private bool isObstacleDetected = false; // 장애물 감지 여부
//    private Vector3 desiredPosition; // 목표 위치

//    private void Start()
//    {
//        카메라의 초기 위치 저장
//        originalPosition = transform.position;
//        desiredPosition = originalPosition;
//    }

//    private void LateUpdate()
//    {
//        카메라와 캐릭터 사이의 방향 계산
//       Vector3 directionToCharacter = character.position - transform.position;
//        RaycastHit hit;

//        레이캐스트로 장애물 감지(장애물 레이어만 감지)
//        if (Physics.Raycast(character.position, -directionToCharacter.normalized, out hit, directionToCharacter.magnitude, obstacleLayer))
//        {
//            장애물이 있으면 카메라를 물체의 앞쪽으로 이동
//            Vector3 hitPoint = hit.point; // 물체와 충돌한 지점
//            Vector3 moveDirection = (character.position - hitPoint).normalized; // 물체 앞쪽으로 이동할 방향
//            desiredPosition = hitPoint - moveDirection * cameraOffsetDistance; // 장애물 앞쪽으로 카메라 위치 조정
//            isObstacleDetected = true;
//        }
//        else
//        {
//            장애물이 없으면 다시 원래 위치로 복귀
//            if (isObstacleDetected)
//            {
//                desiredPosition = originalPosition; // 원래 위치로 돌아가게 설정
//                isObstacleDetected = false;
//            }
//        }

//        카메라를 부드럽게 이동(Lerp 사용)
//        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
//    }
//}
