using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] Text scoreText;
    [SerializeField] GameObject gameOverPanel;

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
}

