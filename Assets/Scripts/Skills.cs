using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public bool hasStrength = false;
    float strengthPower = 15f;
    public GameObject strengthVFX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasStrength)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * strengthPower, ForceMode.Impulse);
        }
    }

    public void Strength()
    {
        hasStrength = true;
        strengthVFX.SetActive(true);
        StartCoroutine(PowerupCountdownRoutine());
    }
    public IEnumerator PowerupCountdownRoutine()
    {
        Debug.Log("pocz¹tek sily");
        yield return new WaitForSeconds(7);
        strengthVFX.SetActive(false);
        Debug.Log("koniec sily");
        hasStrength = false;
    }
}
