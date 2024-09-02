using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Minigame3SoundManager : MonoBehaviour
{
    public Button[] buttons;
    public AudioSource audioSource;

    void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(PlaySound);
        }
    }


    void Update()
    {
        
    }

    void PlaySound()
    {
        audioSource.Play();
    }
}
