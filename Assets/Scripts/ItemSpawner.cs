using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    public GameObject itemPrefab;
    public GameObject player;
    public float spawnInterval = 10.0f;
    public float spawnRadius = 30.0f;

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
        var item = Instantiate(itemPrefab);
        var theta = Random.Range(0, 2 * Mathf.PI);
        var vx = spawnRadius * Mathf.Cos(theta);
        var vz = spawnRadius * Mathf.Sin(theta);
        var spawnPos = new Vector3(vx, 0, vz);
        item.transform.position = player.transform.position + spawnPos; // 기준점을 앞으로 설정하는 것이 일반적임
    }
}
