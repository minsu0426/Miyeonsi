using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    
    [System.Serializable]
    public class Question
    {
        public string questionText; 
        public string correctAnswer; 
    }

    public List<Question> questions; 
    public TextMeshProUGUI questionText;  
    public TMP_InputField answerInput;    
    public Button submitButton;           
    public TextMeshProUGUI feedbackText;  
    public GameObject closedoor;
    public GameObject opendoor;

    private int currentQuestionIndex = 0; 

    void Start()
    {
        
        questions = new List<Question>
        {
            new Question { questionText = "신하가 왕과 헤어질 때 하는 말은?", correctAnswer = "바이킹" },
            new Question { questionText = "공이 웃으면?", correctAnswer = "풋볼" }
        };
        opendoor.SetActive(false);
        
        DisplayQuestion();

        
        submitButton.onClick.AddListener(CheckAnswer);
    }

    
    void DisplayQuestion()
    {
        
        questionText.text = questions[currentQuestionIndex].questionText;
        feedbackText.text = "";

        
        answerInput.text = "";
        answerInput.ActivateInputField();
    }

    
    void CheckAnswer()
    {
        
        string userAnswer = answerInput.text.ToLower().Trim();
        string correctAnswer = questions[currentQuestionIndex].correctAnswer.ToLower().Trim();

        
        if (userAnswer == correctAnswer)
        {
            currentQuestionIndex++; 

            
            if (currentQuestionIndex >= questions.Count)
            {
                opendoor.SetActive(true);
                closedoor.SetActive(false);
                submitButton.interactable = false; 

                End();
            }
            else
            {
                
                DisplayQuestion();
            }
        }
        else
        {
            
            feedbackText.text = "try again";
        }
    }

    public void End()
    {
        SceneManager.LoadScene(FlowManager.Instance.mainGameSceneName);
    }
}
