using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;  // 초기 체력 값
    public Image[] hearts;  // 하트 아이콘 배열

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        // 체력 감소에 따라 하트 아이콘을 업데이트
        UpdateHearts();

        if (health <= 0)
        {
            Debug.Log("Player Died");
           
        }
    }

    void UpdateHearts()
    {
        // 현재 체력 상태에 맞춰 하트 아이콘을 업데이트
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;  // 체력이 남아있는 경우 하트 표시
            }
            else
            {
                hearts[i].enabled = false;  // 체력이 없는 경우 하트 숨기기
            }
        }
    }

    
}