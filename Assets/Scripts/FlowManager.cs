using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowManager : MonoBehaviour
{
    public TMP_Text textBox;
    public Transform optionBox;
    [HideInInspector]
    public OptinoScript[] options;
    public GameObject optionPrefab;

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
        if (instance!= this)
        {
            Destroy(gameObject);
            return;
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        StartScenario(scenarioData);
    }

    void Update()
    {
        
    }
    
    IEnumerator ShowText()
    {
        textBox.fontSize = scenarioData.fontSize;
        currentText = scenarioData.text;
        textComplete = false;
        for(int i = 0; i < scenarioData.text.Length; i++)
        {
            textBox.text = currentText.Substring(0,i+1);
            yield return new WaitForSeconds(1/scenarioData.textSpeed);
        }
        textComplete = true;
    }

    void GenerateOptions()
    {
        for(int i = 0; i < scenarioData.options.Length; i++)
        {
            GameObject optionObj = Instantiate(optionPrefab, optionBox);
            TMP_Text optionText = optionObj.GetComponentInChildren<TMP_Text>();
            optionText.text = scenarioData.options[i].optionText;
            options[i] = optionObj.GetComponent<OptinoScript>();
            options[i].SetSnarioData(scenarioData.options[i].optionResult);
        }
    }

    void ClickBox()
    {
        if(textComplete)
        {
            if(scenarioData.hasOption)
            {
                optionCor = StartCoroutine(ShowOptions());
            } else {
                StartScenario(scenarioData.nextScenario);
            }
        } else {
            StopCoroutine(textCor);
            textBox.text = currentText;
            textComplete = true;
        }
    }

    public void SellectOption(OptinoScript selectedOption)
    {
        for (int i = 0; i < options.Length; i++)
        {
            if(options[i] == selectedOption)
            {
                // pass
            } else {
                options[i].DelOption();
            }
        }
        StartScenario(selectedOption.scenarioData);
    }

    void StartScenario(ScenarioData newScenarioData)
    {
        scenarioData = newScenarioData;
        textCor = StartCoroutine(ShowText());
        GenerateOptions();
    }

    IEnumerator ShowOptions()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
