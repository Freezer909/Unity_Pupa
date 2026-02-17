using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    public DonutBakerScript baker;

    private float timeElapsed = 0;
    private bool isGameRunning = false;

    void Update()
    {
        if (isGameRunning)
        {
            timeElapsed += Time.deltaTime;
            DisplayTime(timeElapsed);
        }
    }

    public void StartGame(bool state)
    {
        isGameRunning = state;
        baker.BakeDonut(state);

        if (!state) 
        {
            ResetTimer();
        }
    }

    public void GameOver()
    {
        isGameRunning = false;
        baker.CleanUp();
        ResetTimer();

        // Find the player and reset their size
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void ResetTimer()
    {
        timeElapsed = 0;
        DisplayTime(0);
    }

    void DisplayTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}