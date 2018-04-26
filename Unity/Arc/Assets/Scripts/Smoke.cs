using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public GameObject smokePrefab;

    public int smokeIntensity;

    private List<GameObject> smokeList;

    void Awake()
    {
        smokeList = new List<GameObject>();
    }

    void OnEnable()
    {
        float angle = 360 / smokeIntensity;

        int count = 0;

        Vector4 temporarySmokeArc = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
        Vector2 currentAngle = new Vector2(0.0f, 0.0f);

        for (int i = 0; i < Arc.m_SmokeArc.Count / 4; i++)
        {
            count = 0;

            if (Arc.m_SmokeArc[i * 4] < Arc.m_SmokeArc[(i * 4) + 1])
            {
                temporarySmokeArc[0] = Arc.m_SmokeArc[i * 4];
                temporarySmokeArc[1] = Arc.m_SmokeArc[(i * 4) + 1];
            }
            else
            {
                temporarySmokeArc[0] = Arc.m_SmokeArc[i * 4];
                temporarySmokeArc[1] = 360.0f + Arc.m_SmokeArc[(i * 4) + 1];
            }

            if (Arc.m_SmokeArc[(i * 4) + 2] < Arc.m_SmokeArc[(i * 4) + 3])
            {
                temporarySmokeArc[2] = Arc.m_SmokeArc[(i * 4) + 2];
                temporarySmokeArc[3] = Arc.m_SmokeArc[(i * 4) + 3];
            }
            else
            {
                temporarySmokeArc[2] = Arc.m_SmokeArc[(i * 4) + 2];
                temporarySmokeArc[3] = 360.0f + Arc.m_SmokeArc[(i * 4) + 3];
            }

            currentAngle = new Vector2(temporarySmokeArc[0], temporarySmokeArc[2]);

            for (int j = 0; j < smokeIntensity; j++)
            {
                if (currentAngle.x <= temporarySmokeArc[1])
                {
                    currentAngle.y = temporarySmokeArc[2];

                    for (int k = 0; k < smokeIntensity; k++)
                    {
                        if (currentAngle.y <= temporarySmokeArc[3])
                        {
                            count++;

                            smokeList.Add(Instantiate(smokePrefab));

                            if (count % 2 == 0)
                            {
                                smokeList[smokeList.Count - 1].transform.RotateAround(Vector3.zero, Vector3.right, currentAngle.y);
                                smokeList[smokeList.Count - 1].transform.RotateAround(Vector3.zero, Vector3.up, currentAngle.x);
                            }
                            else
                            {
                                smokeList[smokeList.Count - 1].transform.RotateAround(Vector3.zero, Vector3.right, currentAngle.y);
                                smokeList[smokeList.Count - 1].transform.RotateAround(Vector3.zero, Vector3.up, currentAngle.x + (angle / 2));
                            }
                        }
                        else
                        {
                            break;
                        }

                        currentAngle.y += angle;
                    }
                }
                else
                {
                    break;
                }

                currentAngle.x += angle;
            }
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < smokeList.Count; i++)
        {
            Destroy(smokeList[i]);
        }

        smokeList.Clear();
    }
}