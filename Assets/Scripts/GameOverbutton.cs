using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public string gameSceneName = "MainGameScene";  // ���� ���� ���� �̸�

    public void Retry()
    {
        // ���� ���� ���� �ٽ� �ε�
        SceneManager.LoadScene("Mini game 2");
    }

}
