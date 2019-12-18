using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{

    protected int enemies;

	public GameObject panel_victory;
	public AudioClip victoryClip;

	private AudioSource audioSource;
	//---------------------------------------

	private void Start(){
		audioSource = GetComponent<AudioSource>();
	}

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
			if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1){ 
				StartCoroutine(VictoryPanel(3f));
			}
			else{
				Debug.Log("No more scenes to load");
			}

        }

    }

	public IEnumerator VictoryPanel(float pauseTime){
		
		
		panel_victory.SetActive(true);
		audioSource.PlayOneShot(victoryClip);

		Time.timeScale = 0f;
		float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
		while (Time.realtimeSinceStartup < pauseEndTime) {
			yield return 0;
		}
		Time.timeScale = 1f;

		panel_victory.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		
		
	}

	
	
}
