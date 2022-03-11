using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {
    public Transform[] spawnPoints;
    public GameObject ObstacleDefault, ObstacleLight, ObstaclePrimary, ObstacleDark;
    public float timeBetweenWaves = 1f;
    private float timeToSpawn = 3f;
    private int ddstate;

    private void Start()
    {
        ddstate = PlayerPrefs.GetInt("themeState");
    }

    void Update ()
    {
		if (Time.time >= timeToSpawn)
        {
            StartCoroutine(SpawnObstacle());
            timeToSpawn = Time.time + timeBetweenWaves;
        }
	}
    
    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(4);
        int randomIndex = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if(randomIndex != i)
            {
                if (ddstate == 0)
                {
                    Instantiate(ObstacleDefault, spawnPoints[i].position, Quaternion.identity);
                }

                if (ddstate == 1)
                {
                    Instantiate(ObstacleLight, spawnPoints[i].position, Quaternion.identity);
                }

                if (ddstate == 2)
                {
                    Instantiate(ObstaclePrimary, spawnPoints[i].position, Quaternion.identity);
                }

                if (ddstate == 3)
                {
                    Instantiate(ObstacleDark, spawnPoints[i].position, Quaternion.identity);
                }
            }
        }
    }

}
