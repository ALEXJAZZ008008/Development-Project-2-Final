using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject firePrefab;

    public int fireIntensity;

    private List<GameObject> fireList;

    void Awake()
    {
        fireList = new List<GameObject>();
    }

    void OnEnable()
    {
        float angle = 360 / fireIntensity;

        int count = 0;

        Vector4 temporaryFireArc = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
        Vector2 currentAngle = new Vector2(0.0f, 0.0f);

        for (int i = 0; i < Scenarios.m_FireArc.Count / 4; i++)
        {
            count = 0;

            if (Scenarios.m_FireArc[i * 4] < Scenarios.m_FireArc[(i * 4) + 1])
            {
                temporaryFireArc[0] = Scenarios.m_FireArc[i * 4];
                temporaryFireArc[1] = Scenarios.m_FireArc[(i * 4) + 1];
            }
            else
            {
                temporaryFireArc[0] = Scenarios.m_FireArc[i * 4];
                temporaryFireArc[1] = 360.0f + Scenarios.m_FireArc[(i * 4) + 1];
            }

            if (Scenarios.m_FireArc[(i * 4) + 2] < Scenarios.m_FireArc[(i * 4) + 3])
            {
                temporaryFireArc[2] = Scenarios.m_FireArc[(i * 4) + 2];
                temporaryFireArc[3] = Scenarios.m_FireArc[(i * 4) + 3];
            }
            else
            {
                temporaryFireArc[2] = Scenarios.m_FireArc[(i * 4) + 2];
                temporaryFireArc[3] = 360.0f + Scenarios.m_FireArc[(i * 4) + 3];
            }

            currentAngle = new Vector2(temporaryFireArc[0], temporaryFireArc[2]);

            for (int j = 0; j < fireIntensity; j++)
            {
                if (currentAngle.x <= temporaryFireArc[1])
                {
                    currentAngle.y = temporaryFireArc[2];

                    for (int k = 0; k < fireIntensity; k++)
                    {
                        if (currentAngle.y <= temporaryFireArc[3])
                        {
                            count++;

                            fireList.Add(Instantiate(firePrefab));

                            if (count % 2 == 0)
                            {
                                fireList[fireList.Count - 1].transform.RotateAround(Vector3.zero, Vector3.right, currentAngle.y);
                                fireList[fireList.Count - 1].transform.RotateAround(Vector3.zero, Vector3.up, currentAngle.x);
                            }
                            else
                            {
                                fireList[fireList.Count - 1].transform.RotateAround(Vector3.zero, Vector3.right, currentAngle.y);
                                fireList[fireList.Count - 1].transform.RotateAround(Vector3.zero, Vector3.up, currentAngle.x + (angle / 2));
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
        for (int i = 0; i < fireList.Count; i++)
        {
            Destroy(fireList[i]);
        }

        fireList.Clear();
    }
}