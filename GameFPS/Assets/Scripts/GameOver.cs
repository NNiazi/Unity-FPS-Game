
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public RectTransform gameOverPanel;

    public Text GameOverText;

    // Use this for initialization
    void Start () {

        GameManager.Instance.GameOverEvent += GameOverEvent;

    }

    private void GameOverEvent(object sender, System.EventArgs e)
    {

        gameOverPanel.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
