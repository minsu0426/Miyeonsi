using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;
using Random = UnityEngine.Random;

public class BombDefuse : MonoBehaviour
{
    public int[] correctSequence;
    private int currentStep = 0;
    private float timeRemaining;
    private bool defused = false;
    private int Sequence_Rage;
    private bool flag = false;
    public Text timerText;
    public Button[] buttons;
    public Color blinkColor = Color.yellow;
    public float blinkDuration = 0.5f;
    public float delayBetweenBlinks = 0.5f;
    public float startDelay = 2f;
    private Color[] originalColors;
    public Image redLamp;
    public Image greenLamp;

    public ScenarioData success;
    public ScenarioData failure;

    void Start()
    {
        timeRemaining = 31f;
        UpdateTimerText();
        Sequence_Rage = 8;
        correctSequence = new int[Sequence_Rage];
        originalColors = new Color[9];

        for (int i = 0; i<Sequence_Rage; i++)
        {
            correctSequence[i] = Random.Range(0, 9);
            Debug.Log(correctSequence[i]);
            
        }
        for (int i = 0; i < 9; i++)
        {
            originalColors[i] = buttons[i].GetComponent<Image>().color;
        }

        ReSetLamps();
        StartCoroutine(ShowSequence());
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
        ReSetLamps();

        if (!defused && timeRemaining > 0)
        {
            if (correctSequence[currentStep] == buttonIndex)
            {
                currentStep++;
                StartCoroutine(BlinkLamp(greenLamp));

                if (currentStep >= correctSequence.Length)
                {
                    DefuseBomb();
                }
            }
            else
            {
                StartCoroutine(BlinkLamp(redLamp));
                currentStep = 0;
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
        FlowManager.Instance.scenarioData = failure;
        FlowManager.Instance.ReturnToMainFlow();
    }
    
     void DefuseBomb()
    {
        defused = true;
        Debug.Log("Defused");
        FlowManager.Instance.scenarioData = success;
        FlowManager.Instance.ReturnToMainFlow();
    }

    IEnumerator ShowSequence()
    {
        yield return new WaitForSeconds(startDelay);

        for (int i = 0; i < Sequence_Rage; i++)
        {
            int index = correctSequence[i];
            StartCoroutine(BlinkButton(buttons[index]));
            yield return new WaitForSeconds(blinkDuration + delayBetweenBlinks);
        }
    }

    IEnumerator BlinkButton(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();
        buttonImage.color = blinkColor;
        yield return new WaitForSeconds(blinkDuration);
        buttonImage.color = originalColors[Array.IndexOf(buttons, button)];
    }

    void ReSetLamps()
    {
        Color redColor = redLamp.color;
        redColor.a = 0;
        redLamp.color = redColor;

        Color greenColor = greenLamp.color;
        greenColor.a = 0;
        greenLamp.color = greenColor;
    }
    
    IEnumerator BlinkLamp(Image lamp)
    {
        Color lampColor = lamp.color;
        lampColor.a = 1;
        lamp.color = lampColor;

        yield return new WaitForSeconds(blinkDuration);

        lampColor.a = 0;
        lamp.color = lampColor;
    }
}
