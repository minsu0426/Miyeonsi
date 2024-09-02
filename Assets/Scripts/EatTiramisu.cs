using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSpawner : MonoBehaviour
{
    public GameObject cakePrefab;  // ����ũ ������
    public float spawnInterval = 10f;  // ����ũ ���� ����
    public int spawnCount = 2;  // ����ũ�� ������ Ƚ��

    void Start()
    {
        // ����ũ�� ���ѵ� Ƚ����ŭ �����ϴ� �ڷ�ƾ ����
        StartCoroutine(SpawnCakeRoutine());
    }

    IEnumerator SpawnCakeRoutine()
    {
        for (int i = 0; i < spawnCount; i++)  // ������ Ƚ����ŭ ����ũ�� ����
        {
            SpawnCake();
            yield return new WaitForSeconds(spawnInterval);  // ������ �ð���ŭ ���
        }
    }

    void SpawnCake()
    {
        // �� ���� ������ ��ġ ���
        float x = Random.Range(-7.28f, 7.98f);
        float y = Random.Range(-4.3f, 4.3f);
        Vector2 spawnPosition = new Vector2(x, y);

        // ����ũ ����
        Instantiate(cakePrefab, spawnPosition, Quaternion.identity);
    }
}