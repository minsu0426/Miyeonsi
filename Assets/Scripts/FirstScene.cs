using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstScene : MonoBehaviour
{
    //public Button yourButton;           // ��ư ����

    public void OnButtonPressed()
    {
        SceneManager.LoadScene("FirstGameScene");
    }
}
