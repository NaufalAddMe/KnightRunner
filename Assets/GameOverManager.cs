using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f; // Pastikan game un-pause dulu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
