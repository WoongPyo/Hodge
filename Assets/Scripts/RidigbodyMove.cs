using UnityEngine;

public class RidigbodyMove : MonoBehaviour {
    Rigidbody rb;
    public float speed = 10;

    private Vector3 inputDir;
    private void Start(){
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate(){
        var dx = Input.GetAxis("Horizontal");
        var dz = Input.GetAxis("Vertical");
        var direction = new Vector3(dx, 0, dz);
        

        if (direction.magnitude > 1)        {
            inputDir = direction.normalized * speed;
        }
        else        {
            inputDir = direction * speed;
        }


        // rb.AddForce(new Vector3(dx, 0, dz) * forceMag);
        rb.velocity = new Vector3(inputDir.x, rb.velocity.y, inputDir.z);
        Debug.LogFormat("Velocity: {0}", Time.deltaTime);
    }
}
