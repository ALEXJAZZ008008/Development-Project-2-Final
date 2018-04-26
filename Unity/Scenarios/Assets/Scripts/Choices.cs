using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choices : MonoBehaviour
{
    public GameObject choicePrefab;
    public GameObject outTransition;

    public Text countdownTextAsset;

    private List<GameObject> choiceList;

    void Awake()
    {
        choiceList = new List<GameObject>();
    }

    void OnEnable()
    {
        countdownTextAsset.text = ((int)Scenarios.m_ChoiceWaitLength).ToString();

        int angle = 360 / Scenarios.m_Choices.Count;

        int currentAngle = 0;

        for (int i = 0; i < Scenarios.m_Choices.Count; i++)
        {
            choiceList.Add(Instantiate(choicePrefab));

            choiceList[i].transform.parent = transform;

            choiceList[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Scenarios.m_Choices[i].GetChoiceText();

            choiceList[i].GetComponent<ChoiceTrigger>().feedbackText = Scenarios.m_Choices[i].GetFeedbackText();
            choiceList[i].GetComponent<ChoiceTrigger>().nextScenarioIndex = Scenarios.m_Choices[i].GetNextScenarioIndex();
            choiceList[i].GetComponent<ChoiceTrigger>().score = Scenarios.m_Choices[i].GetScore();
            choiceList[i].GetComponent<ChoiceTrigger>().outTransition = outTransition;
            choiceList[i].GetComponent<ChoiceTrigger>().countdownTextAsset = countdownTextAsset;

            choiceList[i].transform.RotateAround(Vector3.zero, Vector3.up, currentAngle);

            currentAngle += angle;
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < choiceList.Count; i++)
        {
            Destroy(choiceList[i]);
        }

        choiceList.Clear();
    }
}
