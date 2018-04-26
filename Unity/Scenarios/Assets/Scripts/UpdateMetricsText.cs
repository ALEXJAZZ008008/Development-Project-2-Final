using UnityEngine;
using UnityEngine.UI;

public class UpdateMetricsText : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        Scenarios.m_Time += Time.deltaTime;

        scoreText.text = "Score: " + Scenarios.m_Score.ToString();

        // Crude conversion to a time format 
        int minutes = Mathf.FloorToInt(Scenarios.m_Time / 60f);
        int seconds = Mathf.FloorToInt(Scenarios.m_Time - minutes * 60);

        timerText.text = string.Format("Time: " + "{0:00}:{1:00}", minutes, seconds);
    }
}