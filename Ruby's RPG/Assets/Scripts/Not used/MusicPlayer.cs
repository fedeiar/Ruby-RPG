using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static GameObject _instance;

    private void Awake() {

        if (_instance == null) {
            _instance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            DestroyImmediate(this.gameObject);

        
    }
}
