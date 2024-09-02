using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToPrologue : MonoBehaviour
{
    public void OnButtonPressed()
    {
        SceneManager.LoadScene("Prologue");
    }
}
