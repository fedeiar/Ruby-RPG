using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StratShoot : EnemyStrategy
{
    

	private const float shoot_time = 4f;
	private float shoot_timer;

	private GameObject projectilePrefab;
	new private EnemyShooter enemy;
	//-----------

	public StratShoot(EnemyShooter e, GameObject projectile) : base(e){
		enemy = e;
		shoot_timer = shoot_time;
		projectilePrefab = projectile;
	}


	//-----------
	public override void action(){ 
	
		standardMovement();

		shoot_timer -= Time.deltaTime;

		if(shoot_timer < 0){
			shoot();
			shoot_timer = shoot_time;
		}
		
	
	}

	private void shoot(){
		GameObject projectileObject = Object.Instantiate(projectilePrefab, rigidbody.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
		Vector2 A = enemy.ruby.gameObject.GetComponent<Rigidbody2D>().position;
		Vector2 B = enemy.gameObject.GetComponent<Rigidbody2D>().position;
		Vector2 direction = new Vector2(A.x - B.x, A.y - B.y);
		
		//Debug.Log("pos x = " +pos.x+" y = "+pos.y );
		direction.Normalize();
		
		
        projectile.Launch(direction, enemy.cogSpeed);

	}
}
