using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CameraRotation cameraRotation;
    // Start is called before the first frame update
    void Start()
    {
        cameraRotation = GetComponent<CameraRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cameraRotation.rotationSpeed = 400f;
        }
        else
        {
            cameraRotation.rotationSpeed = 200f;
        }
    }
}
