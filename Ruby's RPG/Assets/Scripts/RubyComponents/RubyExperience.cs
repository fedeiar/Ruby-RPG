using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyExperience : MonoBehaviour
{


    private Slider expSlider;

    private float experience;
    private int level;
    private float maxExperience;

    // Start is called before the first frame update
    void Start()
    {
        expSlider = GameObject.Find("ExpBar").GetComponent<Slider>();

        maxExperience = expSlider.maxValue;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addExperience(float xp) {

        if (experience + xp >= maxExperience) {
            levelUp();
            experience = xp - (maxExperience - experience);
        }
        else
            experience += experience + xp;

        expSlider.value = experience;
    }

    private void levelUp() {
        level++;
    }

}
