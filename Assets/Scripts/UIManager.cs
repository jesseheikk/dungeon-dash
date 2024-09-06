using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] Text scoreText;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject menu;

    void Awake()
    {
        // Make sure only one instance exists
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateScoreUI(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
        menu.SetActive(false);
    }

    public void OpenOptions()
    {
        Debug.Log("Open Options");
    }

    public void ExitGame()
    {
        Debug.Log("Exit game");
        //Application.Quit();
    }
}

