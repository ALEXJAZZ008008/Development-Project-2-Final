using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject smokeCanvas;
    public GameObject fireCanvas;
    public GameObject fireExtinguisherCanvas;
    public GameObject emergencyLight;
    public GameObject audioVisualCanvas;
    public GameObject soundEffect;
    public GameObject outTransition;
    public Vector3 speed;

    private AudioSource soundEffectSource;
    private Vector3 rotation;

    void Awake()
    {
        soundEffectSource = soundEffect.GetComponent<AudioSource>();

        rotation = new Vector3();
    }

    private void UpdateObjectActivityOnKeyPress(GameObject child, KeyCode keyDown)
    {
        if (Input.GetKeyDown(keyDown))
        {
            child.SetActive(!child.activeSelf);
        }
    }

    private void UpdateCamera()
    {
        rotation.x += speed.x * -Input.GetAxis("Vertical");
        rotation.y -= speed.y * -Input.GetAxis("Horizontal");

        if (rotation.y < 0.0f)
        {
            rotation.y = 360.0f + rotation.y;
        }
        else
        {
            if (rotation.y > 360.0f)
            {
                rotation.y = 0.0f + (rotation.y - 360.0f);
            }
        }

        transform.eulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateObjectActivityOnKeyPress(smokeCanvas, KeyCode.T);
        UpdateObjectActivityOnKeyPress(fireCanvas, KeyCode.Y);
        UpdateObjectActivityOnKeyPress(fireExtinguisherCanvas, KeyCode.U);
        UpdateObjectActivityOnKeyPress(emergencyLight, KeyCode.I);

        UpdateObjectActivityOnKeyPress(soundEffect, KeyCode.O);

        if (audioVisualCanvas.activeSelf && soundEffect.activeSelf)
        {
            if (Scenarios.m_SoundEffectWWWBool && !soundEffectSource.isPlaying)
            {
                soundEffectSource.Play();
            }
        }
        else
        {
            if (soundEffectSource.isPlaying)
            {
                soundEffectSource.Stop();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Scenarios.m_StartBool = true;
        }

        if (!outTransition.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Scenarios.m_StartBool = false;
            }

            UpdateObjectActivityOnKeyPress(outTransition, KeyCode.P);
        }

        UpdateCamera();
    }
}