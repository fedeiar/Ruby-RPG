using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    
	public void MainMenu(){
		RubyController ruby = GameObject.Find("Ruby").GetComponent<RubyController>();
		ruby.ChangeHealth(RubyController.maxHealth);
		SceneManager.LoadScene("Menu");
	}
}
