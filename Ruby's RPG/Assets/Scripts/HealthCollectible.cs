using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour {


    public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other){

        RubyHealth r_health = other.GetComponent<RubyHealth>();

        if (r_health != null){

            if (r_health.health < RubyHealth.maxHealth) {
                r_health.ChangeHealth(1);
                Destroy(gameObject);

                r_health.PlaySound(collectedClip);
            }
        }
    }
}
