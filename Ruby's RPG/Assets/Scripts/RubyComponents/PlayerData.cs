using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private float currentExperience;
    public float experience {
        get {
            return currentExperience;
        }
    }

    private int currentLevel;
    public int level {
        get {
            return currentLevel;
        }
    }

    //-----------------------------

    public PlayerData(RubyController Ruby) {
        currentLevel = Ruby.level;
        currentExperience = Ruby.experience;
    }

    //When creating a new file
    public PlayerData() {
        currentLevel = 0;
        currentExperience = 0;
    }
    
}
