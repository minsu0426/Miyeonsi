using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;  // �ʱ� ü�� ��
    public Image[] hearts;  // ��Ʈ ������ �迭

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        // ü�� ���ҿ� ���� ��Ʈ �������� ������Ʈ
        UpdateHearts();

        if (health <= 0)
        {
            Debug.Log("Player Died");
           
        }
    }

    void UpdateHearts()
    {
        // ���� ü�� ���¿� ���� ��Ʈ �������� ������Ʈ
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;  // ü���� �����ִ� ��� ��Ʈ ǥ��
            }
            else
            {
                hearts[i].enabled = false;  // ü���� ���� ��� ��Ʈ �����
            }
        }
    }

    
}