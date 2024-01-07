using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CameraRotation cameraRotation;
    public TextMeshProUGUI scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        cameraRotation = GetComponent<CameraRotation>();

        scoreText.text = "Punkty: " + score;
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

    public void IncreasePoints()
    {
        score++;
        scoreText.text = "Punkty: " + score;
    }
}
