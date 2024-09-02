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
            // 현재 대사를 표시
            yield return StartCoroutine(NormalChat(dialogues[currentDialogueIndex]));

            // 클릭 입력을 대기
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            // 다음 대사로 이동
            currentDialogueIndex++;
        }

        // 모든 대사가 끝난 후, 필요에 따라 추가적인 로직을 삽입할 수 있습니다.
        // 예: 게임 진행, 씬 전환 등
    }

    IEnumerator NormalChat(string narration)
    {
        string displayedText = "";              // 대사 텍스트 초기화

        for (int i = 0; i < narration.Length; i++)
        {
            displayedText += narration[i];      // 한 글자씩 추가
            ChatText.text = displayedText;      // UI에 표시
            yield return new WaitForSeconds(textSpeed);                  // 프레임 대기
        }

        // 대사가 완전히 표시될 때까지 대기
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;                  // 클릭 입력 대기
        }
    }
}
