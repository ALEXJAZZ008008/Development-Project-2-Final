using UnityEngine;

public class OculusCameraPositionLock : MonoBehaviour
{
    public GameObject oculusCamera;

    // Update is called once per frame
    void Update()
    {
        transform.position -= oculusCamera.transform.position;
    }
}