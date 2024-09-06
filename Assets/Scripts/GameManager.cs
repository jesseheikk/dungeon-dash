using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsGameRunning { get; private set; } = false;

    int score = 0;

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
        if (IsGameRunning)
        {
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        score += Mathf.RoundToInt(Time.deltaTime * 10);
        UIManager.Instance.UpdateScoreUI(score);
    }

    public void StartGame()
    {
        IsGameRunning = true;
        CameraController.Instance.SetCameraOffSet(new Vector3(0f, 5f, -5f));
        PlayerController.Instance.StartRunning();
    }

    public void GameOver()
    {
        IsGameRunning = false;
        UIManager.Instance.ShowGameOver();
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
