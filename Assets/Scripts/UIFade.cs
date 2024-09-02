using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public Coroutine FadeInCor;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeIn(float duration)
    {
        canvasGroup = GetComponent<CanvasGroup>();
        float elapsedTime = 0f;
        float t = 0f;

        while (elapsedTime < duration)
        {
            t = elapsedTime / duration;

            // UI 요소의 투명도 서서히 증가
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, t);

            // 경과 시간 증가
            elapsedTime += Time.deltaTime;

            // 다음 프레임까지 대기
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }

    public IEnumerator FadeOut(float duration)
    {
        float elapsedTime = 0f;
        float t = 0f;

        while (elapsedTime < duration)
        {
            t = elapsedTime / duration;

            // UI 요소의 투명도 서서히 증가
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);

            // 경과 시간 증가
            elapsedTime += Time.deltaTime;

            // 다음 프레임까지 대기
            yield return null;
        }
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }

    public void Click()
    {
        if (FadeInCor != null)
            StopCoroutine(FadeInCor);
        StartCoroutine(FadeOut(0.5f));
    }
}
