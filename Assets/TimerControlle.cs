using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float countdownTime = 600f;
    private float currentTime = 0f;
    private bool timerActive = true;

    public Text timerText;

    private void Start()
    {
        currentTime = 0f;
    }

    private void Update()
    {
        if (timerActive)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= countdownTime)
            {
                timerActive = false;
                Debug.Log("Game Over !");
            }

            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}