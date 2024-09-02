using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text ChatText;                 
    public string[] dialogues;            
    private int currentDialogueIndex;       
    public float textSpeed = 0.1f;
    private void Start()
    {
        currentDialogueIndex = 0;
        StartCoroutine(DisplayDialogue());
    }

    IEnumerator DisplayDialogue()
    {
        while (currentDialogueIndex < dialogues.Length)
        {
            // ���� ��縦 ǥ��
            yield return StartCoroutine(NormalChat(dialogues[currentDialogueIndex]));

            // Ŭ�� �Է��� ���
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            // ���� ���� �̵�
            currentDialogueIndex++;
        }

        // ��� ��簡 ���� ��, �ʿ信 ���� �߰����� ������ ������ �� �ֽ��ϴ�.
        // ��: ���� ����, �� ��ȯ ��
    }

    IEnumerator NormalChat(string narration)
    {
        string displayedText = "";              // ��� �ؽ�Ʈ �ʱ�ȭ

        for (int i = 0; i < narration.Length; i++)
        {
            displayedText += narration[i];      // �� ���ھ� �߰�
            ChatText.text = displayedText;      // UI�� ǥ��
            yield return new WaitForSeconds(textSpeed);                  // ������ ���
        }

        // ��簡 ������ ǥ�õ� ������ ���
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;                  // Ŭ�� �Է� ���
        }
    }
}
