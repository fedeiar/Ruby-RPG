using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour {
	
	public GameObject defeatCanvas;
	public RubyController ruby;

	public void LoadMenu(){
		ruby.ChangeHealth(RubyController.maxHealth);
		ruby.enabled = true;
		defeatCanvas.SetActive(false);
		SceneManager.LoadScene("Menu");
	}

}
