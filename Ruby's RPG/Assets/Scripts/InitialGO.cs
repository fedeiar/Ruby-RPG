using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialGO : MonoBehaviour {
    
	private static int maxGO = 3;
	private static int currentGO = 0; 

    private void Awake() {
        if (currentGO < maxGO) {
			currentGO++;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            DestroyImmediate(this.gameObject);
    }
}
