using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    Transform focalPoint;
    public float rotationSpeed = 200.0f;
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            focalPoint.transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }
}
