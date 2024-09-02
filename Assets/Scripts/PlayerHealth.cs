using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;  // �ʱ� ü�� ��

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
        // ���� ����
        Debug.Log("Game Over!");
      
    }
}