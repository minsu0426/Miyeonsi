using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class BombDefuse : MonoBehaviour
{
    public Button[] buttons;
    public int[] correctSequence;
    private int currentStep = 0;
    public float timeLimit = 0;
    private float timeRemaining;
    private bool defused = false;
    public Text timerText;
    public GameObject gameOverSereen;
    public GameObject successScreen;
    void Start()
    {
        timeRemaining = timeLimit;
        UpdateTimerText();
    }

    void Update()
    {
        if(!defused)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        if(timeRemaining <= 0)
        {
            GameOver();
        }
    }

    public void OnButtonPress(int buttonIndex)
    {
        if(!defused && timeRemaining > 0)
        {
            if (correctSequence[currentStep] == buttonIndex)
            {
                currentStep++;

                if(currentStep >= correctSequence.Length)
                {
                    DefuseBomb();
                }
            }
        }
        else
        {
            GameOver();
        }
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Max(timeRemaining, 0).ToString("F2");
    }

    void GameOver()
    {
        defused = true;
        gameOverSereen.SetActive(true);
    }

    void DefuseBomb()
    {
        defused = true;
        successScreen.SetActive(true);
    }
}
