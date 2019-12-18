using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyController {


	public GameObject projectilePrefab;
	public float cogSpeed;

    // Start is called before the first frame update
    new protected void Start(){
        base.Start();
		intelligence = new StratShoot(this, projectilePrefab);
    }

    // Update is called once per frame
    new protected void Update()
    {
        base.Update();
    }
}
