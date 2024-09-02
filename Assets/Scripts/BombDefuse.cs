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
    private float timeRemaining;
    private bool defused = false;
    private bool flag = false;
    public Text timerText;
    public GameObject gameOverSereen;
    public GameObject successScreen;
    void Start()
    {
        timeRemaining = 30f;
        UpdateTimerText();
        int Sequence_Rage = Random.Range(4,6);
        correctSequence = new int[Sequence_Rage];

        for(int i = 0; i<Sequence_Rage; i++)
        {
            correctSequence[i] = Random.Range(1, 9);
            Debug.Log(correctSequence[i]);
        }
    }

    void Update()
    {
        if (!flag)
        {
            if (!defused)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            if (timeRemaining <= 0)
            {
                flag = true;
                GameOver();
            }
        }
    }

    public void OnButtonPress(int buttonIndex)
    {
        if (!defused && timeRemaining > 0)
        {
            if (correctSequence[currentStep] == buttonIndex)
            {
                currentStep++;

                if (currentStep >= correctSequence.Length)
                {
                    DefuseBomb();
                }
            }
        }
        else
        {
             GameOver();
            timeRemaining = 0;
        }
    }

    void UpdateTimerText()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        Debug.Log("Game Over");
       // gameOverSereen.SetActive(true);
    }
    
     void DefuseBomb()
    {
        defused = true;
        Debug.Log("Defused");
        //successScreen.SetActive(true);
    }
}
