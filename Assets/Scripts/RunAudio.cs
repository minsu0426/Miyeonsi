using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAudio : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource.loop = true; // �ݺ� ��� ����
        audioSource.playOnAwake = false; // ���� ���� �� �ڵ� ������� �ʵ��� ����
    }

    // ��������� ����ϴ� �޼���
    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // ������ ��� ���� ������ �ִٸ� ����
        }

        audioSource.clip = clip; // ���ο� ����� Ŭ�� �Ҵ�
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
