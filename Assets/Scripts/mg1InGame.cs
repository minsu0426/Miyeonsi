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
    public int myNum2;
    public GameObject door;
    public TextMeshProUGUI numTxt;
    public GameObject kwang;
    public AudioSource audioSource;
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
        audioSource.Play();


        if (myNum == myNum2)
        {
            kwang.SetActive(true);
            door.SetActive(false);
        }

        if (myNum == 50)
        {
            FlowManager.Instance.ReturnToMainFlow();
            //StartCoroutine(FlowManager.Instance.BlindAndMoveScene(FlowManager.Instance.mainGameSceneName, 1));
        }

    }

}
