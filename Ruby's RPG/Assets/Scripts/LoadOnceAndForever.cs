using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 /*
 * The object that carries this script is the responsible to keep alive between scenes the child objects that it has, and to deactivate them in the main menu.
 * These child objects are objects that are present in every scene(level) except in the MainMenu
 */ 
public class LoadOnceAndForever : MonoBehaviour
{


    private GameObject[] Children;
    public RubyController Ruby;
    private static bool DontLoadAgain = false;

    //we use Awake() so it executes before OnLevelWasLoaded(...)
    void Awake()
    {
     
        if (!DontLoadAgain) {

            DontDestroyOnLoad(this.gameObject);

			PlayerData data;
            if (SaveSystem.FileExists()) {
                data = SaveSystem.LoadPlayer();
            }
            else {
                data = new PlayerData();
                SaveSystem.SavePlayer(data);
            }
			Ruby.LoadRuby(data);
            Children = getFirstChildren(this.gameObject);



            foreach (GameObject child in Children) {
                child.SetActive(false);
            }

            DontLoadAgain = true;
        }
        else
            DestroyImmediate(this.gameObject);

    }
 

    private void OnLevelWasLoaded(int level) {
        
        if (level == SceneNumber.Menu) { 
            foreach (GameObject child in Children) {
                child.SetActive(false);
            }
            
        } 
        else {
            foreach (GameObject child in Children) {
                child.SetActive(true);
            }
        }

        PlayerData data = Ruby.RubyData();
        SaveSystem.SavePlayer(data);
    }

	public void DeleteData(){ 
		PlayerData newData = SaveSystem.DeleteData();
		Ruby.LoadRuby(newData);
	}


    private GameObject[] getFirstChildren(GameObject parent) {
        Transform[] allObjects = parent.GetComponentsInChildren<Transform>(); //warning: it includes the parent gameobject too
        Children = new GameObject[allObjects.Length - 1];

        int i = 0;

        foreach (Transform GO in allObjects) {
            if (GO.gameObject != this.gameObject) {
                Children[i] = GO.gameObject;
                i++;
            }
        }

        return Children;
    }
}
