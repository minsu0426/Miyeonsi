using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 랜덤한 방향으로 발사
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.velocity = randomDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어에게 피해를 입히되, 물리적 영향을 주지 않음
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }

           
        }
         
    }
}