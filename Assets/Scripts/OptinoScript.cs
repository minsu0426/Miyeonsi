using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptinoScript : MonoBehaviour
{
    public ScenarioData scenarioData;
    public bool Discarded = false;

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
        FlowManager.Instance.SellectOption(this);
        Destroy(gameObject);
    }

    public void DelOption()
    {
        Destroy(gameObject);
    }
}
