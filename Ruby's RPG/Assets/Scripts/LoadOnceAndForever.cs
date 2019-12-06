using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 /*
 * The object that carries this script is the responsible to keep alive between scenes the child objects that it has, and to destroy them in the main menu.
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
        if (false) { 
}
        if (!DontLoadAgain) {

            DontDestroyOnLoad(this.gameObject);

            if (SaveSystem.FileExists()) {
                PlayerData data = SaveSystem.LoadPlayer();
                Ruby.LoadRuby(data);
            }
            else {
                PlayerData data = Ruby.NewRuby();
                SaveSystem.SavePlayer(data);
            }
            Children = getFirstChildren(this.gameObject);



            foreach (GameObject child in Children) {
                child.SetActive(false);
            }

            DontLoadAgain = true;
        }
        else
            DestroyImmediate(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
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
