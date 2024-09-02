using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;  // 초기 체력 값
    public int maxHealth = 5;  // 최대 체력 값
    public Image[] hearts;  // 하트 아이콘 배열
    public float timeLimit = 30f;  // 타이머 시간 (초)
    private bool gameCleared = false;  // 게임 클리어 여부
    private float timeRemaining;

    public Text timerText; // UI에 타이머를 표시할 텍스트

    void Start()
    {
        timeRemaining = timeLimit;
        UpdateHearts(); // 초기 상태에서 하트 UI 업데이트
    }

    void Update()
    {
        // 타이머 업데이트
        if (!gameCleared)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                GameClear();
            }

            // 타이머 텍스트 업데이트
            if (timerText != null)
            {
                timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        // 체력 감소에 따라 하트 아이콘을 업데이트
        UpdateHearts();

        if (health <= 0 && !gameCleared)
        {
            Debug.Log("Player Died");
            GameOver();
        }
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;  // 체력이 최대 체력을 넘지 않도록 제한
        }

        UpdateHearts();
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

    void GameClear()
    {
        gameCleared = true;
        Debug.Log("Game Cleared!");
        // 게임 클리어 처리 로직 (예: 클리어 씬으로 전환)
        SceneManager.LoadScene("GameClearScene2");

    }

    void GameOver()
    {
        // 게임 오버 처리 로직
        Debug.Log("Game Over!");
        SceneManager.LoadScene("GameOverScene2");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cake"))
        {
            Heal(1);  // 체력을 1 회복
            Destroy(other.gameObject);  // 케이크를 파괴
        }
    }
}