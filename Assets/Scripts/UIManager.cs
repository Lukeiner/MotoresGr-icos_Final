using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float currentScore = 0f;
    private void Awake()
    {
        if (Instance == null)
        {
        Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        PlayerController.OnPlayerDied += ShowGameOverScreen;
        Collectible.OnCollected += AddBonusPoints;
        DistanceTracker.OnDistanceUpdated += UpdateDistanceUI;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= ShowGameOverScreen;
        Collectible.OnCollected -= AddBonusPoints;
        DistanceTracker.OnDistanceUpdated -= UpdateDistanceUI;
    }
    private void UpdateDistanceUI(int meters)
    {
        distanceText.text = $"Distancia: {meters}m";
    }
    public void ShowGameOverScreen()
    {
        Debug.Log("UI reacciona a la muerte del jugador.");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    private void AddBonusPoints(int amount)
    {
        currentScore += amount;
        Debug.Log($"¡Recolectable juntado! +{amount} pts");
        scoreText.text = "Puntaje: " + Mathf.FloorToInt(currentScore);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PrincipalMenu");
    }
}
