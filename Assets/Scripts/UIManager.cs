using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject mainPainel;
    public GameObject gameOverPainel;
    public GameObject tapText;

    public Text score;
    public Text highScore1;
    public Text highScore2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        highScore1.text ="High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void GameStart()
    {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
        tapText.SetActive(false);
        mainPainel.GetComponent<Animator>().Play("PanelOut");
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPainel.SetActive(true);
    }
}
