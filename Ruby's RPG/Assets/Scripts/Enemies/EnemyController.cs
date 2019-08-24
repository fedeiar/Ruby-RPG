using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;
    public ParticleSystem smokeEffect;
    private RubyController Ruby;
    
    private new Rigidbody2D rigidbody2D;

    private Levels ActiveLevel;
    private Animator animator;
    private float timer;
    private int direction = 1;
    private bool broken;
    AudioSource walkSound;

    
    // Start is called before the first frame update
    private void Start(){
       
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        broken = true;
        walkSound = GetComponent<AudioSource>();

        Ruby = GameObject.Find("Ruby").GetComponent<RubyController>();
    }

    // Update is called once per frame
    private void Update(){

        if (!broken){
            return;
        }
        
  
        timer -= Time.deltaTime;
        Console.WriteLine("timer: " + timer);

        if (timer < 0) {
            direction = -direction;
            timer = changeTime;
        }


        Vector2 position = rigidbody2D.position;

        if (vertical){
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
            position.y = position.y + Time.deltaTime * speed * direction;

        }
        else{
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        rigidbody2D.MovePosition(position);
    }

    //Public because we want to call it from elsewhere like the projectile script
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
        walkSound.Stop();
        ActiveLevel.EnemyFixed();

        Ruby.AddExperience(20f);
        
    }

    public void SetActiveLevel(Levels level) {
        ActiveLevel = level;
    }
}