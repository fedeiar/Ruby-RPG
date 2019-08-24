using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01 : Levels
{
    
    new void Awake()
    {
        base.Awake();

        for (int i = 0; i < 3; i++) {
            AddEnemy(i, 0, 0);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void AddEnemy(float x, float y, float z) {
        Debug.Log("level01");
        EnemyController inst_bot = Instantiate(Bot, new Vector3(x, y, z), Quaternion.identity);
        inst_bot.SetActiveLevel(this);
        enemies++;
    }

    
}
