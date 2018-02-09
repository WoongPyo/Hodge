using UnityEngine;
using UnityEngine.UI;

public class playerScore : MonoBehaviour {
    private float playTime = 0.0f;
    public float GameScore { get; private set; }

    public float addScoreTime = 5.0f;
    public float multiplier = 1.0f;
    private int health;

    Text scoreText;
    
	void Start () {
        scoreText = GameObject.Find("Canvas/Panel/Score Panel/Score Text").GetComponent<Text>();
    }
	void Update () {
        health = GetComponent<playerHP>().GetHealth;
        if (health > 0)        {
            playTime += Time.deltaTime;
            if (playTime > addScoreTime)
            {
                GameScore += multiplier;
                scoreText.text = string.Format("{0}", GameScore);
                playTime = 0.0f;
            }
        }
        else
        {
            PlayerPrefs.SetFloat("BestScore", GameScore);
            PlayerPrefs.Save();
        }

    }
}
