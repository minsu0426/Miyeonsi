using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSpawner : MonoBehaviour
{
    public GameObject cakePrefab;  // 케이크 프리팹
    public float spawnInterval = 10f;  // 케이크 생성 간격
    public int spawnCount = 2;  // 케이크를 생성할 횟수

    void Start()
    {
        // 케이크를 제한된 횟수만큼 생성하는 코루틴 시작
        StartCoroutine(SpawnCakeRoutine());
    }

    IEnumerator SpawnCakeRoutine()
    {
        for (int i = 0; i < spawnCount; i++)  // 지정된 횟수만큼 케이크를 생성
        {
            SpawnCake();
            yield return new WaitForSeconds(spawnInterval);  // 지정된 시간만큼 대기
        }
    }

    void SpawnCake()
    {
        // 맵 위의 랜덤한 위치 계산
        float x = Random.Range(-7.28f, 7.98f);
        float y = Random.Range(-4.3f, 4.3f);
        Vector2 spawnPosition = new Vector2(x, y);

        // 케이크 생성
        Instantiate(cakePrefab, spawnPosition, Quaternion.identity);
    }
}