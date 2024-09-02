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
        FlowManager.Instance.playerName = playerName;
        // �÷��̾� �̸� �Է� �� ������ �ٸ� �κ����� �Ѿ�� ������ �߰�
    }
}
