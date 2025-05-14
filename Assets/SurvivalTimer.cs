using UnityEngine;
using TMPro;

public class SurvivalTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timer;
    private bool isRunning = true;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        if (!isRunning) return;

        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("F2") + " s";
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
