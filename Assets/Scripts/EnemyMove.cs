using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public float enemySpeed = 3.0f;
    public GameObject player;
    public float LivingTime = 15.0f;
    public GameObject explosion;

    private float enemyLivingTime = 0.0f;
    private Vector3 movingVector;

    void Start () {
        player = GameObject.Find("Player");
    }

    void Update () {
        enemyLivingTime += Time.deltaTime;
        var diff = player.transform.position - transform.position;
        movingVector = diff.normalized * enemySpeed * Time.deltaTime;
        transform.Translate(movingVector);

        if (enemyLivingTime > LivingTime) {
            var explo = Instantiate(explosion);
            explo.transform.position = transform.position; 
            Destroy(gameObject);
        }
            
	}
    
}
