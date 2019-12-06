using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02 : Levels
{
    
    new void Awake()
    {
        base.Awake();

		foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject))){
			Debug.Log(obj.tag);
			if(String.Equals(obj.tag, "Enemy")){
				enemies++;
				EnemyController enemy = obj.GetComponent<EnemyController>();
				enemy.SetActiveLevel(this);
			}
		}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
