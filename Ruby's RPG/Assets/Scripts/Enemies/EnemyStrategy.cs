using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EnemyStrategy {
    
	protected EnemyController enemy;
	
	protected Animator animator;
	protected Rigidbody2D rigidbody;

	protected float timer;
	protected int direction;
	//-------------

	public EnemyStrategy(EnemyController e){
		enemy = e;
		

		
		rigidbody = enemy.GetComponent<Rigidbody2D>();
		animator = enemy.GetComponent<Animator>();
		direction = 0;
		timer = enemy.changeTime;
	}


	//-------------
	public abstract void action();


	protected void standardMovement(){
		if (enemy.sideways){
			moveSideways();
		}
		else
			if(enemy.vertical)
				moveVertical();
			else
				moveInAllWays();

	}
	
	private void moveVertical(){
		timer -= Time.deltaTime;
		if(timer < 0){ 
			direction = (direction + 1) % 2;
			timer = enemy.changeTime;
		}

		Vector2 position = rigidbody.position;

		if(direction == 0){ //hacia arriba
			animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", 1);
            position.y = position.y + Time.deltaTime * enemy.speed * 1;
		}

		if(direction == 1){ //hacia abajo
			animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", -1);
            position.y = position.y + Time.deltaTime * enemy.speed * -1;
		}

		rigidbody.MovePosition(position);
	}

	private void moveSideways(){
		timer -= Time.deltaTime;
		if(timer < 0){ 
			direction = (direction + 1) % 2;
			timer = enemy.changeTime;
		}

		Vector2 position = rigidbody.position;

		if(direction == 0){ //hacia la derecha
		    animator.SetFloat("Move X", 1);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + Time.deltaTime * enemy.speed * 1;
		}

		if(direction == 1){ //hacia la izquierda
            animator.SetFloat("Move X", -1);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + Time.deltaTime * enemy.speed * -1;
		}

		rigidbody.MovePosition(position);

	}

	private void moveInAllWays(){
		timer -= Time.deltaTime;
		if(timer < 0){ 
			direction = (direction + 1) % 4;
			timer = enemy.changeTime;
		}

		Vector2 position = rigidbody.position;

		if(direction == 3){ //hacia arriba
			animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", 1);
            position.y = position.y + Time.deltaTime * enemy.speed * 1;
		}
		if(direction == 0){ //hacia la derecha
		    animator.SetFloat("Move X", 1);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + Time.deltaTime * enemy.speed * 1;
		}
		if(direction == 1){ //hacia abajo
			animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", -1);
            position.y = position.y + Time.deltaTime * enemy.speed * -1;
		}
		if(direction == 2){ //hacia la izquierda
            animator.SetFloat("Move X", -1);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + Time.deltaTime * enemy.speed * -1;
		}

		rigidbody.MovePosition(position);
	}

}
