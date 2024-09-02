using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NewScenarioData", menuName = "ScenarioData", order = 51)]
public class ScenarioData : ScriptableObject
{
    [Header("기본 텍스트설정")]
    [Multiline(3)]
    public string text;
    public float fontSize;
    public float textSpeed;

    [Header("선택지 여부")]
    public bool hasOption;
    public TMP_Text[] optionTmp;
    public string[] optionText;
    public ScenarioData[] optionResult;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
