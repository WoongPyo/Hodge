using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {

    public float speed = 10.0f;
    public GameObject ChaseCamera;
    public float ViewSize = 20.0f;

    private DirPad dirPad;
    private Transform player;
    
    void Start () {
        dirPad = GameObject.Find("Canvas/Dir Pad").GetComponent<DirPad>();
        player = GetComponent<Transform>().gameObject.transform;
    }
	
	void Update () {
        if (dirPad.dragging) {
            var dn = dirPad.dir.normalized * Time.deltaTime * speed;
            transform.Translate(new Vector3(dn.x, 0, dn.y));
        }
        else {
            var dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            var dz = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            player.Translate(new Vector3(dx, 0, dz));
        }
    }


}
