using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody rb;
    public GameObject VFX;
    public GameObject Owner;
    public int damage = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != Owner)
        {
            var VFXX = Instantiate(VFX, transform.position, transform.rotation);
            Destroy(VFXX, VFXX.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
            
        }
    }
}
