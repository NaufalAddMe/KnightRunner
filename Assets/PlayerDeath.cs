using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject gameOverCanvas;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            
            FindObjectOfType<SurvivalTimer>().StopTimer();

            gameOverCanvas.SetActive(true);// Aktifkan UI Game Over
            Time.timeScale = 0f; // Pause game
             
        }
    }

    
}
