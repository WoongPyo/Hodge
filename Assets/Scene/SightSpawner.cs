using UnityEngine;

public class SightSpawner : MonoBehaviour {
    public GameObject sightPrefab;
    public GameObject player;
    public float spawnInterval = 10.0f;
    public float spawnRadius = 3.0f;

    private float lastSpawnTime;



    private void Update()
    {

        if (Time.time - lastSpawnTime > spawnInterval)
        {
            Spawn();
            lastSpawnTime = Time.time;
        }

    }

    private void Spawn()
    {
        var sight = Instantiate(sightPrefab);
        var theta = Random.Range(0, 2 * Mathf.PI);
        var vx = spawnRadius * Mathf.Cos(theta);
        var vz = spawnRadius * Mathf.Sin(theta);
        var spawnPos = new Vector3(vx, 0, vz);
        sight.transform.position = player.transform.position + spawnPos; // 기준점을 앞으로 설정하는 것이 일반적임
    }
}
