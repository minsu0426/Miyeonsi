using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditScroll : MonoBehaviour
{
    public float scrollSpeed = 20f; // ��ũ�� �ӵ�
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // �ؽ�Ʈ�� RectTransform ��������
    }

    void Update()
    {
        // �ؽ�Ʈ�� ���� ��ũ��
        rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
}
