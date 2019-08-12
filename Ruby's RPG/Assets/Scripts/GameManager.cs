using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    private static GameManager inst_gm;
    private GameObject canvas;

    private void Awake() {

        if (inst_gm == null) {
            inst_gm = this;
        }
        else
            Destroy(this.gameObject);


        DontDestroyOnLoad(this.gameObject);

        
    }

    private void OnLevelWasLoaded(int level) {
        
    }

    void Update()
    {
        
    }
}
