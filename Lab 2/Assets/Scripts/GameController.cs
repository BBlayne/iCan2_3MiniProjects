using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private static GameController _instance = null;

    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameController>();
            }

            return _instance;
        }
    }

    private int _score = 0;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            if (scoreText != null)
                scoreText.text = _score.ToString();
            if (_score >= maxScore)
            {
                victoryScreen.SetActive(true);
                player.SetActive(false);
            }
        }
    }

    [SerializeField]
    GameObject victoryScreen = null;

    [SerializeField]
    GameObject errorScreen = null;

    [SerializeField]
    GameObject player = null;

    Text scoreText = null;
    Text errorText = null;

    public int maxScore = 10;

    private void OnEnable()
    {
        Floor.OnError += DisplayErrorScreen;
    }

    private void OnDisable()
    {
        Floor.OnError -= DisplayErrorScreen;
    }

    // Use this for initialization
    void Start () {
        Random.InitState((int)System.DateTime.Now.Ticks);

        maxScore = Random.Range(0, 100);

        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        }

        if (errorText == null)
        {
            errorText = GameObject.Find("ErrorText").GetComponent<Text>();
        }

        Score = 0;

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    private void DisplayErrorScreen(string errorMsg)
    {
        if (errorText != null && errorScreen != null)
        {
            errorText.GetComponent<Text>().enabled = true;
            errorText.text = errorMsg;

            errorScreen.GetComponent<Image>().enabled = true;
            player.SetActive(false);
        }
    }
}
