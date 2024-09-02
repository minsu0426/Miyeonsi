using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditScroll : MonoBehaviour
{
    public float scrollSpeed = 20f; // 스크롤 속도
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // 텍스트의 RectTransform 가져오기
    }

    void Update()
    {
        // 텍스트를 위로 스크롤
        rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
}
