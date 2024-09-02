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
        // �÷��̾� �̸� �Է� �� ������ �ٸ� �κ����� �Ѿ�� ������ �߰�
    }
}
