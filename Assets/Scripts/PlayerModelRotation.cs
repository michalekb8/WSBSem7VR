using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelRotation : MonoBehaviour
{
    Transform mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        transform.LookAt(new Vector3(mainCamera.position.x, 1.7f, mainCamera.position.z));
        transform.Rotate(Vector3.up, -90.0f);
        //Vector3 directionToCamera = mainCamera.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(directionToCamera, Vector3.up);
        //transform.rotation = rotation;
    }
}
