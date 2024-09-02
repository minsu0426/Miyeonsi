using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NameInput : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public Button submitButton;

    void Start()
    {
        submitButton.interactable = false;

        nameInputField.onValueChanged.AddListener(OnNameInputChanged);

        submitButton.onClick.AddListener(OnSubmitName);
    }

    void OnNameInputChanged(string input)
    {
        string trimmedInput = input.Replace(" ", "");

        nameInputField.text = trimmedInput;

        submitButton.interactable = !string.IsNullOrEmpty(input);
    }

    void OnSubmitName()
    {
        string playerName = nameInputField.text;
        PlayerData.instance.SetPlayerName(playerName);
        // 플레이어 이름 입력 후 게임의 다른 부분으로 넘어가는 로직을 추가
    }
}
