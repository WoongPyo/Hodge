using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHP : MonoBehaviour {

    private Text HPText;
    private Text MultiplierText;
    public GameObject explosion;
    private GameObject ground;
    private GameObject gameover;
    
    private Camera cam;

    private float dx;
    private float dz;

    private bool onSight = false;
    private float sightTime = 0.0f;
    public float LivingTime = 15.0f;

    private float UpdateTime;

    private int health=10;

    public int GetHealth { get { return health; } }

    public void HealHp(int amount)
    {
        health += amount;
        UpdateHP();
    }
    public void DamageHp(int amount) {
        health -= amount;
        UpdateHP();
    }

    private void UpdateHP()
    {
        HPText.text = health.ToString();
    }

    private playerScore scoremulti;


    private void Start() {
        cam = GameObject.Find("Player/Cube/Main Camera").GetComponent<Camera>();
        gameover = GameObject.Find("Canvas/Game Over Button");
        ground = GameObject.Find("Ground");
        scoremulti = GetComponent<playerScore>();
        HPText = GameObject.Find("Canvas/Panel (1)/Health Panel/HP Text").GetComponent<Text>();
        MultiplierText = GameObject.Find("Canvas/Mutiplier Panel/Multi Text").GetComponent<Text>();
        gameover.SetActive(false);
    }

    private void Update() {
        if(UpdateTime - 10.0f > 0) {
            HealHp(1);
            UpdateTime = 0.0f;
        }

        UpdateTime += Time.deltaTime;

        if (onSight) {
            sightTime += Time.deltaTime;
        }
        
        if (sightTime > LivingTime) {
            GetComponentInChildren<Light>().range = 15.0f;
            GetComponentInChildren<Light>().transform.localPosition = new Vector3(0, 0, 7);
            cam.orthographicSize = 10;
            onSight = false;
            sightTime = 0.0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cube") {
            var explo = Instantiate(explosion);
            explo.transform.position = other.transform.position;
            Destroy(other.transform.parent.gameObject);
            if(health != 0) DamageHp(1);
        }

        if (other.name == "Item") {
            Destroy(other.transform.parent.gameObject);
            scoremulti.multiplier += 1.0f;
            MultiplierText.text = string.Format("{0}", scoremulti.multiplier);
        }

        if (other.tag == "Sight")
        {
            GetComponentInChildren<Light>().range = 30.0f;
            GetComponentInChildren<Light>().transform.localPosition = new Vector3(0, 0, 0);
            cam.orthographicSize = 20;
            sightTime = 0.0f;
            onSight = true;
        }
        
        if(other.tag == "Wall")
        {
            MoveWall(other);
        }

        if (health == 0) {
            PlayerPrefs.GetFloat("BestScore", GetComponent<playerScore>().GameScore);
            PlayerPrefs.Save();
            transform.parent.GetComponent<Move>().enabled = false;
            gameover.SetActive(true);
        }

    }

    private void MoveWall(Collider other)
    {
        if (other.name == "Wall Up")
        {
            dx = ground.transform.position.x;
            dz = ground.transform.position.z + 225.0f;
        }
        if (other.name == "Wall Down")
        {
            dx = ground.transform.position.x;
            dz = ground.transform.position.z - 225.0f;
        }
        if (other.name == "Wall Right")
        {
            dx = ground.transform.position.x + 225.0f;
            dz = ground.transform.position.z;
        }
        if (other.name == "Wall Left")
        {
            dx = ground.transform.position.x - 225.0f;
            dz = ground.transform.position.z;
        }
        ground.transform.position = new Vector3(dx, 0, dz);
    }

    public void GoBackSplash() {
        SceneManager.LoadScene("Splash");
    }
}
