using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsGameRunning { get; private set; } = false;

    float score = 0f;

    void Awake()
    {
        // Make sure only one instance exists
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (IsGameRunning)
        {
            AddScore(0.1f);
            UIManager.Instance.UpdateScoreUI(Mathf.RoundToInt(score));
        }
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

    public void AddScore(float amount)
    {
        score += amount;
    }
}
