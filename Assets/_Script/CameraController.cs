using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float cameraGap = 2f;
    [SerializeField]
    private float cameraHeight = 1f;

    float rotX;
    float rotY;

    [SerializeField]
    private float minVarAngle = -45f;
    [SerializeField]
    private float maxVarAngle = 45f;

    // Update is called once per frame
    void Update()
    {

        rotX += Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, minVarAngle, maxVarAngle);
        rotY += Input.GetAxis("Mouse X");

        ThirdPerson();

    }

    public void ThirdPerson()
    {
        var targetRotation = Quaternion.Euler(rotX, rotY, 0);

        transform.position = target.position - targetRotation * new Vector3(0f, cameraHeight, cameraGap);
        transform.rotation = targetRotation;
    }

    public Quaternion flatRoation => Quaternion.Euler(0, rotY, 0);
}


