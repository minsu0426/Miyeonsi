using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstScene : MonoBehaviour
{
    //public Button yourButton;           // 버튼 참조

    public void OnButtonPressed()
    {
        SceneManager.LoadScene("FirstGameScene");
    }
}
