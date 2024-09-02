using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;  // �ʱ� ü�� ��
    public int maxHealth = 5;  // �ִ� ü�� ��
    public Image[] hearts;  // ��Ʈ ������ �迭
    public float timeLimit = 30f;  // Ÿ�̸� �ð� (��)
    private bool gameCleared = false;  // ���� Ŭ���� ����
    private float timeRemaining;

    public Text timerText; // UI�� Ÿ�̸Ӹ� ǥ���� �ؽ�Ʈ

    void Start()
    {
        timeRemaining = timeLimit;
        UpdateHearts(); // �ʱ� ���¿��� ��Ʈ UI ������Ʈ
    }

    void Update()
    {
        // Ÿ�̸� ������Ʈ
        if (!gameCleared)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                GameClear();
            }

            // Ÿ�̸� �ؽ�Ʈ ������Ʈ
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

        // ü�� ���ҿ� ���� ��Ʈ �������� ������Ʈ
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
            health = maxHealth;  // ü���� �ִ� ü���� ���� �ʵ��� ����
        }

        UpdateHearts();
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

    void GameClear()
    {
        gameCleared = true;
        Debug.Log("Game Cleared!");
        // ���� Ŭ���� ó�� ���� (��: Ŭ���� ������ ��ȯ)
        SceneManager.LoadScene(FlowManager.Instance.mainGameSceneName);

    }

    void GameOver()
    {
        // ���� ���� ó�� ����
        Debug.Log("Game Over!");
        SceneManager.LoadScene("GameOverScene2");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cake"))
        {
            Heal(1);  // ü���� 1 ȸ��
            Destroy(other.gameObject);  // ����ũ�� �ı�
        }
    }
}