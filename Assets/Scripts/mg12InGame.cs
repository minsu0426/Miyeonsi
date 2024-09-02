using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    // ���� Ŭ����
    [System.Serializable]
    public class Question
    {
        public string questionText;  // ���� �ؽ�Ʈ
        public string correctAnswer; // ���� �ؽ�Ʈ
    }

    public List<Question> questions; // ���� ����Ʈ
    public TextMeshProUGUI questionText;  // ������ ǥ���� TextMeshProUGUI
    public TMP_InputField answerInput;    // ����ڰ� ���� �Է��� TMP_InputField
    public Button submitButton;           // ���� ������ Button UI
    public TextMeshProUGUI feedbackText;  // ��� �ǵ���� ǥ���� TextMeshProUGUI
    public GameObject closedoor;
    public GameObject opendoor;

    private int currentQuestionIndex = 0; // ���� ���� �ε���

    void Start()
    {
        // ���� ����Ʈ�� �ʱ�ȭ�ϰ� ������ �߰��մϴ�.
        questions = new List<Question>
        {
            new Question { questionText = "�ѱ�", correctAnswer = "god" },
            new Question { questionText = "1+2", correctAnswer = "3" }
        };
        opendoor.SetActive(false);
        // ù ��° ������ ǥ��
        DisplayQuestion();

        // ��ư�� ���� �Լ� ����
        submitButton.onClick.AddListener(CheckAnswer);
    }

    // ���� ������ UI�� ǥ���ϴ� �Լ�
    void DisplayQuestion()
    {
        // ������ �����ϰ� �ǵ�� �ؽ�Ʈ �ʱ�ȭ
        questionText.text = questions[currentQuestionIndex].questionText;
        feedbackText.text = "";

        // �亯 �Է� �ʵ带 ���� ��Ŀ��
        answerInput.text = "";
        answerInput.ActivateInputField();
    }

    // ���� ������ �� ȣ��Ǵ� �Լ�
    void CheckAnswer()
    {
        // ����ڰ� �Է��� ���� �ҹ��ڷ� ��ȯ�Ͽ� �� (��ҹ��� ���� ���� ó��)
        string userAnswer = answerInput.text.ToLower().Trim();
        string correctAnswer = questions[currentQuestionIndex].correctAnswer.ToLower().Trim();

        // ���� Ȯ��
        if (userAnswer == correctAnswer)
        {
            currentQuestionIndex++; // ���� �������� �Ѿ

            // ��� ������ �� ���� ���
            if (currentQuestionIndex >= questions.Count)
            {
                opendoor.SetActive(true);
                closedoor.SetActive(false);
                submitButton.interactable = false; // �� �̻� �� ���� �Ұ���
                End();
            }
            else
            {
                // ���� ������ ǥ��
                DisplayQuestion();
            }
        }
        else
        {
            // ������ ��� �ǵ�� ǥ��
            feedbackText.text = "try again";
        }
    }

    public void End()
    {
        SceneManager.LoadScene(FlowManager.Instance.mainGameSceneName);
    }
}
