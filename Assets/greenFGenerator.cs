using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenFGenerator : MonoBehaviour
{

    public GameObject greenFPrefab; // 장애물 프리팹
    public float span = 0.5f;     // 장애물 생성 간격
    private float delta = 0;

    private float screenMinX = -11f;
    private float screenMaxX = 11f;
    private float screenMinY = -5f;
    private float screenMaxY = 5f;

    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            SpawnObstacle();
        }


    }

    void SpawnObstacle()
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        GameObject go = Instantiate(greenFPrefab, spawnPosition, Quaternion.identity);

        Vector2 targetPosition = GetRandomTargetPosition();
        Vector2 direction = (targetPosition - spawnPosition).normalized;

        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * 3f; // 속도 설정
        }
    }

    Vector2 GetRandomSpawnPosition()
    {
        // 화면 바깥의 네 방향 중 하나에서 무작위 위치 반환
        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0: // 위쪽
                return new Vector2(Random.Range(screenMinX, screenMaxX), screenMaxY + 1f);
            case 1: // 아래쪽
                return new Vector2(Random.Range(screenMinX, screenMaxX), screenMinY - 1f);
            case 2: // 왼쪽
                return new Vector2(screenMinX - 1f, Random.Range(screenMinY, screenMaxY));
            case 3: // 오른쪽
                return new Vector2(screenMaxX + 1f, Random.Range(screenMinY, screenMaxY));
            default:
                return Vector2.zero;
        }
    }

    Vector2 GetRandomTargetPosition()
    {
        // 화면 안의 무작위 위치 반환
        return new Vector2(Random.Range(-7, 8), Random.Range(-3, 4));
    }
    
}