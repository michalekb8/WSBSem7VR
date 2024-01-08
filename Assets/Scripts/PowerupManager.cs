using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public Powerup powerupType;
    Skills skillsController;
    public enum Powerup
    {
        Strength,
        Shockwave,
        Freeze,
        Heal
    }
    // Start is called before the first frame update
    void Start()
    {
        skillsController = GameObject.Find("Player").GetComponent<Skills>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Strength()
    {
        //playerRb.mass = 200;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (powerupType)
            {
                case Powerup.Strength:
                    {
                        Debug.Log("strength");
                        skillsController.Strength();
                        Destroy(gameObject);
                        break;
                    }
                case Powerup.Shockwave:
                    {
                        Debug.Log("shockwave");
                        skillsController.Shockwave();
                        Destroy(gameObject);
                        break;
                    }
                case Powerup.Freeze:
                    {
                        Debug.Log("freeze");
                        break;
                    }
                case Powerup.Heal:
                    {
                        Debug.Log("heal");
                        break;
                    }

            }


        }
    }
}
