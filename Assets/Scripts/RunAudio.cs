using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource 컴포넌트 추가 및 기본 설정
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; // 반복 재생 설정
        audioSource.playOnAwake = false; // 게임 시작 시 자동 재생되지 않도록 설정
    }

    // 배경음악을 재생하는 메서드
    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // 기존에 재생 중인 음악이 있다면 중지
        }

        audioSource.clip = clip; // 새로운 오디오 클립 할당
        audioSource.Play(); // 음악 재생
    }

    // 배경음악을 중지하는 메서드
    public void StopBackgroundMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // 현재 재생 중인 음악을 중지
        }
    }
}
