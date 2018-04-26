using API;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject fireCanvas;
    public GameObject smokeCanvas;

    public Text instructionText1;
    public Text instructionText2;
    public Text instructionText3;

    public Vector3 speed;

    private List<float> fireArc;
    private List<float> smokeArc;

    private Vector3 rotation;

    void Awake()
    {
        instructionText1.text = "Press Q to save and quit, press R to reset";

        instructionText2.text = "Start fire selection with F";

        instructionText3.text = "Start smoke selection with E";

        fireArc = new List<float>();
        smokeArc = new List<float>();

        rotation = new Vector3();
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch ((smokeArc.Count + 2) % 4)
            {
                case 1:

                    smokeArc.Add(mainCamera.transform.rotation.eulerAngles.x);

                    if (smokeCanvas.activeSelf)
                    {
                        smokeCanvas.SetActive(false);
                    }

                    Arc.m_SmokeArc = smokeArc;

                    smokeCanvas.SetActive(true);

                    instructionText3.text = "Select left point of smoke with E";

                    break;

                case 2:

                    smokeArc.Add(mainCamera.transform.rotation.eulerAngles.y);

                    instructionText3.text = "Select right point of smoke with E";

                    break;

                case 3:

                    smokeArc.Add(mainCamera.transform.rotation.eulerAngles.y);

                    instructionText3.text = "Select top point of smoke with E";

                    break;

                case 0:

                    smokeArc.Add(mainCamera.transform.rotation.eulerAngles.x);

                    instructionText3.text = "Select bottom point of smoke with E";

                    break;
            }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            switch ((fireArc.Count + 2) % 4)
            {
                case 1:

                    fireArc.Add(mainCamera.transform.rotation.eulerAngles.x);

                    if (fireCanvas.activeSelf)
                    {
                        fireCanvas.SetActive(false);
                    }

                    Arc.m_FireArc = fireArc;

                    fireCanvas.SetActive(true);

                    instructionText2.text = "Select left point of fire with F";

                    break;

                case 2:

                    fireArc.Add(mainCamera.transform.rotation.eulerAngles.y);

                    instructionText2.text = "Select right point of fire  with F";

                    break;

                case 3:

                    fireArc.Add(mainCamera.transform.rotation.eulerAngles.y);

                    instructionText2.text = "Select top point of fire  with F";

                    break;

                case 0:

                    fireArc.Add(mainCamera.transform.rotation.eulerAngles.x);

                    instructionText2.text = "Select bottom point of fire  with F";

                    break;
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (fireCanvas.activeSelf)
            {
                fireCanvas.SetActive(false);
            }

            fireArc.Clear();

            Arc.m_FireArc = fireArc;

            fireCanvas.SetActive(true);

            if (smokeCanvas.activeSelf)
            {
                smokeCanvas.SetActive(false);
            }

            smokeArc.Clear();

            Arc.m_SmokeArc = smokeArc;

            smokeCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            string output = string.Empty;

            List<List<float>> arcList = new List<List<float>>();

            arcList.Add(fireArc);
            arcList.Add(smokeArc);

            JSONParser.TObjectToJSON(ref output, arcList);

            using (StreamWriter streamWriter = new StreamWriter(Arc.m_UniqueOutputPath))
            {
                streamWriter.WriteLine(output);
            }

            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Arc.m_NextScenario++;

            if(Arc.m_NextScenario > Arc.scenarioList.GetScenarios().Count - 1)
            {
                Arc.m_NextScenario = 0;
            }

            Arc.m_UpdateScenario = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Arc.m_NextScenario--;

            if (Arc.m_NextScenario < 0)
            {
                Arc.m_NextScenario = Arc.scenarioList.GetScenarios().Count - 1;
            }

            Arc.m_UpdateScenario = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        UpdateCamera();
    }
}