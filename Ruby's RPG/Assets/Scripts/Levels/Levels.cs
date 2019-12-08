using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{

    protected int enemies;

    private void OnLevelWasLoaded(int level)
    {
		if(level != SceneNumber.Menu){ 
			enemies = 0;
        
			foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject))){
				if(String.Equals(obj.tag, "Enemy")){
					enemies++;
					EnemyController enemy = obj.GetComponent<EnemyController>();
					enemy.SetActiveLevel(this);
				}
			}
		}
    }



    public void EnemyFixed() {
        enemies--;
        if (enemies == 0) {
			if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			else{
				VictoryPanel();
				Debug.Log("Victory!");
			}

        }

    }


    private void VictoryPanel() {
        //TO-DO
        
    }
}
