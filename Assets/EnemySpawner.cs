using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public GameObject player;
    public Transform playerPosition;
    public float spawnRadius = 2.0f;
    public float spawnInterval = 2.0f;
    public float enemyRadius = 20.0f;

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
        var enemy = Instantiate(enemyPrefab);
        var theta = Random.Range(0, 2 * Mathf.PI);
        var vx = enemyRadius * Mathf.Cos(theta);
        var vz = enemyRadius * Mathf.Sin(theta);
        var spawnPos = new Vector3(vx, 0, vz);
        enemy.transform.position = player.transform.position + spawnPos; // 기준점을 앞으로 설정하는 것이 일반적임
    }
}
