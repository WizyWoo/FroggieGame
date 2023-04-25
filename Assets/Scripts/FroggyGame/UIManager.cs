using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private TMP_Text highscoreText, scoreText;
    [SerializeField]
    private LevelController levelController;
    [SerializeField]
    private GameObject retryPanel;

    private void Start()
    {

        int _highscore = 0;

        if(PlayerPrefs.HasKey("DistanceHighscore"))
            _highscore = PlayerPrefs.GetInt("DistanceHighscore");

        highscoreText.text = "Highscore: " + _highscore;

    }

    private void FixedUpdate()
    {

        scoreText.text = "Distance: " + levelController.DistanceMoved;

        if(levelController.FrogGone)
            retryPanel.SetActive(true);

    }

    public void QuitGame()
    {

        Application.Quit();

    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
