using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float minSpawnTime = 1.0f;
    [SerializeField] float maxSpawnTime = 3.0f;
    
    float spawnDistance = 10f;
    Vector2 screenbounds;
    Vector2 spawnPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        int side = Random.Range(0,4);
        switch (side)
        {
            case 0:
                spawnPos = new Vector2(Random.Range(-screenbounds.x, screenbounds.x), screenbounds.y + spawnDistance);
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(-screenbounds.x, screenbounds.x), -screenbounds.y - spawnDistance);
                break;
            case 2:
                spawnPos = new Vector2(screenbounds.x + spawnDistance, Random.Range(-screenbounds.y, screenbounds.y));
                break;
            case 3:
                spawnPos = new Vector2(-screenbounds.x - spawnDistance, Random.Range(-screenbounds.y, screenbounds.y));
                break;
        }
        Instantiate(enemyPrefab, spawnPos, transform.rotation);
        Invoke("SpawnEnemy", spawnTime);
    }
}
