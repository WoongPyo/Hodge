using UnityEngine;
using UnityEngine.UI;

public class triggers : MonoBehaviour {

    public Text testText;
    public float health = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Ground") {
            Destroy(other.transform.parent.gameObject);
        }
        testText.text = string.Format("{0}", health--);
    }
}
