using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CameraRotation cameraRotation;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int score = 1;

    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        cameraRotation = GetComponent<CameraRotation>();

        scoreText.text = "Runda: " + score;
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Time.timeScale = 0;
            mainUI.SetActive(false);
            pause.SetActive(true);
            Debug.Log("Pauza");
        }
    }

    public void IncreasePoints()
    {
        score++;
        if (PlayerPrefs.GetInt("Highscore") < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        scoreText.text = "Punkty: " + score;
    }
}
