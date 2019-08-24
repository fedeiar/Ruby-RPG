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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void EnemyFixed() {
        enemies--;
        if (enemies == 0) {
            VictoryPanel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    private void VictoryPanel() {
        //TO-DO
        
    }
}
