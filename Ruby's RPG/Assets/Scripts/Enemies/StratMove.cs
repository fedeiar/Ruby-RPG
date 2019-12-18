using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StratMove : EnemyStrategy
{
    
	
	

	public StratMove(EnemyController e) : base(e){
		
	}

	//-----------


	public override void action(){
		
		
		base.standardMovement();

	}
}
