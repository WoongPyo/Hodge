using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
    public AudioSource music;
    public AudioSource buttonSound;
    public GameObject HpPanel;
    private bool musicBool = false;
    public Text musicOnOff;
    public Text addNumberButtonText; // 누르면 숫자가 증가하는 버튼의 Text

    private void Start()
    {
        var addNumber = PlayerPrefs.GetFloat("BestScore", 0.0f);
        addNumberButtonText.text = string.Format("{0}", addNumber);
    }

    public void OpenMainScene() {
        SceneManager.LoadScene("Hodge");
    }

    public void PlaySound() {
        if (!musicBool)        {
            music.Play();
            musicOnOff.text = "Music ON";
            musicBool = true;
        } else {
            music.Stop();
            musicOnOff.text = "Music OFF";
            musicBool = false;
        }
    }

    public void ToggleHPPanel() {
        buttonSound.Play();
        HpPanel.SetActive(HpPanel.activeSelf == false);
    }

    public void AddNumber() {
        buttonSound.Play();
        var addNumber = PlayerPrefs.GetInt("ADD_NUMBER", 1);
        PlayerPrefs.SetInt("ADD_NUMBER", addNumber + 1);
        PlayerPrefs.Save();
    }

    public void ResetBestScore() {
        buttonSound.Play();
        PlayerPrefs.SetFloat("BestScore", 0.0f);
        var addNumber = PlayerPrefs.GetFloat("BestScore", 0.0f);
        PlayerPrefs.Save();
        addNumberButtonText.text = string.Format("{0}", addNumber);
    }
    public void applicationQuit()
    {
        Application.Quit();
    }
}
