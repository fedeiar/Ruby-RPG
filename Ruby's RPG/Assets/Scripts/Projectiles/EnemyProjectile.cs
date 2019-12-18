using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    
	
	

	protected new void Awake(){
		base.Awake();
	}



    // Update is called once per frame
    void Update() {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

	protected override void OnCollisionEnter2D(Collision2D other){
        

        RubyController r = other.gameObject.GetComponent<RubyController>();
        if (r != null)
        {
            r.ChangeHealth(-1);
        }

        Instantiate(HitEffect, rigidbody2d.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
