using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Patron Singleton simple
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
        // Se suscribe a la muerte del jugador
        PlayerController.OnPlayerDied += HandlePlayerDeath;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= HandlePlayerDeath;
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("GameManager: El jugador murió. Procesando fin de partida...");
        UIManager.Instance.ShowGameOverScreen();
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }
}