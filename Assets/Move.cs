using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {

    public float speed = 10.0f;
    public GameObject ChaseCamera;
    public float ViewSize = 20.0f;

    private Transform player;
    
    void Start () {
        player = GetComponent<Transform>().gameObject.transform;
    }
	
	void Update () {
        var dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var dz = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        player.Translate(new Vector3(dx, 0, dz));
    }


}
