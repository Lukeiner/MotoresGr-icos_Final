using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

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
        // Nos suscribimos al evento del Jugador (Observer)
        PlayerController.OnPlayerDied += ShowGameOverScreen;
        Collectible.OnCollected += AddBonusPoints;
    }

    private void OnDisable()
    {
        // Siempre desuscribirse para evitar fugas de memoria
        PlayerController.OnPlayerDied -= ShowGameOverScreen;
        Collectible.OnCollected -= AddBonusPoints;
    }

    public void ShowGameOverScreen()
    {
        Debug.Log("UI reacciona a la muerte del jugador.");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void AddBonusPoints(int amount)
    {
        currentScore += amount;
        Debug.Log($"¡Recolectable juntado! +{amount} pts");
        // Actualiza el texto en pantalla inmediatamente
        scoreText.text = "Puntaje: " + Mathf.FloorToInt(currentScore);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Aseguramos que el tiempo vuelva a 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PrincipalMenu");
    }
}
