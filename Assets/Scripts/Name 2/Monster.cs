using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // enemy 관련 내용, 이동경로 관련 내용
    [SerializeField] public float hp = 0.0f; // 체력
    private int wayPointCount; // 이동경로 개수
    private Transform[] wayPoints; // 이동경로 정보
    private int currentIndex = 0; // 현재 목표지점 인덱스
    private Movement2D movement2D; // 오브젝트 이동제어

    public void Setup(Transform[] wayPoins)
    {
        movement2D = GetComponent<Movement2D>();

        //적 이동결로 WayPoints 정보 설정
        wayPointCount = wayPoins.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoins;

        // 적의 위치를 첫번째 wayPoint로 설정
        transform.position = wayPoints[currentIndex].position;

        //적 이동 목표지점 설정 함수 시작
        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        // 다음 이동 설정
        NextMoveTo();

        while (true)
        {
            //transform.Rotate(Vector3.forward * 10);
            
            // 한 프레임에 0.02f보다 크게 움직이기 때문에 if조건문에 걸리지 않고 경로 탈주하는 것 방지
            if(Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.01f * movement2D.MoveSpeed)
            {
                NextMoveTo();   // 다음 이동 설정
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        // 이동할 wayPoint가 남아있을때
        if(currentIndex < wayPointCount - 1) 
        {
            // enemy위치를 목표 위치로 설정
            transform.position = wayPoints[currentIndex].position;
            // 이동 방향 설정 
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        // 마지막 wayPoint 일때
        else
        {
            currentIndex = 0;
            NextMoveTo();
            // enemy 삭제
            //Destroy(gameObject);
        }
    }
}
