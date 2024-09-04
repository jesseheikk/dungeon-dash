using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    int score = 0;
    bool isGameRunning = true;

    void Awake()
    {
        // Make sure only one instance exists
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (isGameRunning)
        {
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        score += Mathf.RoundToInt(Time.deltaTime * 10);
        UIManager.Instance.UpdateScoreUI(score);
    }

    public void GameOver()
    {
        isGameRunning = false;
        UIManager.Instance.ShowGameOver();
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
