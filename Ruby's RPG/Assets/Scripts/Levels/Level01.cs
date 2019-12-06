using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01 : Levels
{
    
    new void Awake()
    {
        base.Awake();

        for (int i = 0; i < 3; i++) {
            AddEnemy(i, 0, 0);
        }
        
		foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject))){
			Debug.Log(obj.tag);
			
		}
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

   

    
}
