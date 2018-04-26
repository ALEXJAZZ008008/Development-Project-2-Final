using UnityEngine;

public class EmergencyLight : MonoBehaviour
{
    private Material material;
    private bool alphaAscending;

    void Awake()
    {
        material = GetComponent<Renderer>().material;

        alphaAscending = true;
    }

    // Update is called once per frame
    void Update()
    {
        Color colour = material.color;

        float alphaIncrement = Scenarios.m_LightingIntensity * Time.deltaTime;

        if (alphaAscending)
        {
            colour.a += alphaIncrement;
        }
        else
        {
            colour.a -= alphaIncrement;
        }

        if (colour.a < 0.0f || colour.a > Scenarios.m_LightingIntensity)
        {
            alphaAscending = !alphaAscending;
        }
        else
        {
            material.color = colour;
        }
    }

    void OnDisable()
    {
        Color colour = material.color;

        colour.a = 0.0f;

        material.color = colour;
    }
}