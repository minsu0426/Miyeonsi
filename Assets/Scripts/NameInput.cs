using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameInput : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public Button submitButton;

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmitName);
    }

    void OnSubmitName()
    {
        string playerName = nameInputField.text;
        PlayerData.instance.SetPlayerName(playerName);
        // 플레이어 이름 입력 후 게임의 다른 부분으로 넘어가는 로직을 추가
    }
}
