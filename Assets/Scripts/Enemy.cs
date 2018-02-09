using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject enemies;
    public float makingTime;
    public float radius;
    
    private float presentTime;

    
    void Start () {

    }
	
	void Update () {
        if (presentTime > makingTime) {
            var enemi = Instantiate(enemies, transform);
            var tf = enemi.transform;
            float thetaRandom = Random.Range(0, 2 * Mathf.PI);

            float Mx = radius * Mathf.Sin(thetaRandom);
            float Mz = radius * Mathf.Cos(thetaRandom);
            tf.localPosition = new Vector3(Mx, 0, Mz);
            presentTime = 0;
        }
        presentTime += Time.deltaTime;
    }
}
