using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyProjectile : Projectile
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
        
        EnemyController e = other.gameObject.GetComponent<EnemyController>();
		
        if (e != null)
        {
            e.Fix();
        }

        SelfDestroy();
    }

	public void SelfDestroy(){
		Instantiate(HitEffect, rigidbody2d.position, Quaternion.identity);
        Destroy(gameObject);
	}



}
