using UnityEngine;

public class OutTransition : MonoBehaviour
{
    public GameObject inTransition;
    public GameObject[] objects;
    public GameObject[] earlyObjects;
    public float speed;

    private Material material;

    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void OnEnable()
    {
        if (inTransition.activeSelf)
        {
            gameObject.SetActive(false);
        }

        for (int i = 0; i < earlyObjects.Length; i++)
        {
            if (earlyObjects[i].activeSelf)
            {
                earlyObjects[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Color colour = material.color;

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].activeSelf)
            {
                objects[i].SetActive(false);
            }
        }

        if (colour.a < 1.0f)
        {
            colour.a += speed * Time.deltaTime;

            material.color = colour;

            if (colour.a >= 1.0f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        Color colour = material.color;

        colour.a = 0.0f;

        material.color = colour;

        inTransition.SetActive(true);
    }
}