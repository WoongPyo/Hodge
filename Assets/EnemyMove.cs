using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public float enemySpeed = 3.0f;
    public GameObject player;

    private Vector3 movingVector;

    void Start () {
        player = GameObject.Find("Player/Cube");
    }

    void Update () {
        var diff = player.transform.position- transform.position;
        movingVector = diff.normalized * enemySpeed * Time.deltaTime;
        transform.Translate(movingVector);
	}
    
}
