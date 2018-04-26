using UnityEngine;

public class InTransition : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject instructionsText;
    public GameObject visual;
    public float speed;

    private Material material;
    private float pause;

    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void OnEnable()
    {
        Arc.m_SoundEffectWWWBool = false;

        Arc.m_UpdateScenario = true;

        pause = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause <= Arc.m_InTransitionLength)
        {
            if (Arc.m_StartBool)
            {
                if (!Arc.m_UpdateScenario && !visual.activeSelf)
                {
                    visual.SetActive(true);
                }

                pause += 1.0f * Time.deltaTime;
            }
        }
        else
        {
            if (!instructionsText.activeSelf)
            {
                instructionsText.SetActive(true);

                crosshair.SetActive(true);
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
    }
}