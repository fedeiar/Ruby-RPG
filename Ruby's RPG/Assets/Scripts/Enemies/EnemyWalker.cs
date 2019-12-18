using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : EnemyController {
    


	
	// Start is called before the first frame update
    new protected void Start(){
        base.Start();
		intelligence = new StratMove(this);
    }

    // Update is called once per frame
    new protected void Update()
    {
        base.Update();
    }
}
