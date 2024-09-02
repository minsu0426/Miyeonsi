using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;  // 초기 체력 값

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            Debug.Log("Player Died");
            GameOver();
        }
    }

    void GameOver()
    {
        // 게임 종료
        Debug.Log("Game Over!");
      
    }
}