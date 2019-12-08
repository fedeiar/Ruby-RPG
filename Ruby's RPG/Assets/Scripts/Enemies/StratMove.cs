using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StratMove : EnemyStrategy
{
    
	private EnemyController enemy;
	
	private Animator animator;
	private Rigidbody2D rigidbody;

	private float changeTime;
	private float timer;
	private int direction;
	

	public StratMove(EnemyController e){
		enemy = e;
		


		rigidbody = enemy.GetComponent<Rigidbody2D>();
		animator = enemy.GetComponent<Animator>();
		changeTime = 3.5f;
		direction = 0;
		timer = changeTime;
	}

	//-----------


	public override void action(){
		
		
		timer -= Time.deltaTime;
		if(timer < 0){ 
			direction = (direction + 1) % 4;
			Debug.Log("var direction is set to: "+ direction);
			timer = changeTime;
		}

		Vector2 position = rigidbody.position;

		if(direction == 0){
			animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", 1);
            position.y = position.y + Time.deltaTime * enemy.speed * 1;
		}
		if(direction == 1){
		    animator.SetFloat("Move X", 1);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + Time.deltaTime * enemy.speed * 1;
		}
		if(direction == 2){
			animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", -1);
            position.y = position.y + Time.deltaTime * enemy.speed * -1;
		}
		if(direction == 3){
            animator.SetFloat("Move X", -1);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + Time.deltaTime * enemy.speed * -1;
		}

		rigidbody.MovePosition(position);

	}
}
