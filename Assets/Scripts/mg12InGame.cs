using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    // 질문 클래스
    [System.Serializable]
    public class Question
    {
        public string questionText;  // 질문 텍스트
        public string correctAnswer; // 정답 텍스트
    }

    public List<Question> questions; // 질문 리스트
    public TextMeshProUGUI questionText;  // 질문을 표시할 TextMeshProUGUI
    public TMP_InputField answerInput;    // 사용자가 답을 입력할 TMP_InputField
    public Button submitButton;           // 답을 제출할 Button UI
    public TextMeshProUGUI feedbackText;  // 결과 피드백을 표시할 TextMeshProUGUI
    public GameObject closedoor;
    public GameObject opendoor;

    private int currentQuestionIndex = 0; // 현재 질문 인덱스

    void Start()
    {
        // 질문 리스트를 초기화하고 질문을 추가합니다.
        questions = new List<Question>
        {
            new Question { questionText = "how old me", correctAnswer = "21" },
            new Question { questionText = "T1", correctAnswer = "1557" }
        };
        opendoor.SetActive(false);
        // 첫 번째 질문을 표시
        DisplayQuestion();

        // 버튼에 제출 함수 연결
        submitButton.onClick.AddListener(CheckAnswer);
    }

    // 현재 질문을 UI에 표시하는 함수
    void DisplayQuestion()
    {
        // 질문을 설정하고 피드백 텍스트 초기화
        questionText.text = questions[currentQuestionIndex].questionText;
        feedbackText.text = "";

        // 답변 입력 필드를 비우고 포커스
        answerInput.text = "";
        answerInput.ActivateInputField();
    }

    // 답을 제출할 때 호출되는 함수
    void CheckAnswer()
    {
        // 사용자가 입력한 답을 소문자로 변환하여 비교 (대소문자 구분 없이 처리)
        string userAnswer = answerInput.text.ToLower().Trim();
        string correctAnswer = questions[currentQuestionIndex].correctAnswer.ToLower().Trim();

        // 정답 확인
        if (userAnswer == correctAnswer)
        {
            currentQuestionIndex++; // 다음 질문으로 넘어감

            // 모든 질문을 다 맞춘 경우
            if (currentQuestionIndex >= questions.Count)
            {
                opendoor.SetActive(true);
                closedoor.SetActive(false);
                submitButton.interactable = false; // 더 이상 답 제출 불가능
                //nextscene
            }
            else
            {
                // 다음 질문을 표시
                DisplayQuestion();
            }
        }
        else
        {
            // 오답일 경우 피드백 표시
            feedbackText.text = "try again";
        }
    }
}
