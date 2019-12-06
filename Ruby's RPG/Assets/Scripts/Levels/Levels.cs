using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Levels : MonoBehaviour
{

    protected int enemies;
    public EnemyController Bot;

    
    protected void Awake()
    {
        enemies = 0;
        
		foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject))){
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

	protected void AddEnemy(float x, float y, float z) {
        Debug.Log("level01");
        EnemyController inst_bot = Instantiate(Bot, new Vector3(x, y, z), Quaternion.identity);
        inst_bot.SetActiveLevel(this);
        enemies++;
    }

    private void VictoryPanel() {
        //TO-DO
        
    }
}
