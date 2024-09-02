using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public static RunAudio instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSource.loop = true; // �ݺ� ��� ����
        audioSource.playOnAwake = false; // ���� ���� �� �ڵ� ������� �ʵ��� ����
    }

    // ��������� ����ϴ� �޼���
    public void PlayBackgroundMusic(AudioClip clip, float volume)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // ������ ��� ���� ������ �ִٸ� ����
        }

        audioSource.clip = clip; // ���ο� ����� Ŭ�� �Ҵ�
        audioSource.volume = volume; // ���ο� ��� ���� �������� ������ ������ �������� ���
        audioSource.Play(); // ���� ���
    }

    // ��������� �����ϴ� �޼���
    public void StopBackgroundMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // ���� ��� ���� ������ ����
        }
    }
}
