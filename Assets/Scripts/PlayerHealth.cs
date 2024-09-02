using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3; // 플레이어의 초기 체력

    // 체력을 감소시키는 메서드
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            // 체력이 0 이하가 되면 플레이어가 죽는 로직 (예: 게임 오버 처리)
            Debug.Log("Player Died");
        }
    }
}