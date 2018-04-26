using UnityEngine;

public class InTransition : MonoBehaviour
{
    public GameObject outTransition;
    public GameObject audioVisual;
    public GameObject scenarioText;
    public GameObject objects;
    public GameObject metricsText;
    public float speed;

    private Material material;
    private float pause;

    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void OnEnable()
    {
        if (outTransition.activeSelf)
        {
            gameObject.SetActive(false);
        }

        Scenarios.m_SoundEffectWWWBool = false;

        Scenarios.m_UpdateScenario = true;

        scenarioText.SetActive(true);

        pause = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause <= Scenarios.m_InTransitionLength)
        {
            if (Scenarios.m_StartBool)
            {
                if (!Scenarios.m_UpdateScenario && !audioVisual.activeSelf)
                {
                    audioVisual.SetActive(true);
                }

                pause += 1.0f * Time.deltaTime;
            }
        }
        else
        {
            if (scenarioText.activeSelf)
            {
                scenarioText.SetActive(false);

                objects.SetActive(true);
            }

            Color colour = material.color;

            if (colour.a > 0.0f)
            {
                colour.a -= speed * Time.deltaTime;

                material.color = colour;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        Color colour = material.color;

        colour.a = 1.0f;

        material.color = colour;

        metricsText.SetActive(true);
    }
}