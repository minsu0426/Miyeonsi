using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptinoScript : MonoBehaviour
{
    public ScenarioData scenarioData;
    public bool Discarded = false;
    public bool selected = false;
    public RectTransform rectTransform;
    public CanvasGroup canvasGroup;

    Coroutine FadeInCor;
    Coroutine FadeOutCor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSnarioData(ScenarioData newData)
    {
        scenarioData = newData;
    }

    public void SellectOption()
    {
        if (Discarded) return;
        selected = true;
        FlowManager.Instance.DiscardOptions();
        FadeOutCor = StartCoroutine(MoveAndFadeOut(0.5f,0.25f));
    }

    public void SkipFadeIn()
    {
        if(FadeInCor!= null)
            StopCoroutine(FadeInCor);
    }

    public void ShowOption()
    {
        gameObject.SetActive(true);
        canvasGroup = GetComponent<CanvasGroup>();
        FadeInCor = StartCoroutine(FadeIn(0.25f));
    }

    public void DelOption()
    {
        StartCoroutine(MoveAndFadeOut(0,0.25f));
    }

    public IEnumerator FadeIn(float duration)
    {
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

    IEnumerator MoveAndFadeOut(float delay, float duration)
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 targetPosition = new Vector2(rectTransform.anchoredPosition.x+100, rectTransform.anchoredPosition.y);
        float elapsedTime = 0f;
        float t = 0f;

        while (elapsedTime < delay+duration)
        {
            // 시간 경과에 따른 비율 계산
            if (elapsedTime > delay)
                t = (elapsedTime-delay) / duration;

            // UI 요소의 위치를 서서히 이동
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);

            // UI 요소의 투명도 서서히 감소
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);

            // 경과 시간 증가
            elapsedTime += Time.deltaTime;

            // 다음 프레임까지 대기
            yield return null;
        }

        // 최종 위치와 투명도 설정
        rectTransform.anchoredPosition = targetPosition;
        canvasGroup.alpha = 0f;
        if (selected)
            FlowManager.Instance.StartScenario(scenarioData);
        Destroy(gameObject);
    }
}
