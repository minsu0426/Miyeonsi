using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text ChatText;                 // 대사를 표시할 UI 요소
    public string[] dialogues;                // 대사 배열
    public float textSpeed = 0.05f;           // 한 글자씩 출력되는 시간 지연 (초 단위)
    public int currentDialogueIndex;         // 현재 대사 인덱스

    public FirstScene firstScene;

    public Image targetImage;                 // 변경할 이미지 UI 요소
    public Sprite newSprite;                  // 대사 인덱스가 특정 값일 때 표시할 새 이미지
    public int imageChangeDialogueIndex = 1;  // 이미지를 변경할 대사 인덱스

    private void Start()
    {
        currentDialogueIndex = 0;              // 대사 인덱스 초기화
        StartCoroutine(DisplayDialogue());     // 대사 표시 코루틴 시작
    }

    IEnumerator DisplayDialogue()
    {
        while (currentDialogueIndex < dialogues.Length)
        {
            // 현재 대사를 표시
            yield return StartCoroutine(NormalChat(dialogues[currentDialogueIndex]));

            // 이미지 변경
            if (currentDialogueIndex == imageChangeDialogueIndex)
            {
                ChangeImage();
            }

            // 클릭 입력을 대기
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            // 다음 대사로 이동
            currentDialogueIndex++;
        }

        // 모든 대사가 끝난 후, 필요에 따라 추가적인 로직을 삽입할 수 있습니다.
    }

    IEnumerator NormalChat(string narration)
    {
        string displayedText = "";              // 대사 텍스트 초기화

        for (int i = 0; i < narration.Length; i++)
        {
            displayedText += narration[i];      // 한 글자씩 추가
            ChatText.text = displayedText;      // UI에 표시
            yield return new WaitForSeconds(textSpeed); // 글자 출력 속도 조절
        }

        // 대사가 완전히 표시될 때까지 대기
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;                  // 클릭 입력 대기
        }
    }

    private void ChangeImage()
    {
        if (targetImage != null && newSprite != null)
        {
            targetImage.sprite = newSprite;    // 이미지를 새 이미지로 변경
        }
    }
}
