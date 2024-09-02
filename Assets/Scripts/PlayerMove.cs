using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // 일정한 이동 속도

    void Update()
    {
        // 입력 값 받아오기 (WASD 키 또는 화살표 키)
        float moveX = Input.GetAxis("Horizontal"); // 수평 이동 입력 (A, D 또는 화살표 좌, 우)
        float moveY = Input.GetAxis("Vertical");   // 수직 이동 입력 (W, S 또는 화살표 위, 아래)

        // 이동 벡터 계산
        Vector2 movement = new Vector2(moveX, moveY).normalized;

        // 일정한 속도로 캐릭터 이동
        transform.Translate(movement * speed * Time.deltaTime);
    }
}