using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class mg1InGame : MonoBehaviour
{
    // Start is called before the first frame update
    int myNum;
    public int myNum2;
    public GameObject door;
    public TextMeshProUGUI numTxt;
    public GameObject kwang;
    void Start()
    {
        Debug.Log("HelloWorld!!");
        myNum2 = 50;
        numTxt.text = "0";
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
        Debug.Log("myNum: " + myNum);
        numTxt.text = myNum.ToString();
        

        if (myNum == myNum2)
        {
            kwang.SetActive(true);
            //¥Ÿ¿Ωæ¿¿∏∑Œ
        }
       

    }
}
