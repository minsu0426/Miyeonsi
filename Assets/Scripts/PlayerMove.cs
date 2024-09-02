using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // ������ �̵� �ӵ�

    void Update()
    {
        // �Է� �� �޾ƿ��� (WASD Ű �Ǵ� ȭ��ǥ Ű)
        float moveX = Input.GetAxis("Horizontal"); // ���� �̵� �Է� (A, D �Ǵ� ȭ��ǥ ��, ��)
        float moveY = Input.GetAxis("Vertical");   // ���� �̵� �Է� (W, S �Ǵ� ȭ��ǥ ��, �Ʒ�)

        // �̵� ���� ���
        Vector2 movement = new Vector2(moveX, moveY).normalized;

        // ������ �ӵ��� ĳ���� �̵�
        transform.Translate(movement * speed * Time.deltaTime);
    }
}