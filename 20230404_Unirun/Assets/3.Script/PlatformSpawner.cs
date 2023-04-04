using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefabs;
    public int count = 3;
    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax= 2.25f;
    public float timeBetSpawn;

    public float yPos_min = -3.5f;
    public float yPos_Max = 1.5f;

    public float xPos = 20f;

    private GameObject[] platforms;
    private int current_index = 0;

    private Vector2 Poolposition = new Vector2(0, -25f);
    private float lastSpawnTime;


    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[count];
        for (int i=0; i<count; i++)
        {
            platforms[i] = Instantiate(platformPrefabs, Poolposition, Quaternion.identity);
        }
        lastSpawnTime = 0;
        timeBetSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManger.Instance.isGameOver)
        {
            return;
        }
        if(Time.time>=lastSpawnTime+timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float ypos = Random.Range(yPos_min, yPos_Max);
            platforms[current_index].SetActive(false);  
            platforms[current_index].SetActive(true);

            platforms[current_index].transform.position = new Vector2(xPos, ypos);
            current_index++;

            if(current_index>=count)
            {
                current_index = 0;
            }

        }
    }
}
