using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float columnMin = -2.9f;
    public float columnMax = 1.4f;
    float spawnXPosition = 10;
    GameObject[] columns;
    Vector2 objectPoolPosition = new Vector2(-14, 0);
    float timeSinceLastSpawn;
    public float SpawnRate;
    int currentColumn;

    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for(int i=0; i < columnPoolSize; i++)
        {
            columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
        SpawnColumn();
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime; //vamos sumando el timpo que ha pasado desde el ultimo fotograma
        if(!GameControler.instance.gameOver && timeSinceLastSpawn >= SpawnRate)
        {
            timeSinceLastSpawn = 0;
            SpawnColumn();
        }
    }

    void SpawnColumn()
    {
        float spawnYPosition = Random.Range(columnMin, columnMax);
        columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
        currentColumn++;
        if (currentColumn >= columnPoolSize)
        {
            currentColumn = 0;
        }
    }
}
