using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private void OnEnable()
    {
        // Nos suscribimos al evento del Jugador (Observer)
        PlayerController.OnPlayerDied += ShowGameOverScreen;
    }

    private void OnDisable()
    {
        // Siempre desuscribirse para evitar fugas de memoria
        PlayerController.OnPlayerDied -= ShowGameOverScreen;
    }

    private void ShowGameOverScreen()
    {
        Debug.Log("UI reacciona a la muerte del jugador.");
        //if (gameOverPanel != null)
        //{
            //gameOverPanel.SetActive(true);
        //}

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
