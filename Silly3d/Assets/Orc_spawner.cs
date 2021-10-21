using UnityEngine;

public class Orc_spawner : MonoBehaviour
{
    public float spawnFrequency = 15f;
    float timeForNextSpawn = 0;
    Vector3 pos;
    public GameObject MobToSpawn;
    public GameObject MobToSpawn2;

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
            int random = Random.Range(1, 4);
            GameObject mob;
            if (random < 3) mob = MobToSpawn;
            else mob = MobToSpawn2;
            mob = Instantiate(mob);
            mob.transform.position = pos;
            timeForNextSpawn = Time.time + spawnFrequency;
        }
    }
}
