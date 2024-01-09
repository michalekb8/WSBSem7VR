using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] GameObject MainUI;
    [SerializeField] GameObject GameOver;

    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Time.timeScale = 0;
            MainUI.SetActive(false);
            GameOver.SetActive(true);
            Debug.Log("Game Over!");
        }
    }
}
