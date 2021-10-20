using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc_spawner : MonoBehaviour
{
    public float spawnFrequency = 15f;
    float timeForNextSpawn = 0;
    Vector3 pos;
    public GameObject MobToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeForNextSpawn)
        {
            GameObject orc = Instantiate(MobToSpawn);
            orc.transform.position = pos;
            timeForNextSpawn = Time.time + spawnFrequency;
        }
    }
}
