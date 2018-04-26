using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceTrigger : MonoBehaviour
{
    public string feedbackText;

    public int nextScenarioIndex;
    public int score;

    public GameObject outTransition;

    public Text countdownTextAsset;

    private float timer;

    void Awake()
    {
        timer = Scenarios.m_ChoiceWaitLength;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Crosshair"))
        {
            timer -= Time.deltaTime;

            countdownTextAsset.text = ((int)timer).ToString();

            if (timer <= 0.0f)
            {
                Scenarios.m_NextScenario = nextScenarioIndex;

                if (!outTransition.activeSelf)
                {
                    outTransition.SetActive(true);
                }

                Scenarios.m_Score += score;

                using (StreamWriter streamWriter = new StreamWriter(Scenarios.m_UniqueOutputPath, true))
                {
                    streamWriter.WriteLine(feedbackText + "\r\nCurrent Score: " + Scenarios.m_Score.ToString() + "\r\nCurrent Time: " + Scenarios.m_Time.ToString());
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Crosshair"))
        {
            timer = Scenarios.m_ChoiceWaitLength;

            countdownTextAsset.text = ((int)timer).ToString();
        }
    }
}
