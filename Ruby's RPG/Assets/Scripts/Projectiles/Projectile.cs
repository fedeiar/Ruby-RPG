using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{

    public ParticleSystem HitEffect;
    public AudioClip cogSound;

    protected Rigidbody2D rigidbody2d;
    protected AudioSource audioSource;

    
    protected void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }


    public void Launch(Vector2 direction, float force){
        rigidbody2d.AddForce(direction * force);
        audioSource.PlayOneShot(cogSound);
		
    }

    
    protected abstract void OnCollisionEnter2D(Collision2D other);
    
    



}
