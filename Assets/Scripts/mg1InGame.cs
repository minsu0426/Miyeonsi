using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class mg1InGame : MonoBehaviour
{
    // Start is called before the first frame update
    int myNum;
    int myNum3;
    public int myNum2;
    public GameObject door;
    public TextMeshProUGUI numTxt;
    public GameObject kwang;
    void Start()
    {
        Debug.Log("HelloWorld!!");
        myNum2 = 30;
        kwang.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Click()
    {
        Debug.Log("Click!!");
        myNum++;
        myNum3++;

        if (myNum >= myNum2)
        {
            kwang.SetActive(true);
            door.SetActive(false);
        }

        if (myNum3 >= 50)
        {
            SceneManager.LoadScene(FlowManager.Instance.mainGameSceneName);
        }

    }
}
