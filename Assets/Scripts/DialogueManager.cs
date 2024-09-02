using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text ChatText;                 // ��縦 ǥ���� UI ���
    public string[] dialogues;                // ��� �迭
    public float textSpeed = 0.05f;           // �� ���ھ� ��µǴ� �ð� ���� (�� ����)
    public int currentDialogueIndex;         // ���� ��� �ε���

    public FirstScene firstScene;

    public Image targetImage;                 // ������ �̹��� UI ���
    public Sprite newSprite;                  // ��� �ε����� Ư�� ���� �� ǥ���� �� �̹���
    public int imageChangeDialogueIndex = 1;  // �̹����� ������ ��� �ε���

    private void Start()
    {
        currentDialogueIndex = 0;              // ��� �ε��� �ʱ�ȭ
        StartCoroutine(DisplayDialogue());     // ��� ǥ�� �ڷ�ƾ ����
    }

    IEnumerator DisplayDialogue()
    {
        while (currentDialogueIndex < dialogues.Length)
        {
            // ���� ��縦 ǥ��
            yield return StartCoroutine(NormalChat(dialogues[currentDialogueIndex]));

            // �̹��� ����
            if (currentDialogueIndex == imageChangeDialogueIndex)
            {
                ChangeImage();
            }

            // Ŭ�� �Է��� ���
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            // ���� ���� �̵�
            currentDialogueIndex++;
        }

        // ��� ��簡 ���� ��, �ʿ信 ���� �߰����� ������ ������ �� �ֽ��ϴ�.
    }

    IEnumerator NormalChat(string narration)
    {
        string displayedText = "";              // ��� �ؽ�Ʈ �ʱ�ȭ

        for (int i = 0; i < narration.Length; i++)
        {
            displayedText += narration[i];      // �� ���ھ� �߰�
            ChatText.text = displayedText;      // UI�� ǥ��
            yield return new WaitForSeconds(textSpeed); // ���� ��� �ӵ� ����
        }

        // ��簡 ������ ǥ�õ� ������ ���
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;                  // Ŭ�� �Է� ���
        }
    }

    private void ChangeImage()
    {
        if (targetImage != null && newSprite != null)
        {
            targetImage.sprite = newSprite;    // �̹����� �� �̹����� ����
        }
    }
}
