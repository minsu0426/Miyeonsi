using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public string gameSceneName = "MainGameScene";  // 이전 게임 씬의 이름

    public void Retry()
    {
        // 이전 게임 씬을 다시 로드
        SceneManager.LoadScene("Mini game 2");
    }

}
