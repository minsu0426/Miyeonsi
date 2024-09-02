using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlowManager : MonoBehaviour
{
    public GameObject MainCanvasObject;
    public TMP_Text textBox;
    public TMP_Text nameBox;
    public Transform optionBox;
    public OptinoScript[] options;
    public GameObject optionPrefab;

    public Image background;
    public Image imageLeft;
    public Image imageMiddle;
    public Image imageRight;
    public Image imageFront;

    public GameObject BlinderPrefab;

    public ScenarioData scenarioData;

    Coroutine textCor;
    Coroutine optionCor;

    private string currentText;
    private bool textComplete = false;
    private bool isinMainFlow = true;

    private string replaceName = "$player";
    public string playerName = "main";

    public string mainGameSceneName = "FirstGameScene";

    //singleton pattern
    private static readonly object _lock = new object();
    private static FlowManager instance;
    public static FlowManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<FlowManager>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject("FlowManager");
                        instance = obj.AddComponent<FlowManager>();
                    }
                }
                return instance;
            }
        }
    }

    string t(string text)
    {
        return text.Replace(replaceName, playerName);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return; // 기존 인스턴스가 있는 경우, 아래 코드를 실행하지 않도록 합니다.
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene " + scene.name + " loaded.");
        if(scene.name == mainGameSceneName)
        {
            StartScenario(scenarioData);
        }
    }

    IEnumerator ShowText()
    {
        textBox.fontSize = scenarioData.fontSize;
        nameBox.text = t(scenarioData.CharacterName);
        currentText = t(scenarioData.text);
        textComplete = false;
        for(int i = 0; i < scenarioData.text.Length; i++)
        {
            textBox.text = currentText.Substring(0,i+1);
            yield return new WaitForSeconds(1/scenarioData.textSpeed);
        }
        textComplete = true;
        optionCor = StartCoroutine(ShowOptions());
    }

    /// <summary>
    /// 선택지 오브젝트를 생성하고, 데이터를 할당합니다.
    /// </summary>
    void GenerateOptions()
    {
        options = new OptinoScript[scenarioData.options.Length];
        for(int i = 0; i < scenarioData.options.Length; i++)
        {
            GameObject optionObj = Instantiate(optionPrefab, optionBox);
            options[i] = optionObj.GetComponent<OptinoScript>();
            options[i].SetSnarioData(scenarioData.options[i].optionResult);

            TMP_Text optionText = optionObj.GetComponentInChildren<TMP_Text>();
            optionText.text = t(scenarioData.options[i].optionText);
            optionText.fontSize = scenarioData.options[i].fontSize;

            optionObj.SetActive(false);
        }
    }

    public void ClickBox()
    {
        if(textComplete)
        {

            if(scenarioData.hasOption)
            {
                //
            } else {
                EndCurrentScenario(scenarioData.nextScenario);
            }
        } else {
            if (textCor!= null)
                StopCoroutine(textCor);
            textBox.text = currentText;
            textComplete = true;
            optionCor = StartCoroutine(ShowOptions());
        }
    }

    /// <summary>
    /// 선택지가 클릭되지 않도록 하고, 참조를 삭제합니다.
    /// </summary>
    public void DiscardOptions()
    {
        StopCoroutine(optionCor);
        for (int i = 0; i < options.Length; i++)
        {
            options[i].SkipFadeIn();
            if (!options[i].selected)
            {
                options[i].DelOption();
            }
            options[i].Discarded = true;
            options[i] = null;
        }
    }

    /// <summary>
    /// 페이드 아웃 효과를 주며 씬을 전환해, 메인 스토리 흐름으로 돌아갑니다.
    /// </summary>
    public void ReturnToMainFlow()
    {
        StartCoroutine(BlindAndMoveScene(mainGameSceneName, 1));
    }

    public void EndCurrentScenario(ScenarioData nextScenario)
    {
        if (scenarioData.changeScene && isinMainFlow)
        {
            isinMainFlow = false;
            StartCoroutine(BlindAndMoveScene(scenarioData.sceneName,1));
            scenarioData = nextScenario;
            return;
        }
        StartScenario(nextScenario);
    }

    public void StartScenario(ScenarioData newScenarioData)
    {
        isinMainFlow = true;

        if (newScenarioData == null) 
        {
            Debug.LogError("newScenarioData is Null");
            return;
        }

        scenarioData = newScenarioData;

        SetUIandAudio();

        textCor = StartCoroutine(ShowText());
        GenerateOptions();
    }

    public void SetUIandAudio()
    {
        if (AudioController.instance != null)
        {
            AudioController.instance.PlayAudio(scenarioData.audioClip, scenarioData.audioVolume);
        }

        if (MainCanvasObject == null)
        {
            MainCanvasObject = GameObject.Find("MainCanvas");
            if (MainCanvasObject == null)
            {
                Debug.LogError("MainCanvas is Null");
                return;
            } else {
                SetUIElement();
            }
        }

        if (scenarioData.background == null)
        {
            background.gameObject.SetActive(false);
        } else {
            background.gameObject.SetActive(true);
            background.sprite = scenarioData.background;
        }

        if (scenarioData.imageLeft==null)
        {
            imageLeft.gameObject.SetActive(false);
        } else {
            imageLeft.gameObject.SetActive(true);
            imageLeft.sprite = scenarioData.imageLeft;
        }

        if (scenarioData.imageMiddle == null)
        {
            imageMiddle.gameObject.SetActive(false);
        } else {
            imageMiddle.gameObject.SetActive(true);
            imageMiddle.sprite = scenarioData.imageMiddle;
        }

        if (scenarioData.imageRight == null)
        {
            imageRight.gameObject.SetActive(false);
        } else {
            imageRight.gameObject.SetActive(true);
            imageRight.sprite = scenarioData.imageRight;
        }

        if (scenarioData.imageFront == null)
        {
            imageFront.gameObject.SetActive(false);
        } else {
            imageFront.gameObject.SetActive(true);
            imageFront.sprite = scenarioData.imageFront;
            UIFade temp = imageFront.GetComponent<UIFade>();
            temp.FadeInCor = StartCoroutine(temp.FadeIn(0.5f));
        }
    }

    public void SetUIElement()
    {
        MainCanvasElementInfo info = MainCanvasObject.GetComponent<MainCanvasElementInfo>();
        textBox = info.textBox;
        nameBox = info.nameBox;
        optionBox = info.optionBox;
        background = info.background;
        imageLeft = info.imageLeft;
        imageMiddle = info.imageMiddle;
        imageRight = info.imageRight;
        imageFront = info.imageFront;
    }

    IEnumerator ShowOptions()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].ShowOption();
            yield return new WaitForSeconds(0.5f);
        }
    }

    public IEnumerator BlindAndMoveScene(string sceneName, float duration)
    {
        CanvasGroup blinder = Instantiate(BlinderPrefab, Vector3.zero, Quaternion.identity).GetComponent<CanvasGroup>();
        float elapsedTime = 0f;
        float t = 0f;

        while (elapsedTime < duration)
        {
            t = elapsedTime / duration;

            // UI 요소의 투명도 서서히 증가
            blinder.alpha = Mathf.Lerp(0f, 1f, t);

            // 경과 시간 증가
            elapsedTime += Time.deltaTime;

            // 다음 프레임까지 대기
            yield return null;
        }
        blinder.alpha = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
