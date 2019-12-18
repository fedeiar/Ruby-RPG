using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour {


    public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other){
		
        RubyController r_health = other.GetComponent<RubyController>();

        if (r_health != null){

            if (r_health.health < RubyController.maxHealth) {
                r_health.ChangeHealth(1);
                Destroy(gameObject);

                r_health.PlaySound(collectedClip);
            }
        }
    }
}
