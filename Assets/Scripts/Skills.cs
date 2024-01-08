using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    //Strength variables
    [Header("Strength")]
    [SerializeField] float strengthPower = 6f;
    [HideInInspector] public bool hasStrength = false;
    public GameObject strengthVFX;

    //Shockwave variables
    [Header("Shockwave")]
    public float detectionRadius = 5f;
    public GameObject shockwaveVFX;

    //Freeze variables
    [Header("Freeze")]
    [SerializeField] float freezeTime = 3f;
    Rigidbody[] enemiesRb;
    GameObject[] enemiesGo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, detectionRadius);
    //}

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

    public void Shockwave()
    {
        shockwaveVFX.GetComponent<ParticleSystem>().Play();
        Collider[] enemiesInRadius = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var enemy in enemiesInRadius)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Vector3 awayFromPlayer = enemy.transform.position - transform.position;
                enemy.attachedRigidbody.AddForce(awayFromPlayer * strengthPower, ForceMode.Impulse);
            }
        }
    }

    public void Freeze()
    {
        enemiesGo = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesRb = new Rigidbody[enemiesGo.Length];
        for (int i = 0; i < enemiesGo.Length; i++)
        {
            enemiesRb[i] = enemiesGo[i].GetComponent<Rigidbody>();
        }
        //Debug.Log("Ilosc: " + enemiesRb.Length);
        StartCoroutine(FreezeForTime(freezeTime));
    }

    IEnumerator FreezeForTime(float operationTime)
    {
        float startTime = Time.time;

        while (Time.time - startTime < operationTime)
        {
            StayStill();
            yield return null;
        }
        foreach (GameObject enemy in enemiesGo)
        {
            EnemyController script = enemy.GetComponent<EnemyController>();
            script.enabled = true;
        }
    }

    void StayStill()
    {
        foreach (GameObject enemy in enemiesGo)
        {
            EnemyController script = enemy.GetComponent<EnemyController>();
            script.enabled = false;
        }
        foreach (var enemy in enemiesRb)
        {
            enemy.velocity = new Vector3(0, 0, 0);
        }
    }
}
