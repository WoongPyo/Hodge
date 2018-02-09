using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwayFromPlayer : MonoBehaviour {
    public float sightSpeed = 1.0f;
    public GameObject player;
    public float LivingTime = 0.0f;
    private Vector3 movingVector;

    void Start()
    {
        player = GameObject.Find("Player/Cube");
        LivingTime = Time.time;
    }

    void Update()
    {        
        var diff = transform.position - player.transform.position + new Vector3(Random.value, 0, Random.value) * 5;
        movingVector = diff.normalized * sightSpeed * Time.deltaTime;
        transform.Translate(movingVector);
        if (Time.time - LivingTime > 20.0f)  Destroy(transform.parent.gameObject);
    }

}
