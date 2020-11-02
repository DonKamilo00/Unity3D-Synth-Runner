using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    private Rigidbody rb;

    float bulletSpeed;

    public float destroys = 4;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        bulletSpeed = 10;

        Destroy(gameObject, destroys);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.right * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
