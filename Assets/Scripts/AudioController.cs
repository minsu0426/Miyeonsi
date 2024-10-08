using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    public static AudioController instance;

    void Awake()
    {
        instance = this;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(AudioClip audioClip, float volume = 1)
    {
        audioSource.PlayOneShot(audioClip, volume);
    }
}
