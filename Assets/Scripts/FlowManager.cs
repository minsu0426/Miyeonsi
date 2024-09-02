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

    public ScenarioData scenarioData;

    Coroutine textCor;
    Coroutine optionCor;

    private string currentText;
    private bool textComplete = false;

    //singleton pattern
    private static FlowManager instance;
    public static FlowManager Instance
    {
        get
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

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } else {
            if (this!= instance)
                Destroy(gameObject);
        }
    }

    void Start()
    {
        StartScenario(scenarioData);
    }
    
    IEnumerator ShowText()
    {
        textBox.fontSize = scenarioData.fontSize;
        nameBox.text = scenarioData.CharacterName;
        currentText = scenarioData.text;
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
            optionText.text = scenarioData.options[i].optionText;
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
                StartScenario(scenarioData.nextScenario);
            }
        } else {
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

    public void StartScenario(ScenarioData newScenarioData)
    {
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
        scenarioData = newScenarioData;

        if (scenarioData.background== null)
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

        textCor = StartCoroutine(ShowText());
        GenerateOptions();
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
    }

    IEnumerator ShowOptions()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].ShowOption();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
