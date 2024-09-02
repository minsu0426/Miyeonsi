using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3; // �÷��̾��� �ʱ� ü��

    // ü���� ���ҽ�Ű�� �޼���
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            // ü���� 0 ���ϰ� �Ǹ� �÷��̾ �״� ���� (��: ���� ���� ó��)
            Debug.Log("Player Died");
        }
    }
}