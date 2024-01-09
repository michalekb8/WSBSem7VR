using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModelRotation : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.LookAt(new Vector3(player.position.x, 1.7f, player.position.z));
        transform.Rotate(Vector3.up, 90.0f);
    }
}
