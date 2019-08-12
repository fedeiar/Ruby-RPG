using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public ParticleSystem HitEffect;
    public AudioClip cogSound;

    private Rigidbody2D rigidbody2d;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
        audioSource.PlayOneShot(cogSound);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }

        Instantiate(HitEffect, rigidbody2d.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
