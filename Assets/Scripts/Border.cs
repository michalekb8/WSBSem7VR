using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            gm.IncreasePoints();
            Debug.Log("+1");
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Time.timeScale = 0;
            Debug.Log("Game Over!");
        }
    }
}
