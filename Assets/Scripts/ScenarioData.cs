using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public class Option
{
    public string optionText;
    public float fontSize = 30;
    public ScenarioData optionResult;
}

[CreateAssetMenu(fileName = "NewScenarioData", menuName = "ScenarioData", order = 51)]
public class ScenarioData : ScriptableObject
{
    [Header("기본 텍스트설정")]
    [Multiline(3)]
    public string text;
    public float fontSize = 30;
    public float textSpeed = 10;

    [Header("선택지 여부")]
    public bool hasOption;
    public ScenarioData nextScenario;
    public Option[] options;
}
