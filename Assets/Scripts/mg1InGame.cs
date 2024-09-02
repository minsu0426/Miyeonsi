using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mg1InGame : MonoBehaviour
{
    // Start is called before the first frame update
    int myNum;
    public int myNum2;
    public GameObject door;
    public TextMeshProUGUI numTxt;

    void Start()
    {
        Debug.Log("HelloWorld!!");
        myNum2 = 20;
        numTxt.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Click()
    {
        Debug.Log("Äç");
        myNum++;
        Debug.Log("myNum: " + myNum);
        numTxt.text = myNum.ToString();

        if(myNum == myNum2)
        {
            //´ÙÀ½¾ÀÀ¸·Î ÀüÈ¯
        }
        
    }
}
