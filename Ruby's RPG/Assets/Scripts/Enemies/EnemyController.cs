using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour {

    public float speed = 3.0f;
	public float changeTime;
	public bool vertical;
	public bool sideways;
	
    
    public ParticleSystem smokeEffect;
	public AudioClip fixClip;

    protected RubyController Ruby;
	public RubyController ruby{
		get{
			return Ruby;
		}
	}

    protected new Rigidbody2D rigidbody2D;
    protected Levels ActiveLevel;
    protected Animator animator;

	protected EnemyStrategy intelligence;

    protected bool broken;
    protected AudioSource walkSound;

    
    // Start is called before the first frame update
    protected void Start(){
        
        rigidbody2D = GetComponent<Rigidbody2D>();
        broken = true;
        walkSound = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();

        Ruby = GameObject.Find("Ruby").GetComponent<RubyController>();

		intelligence = new StratMove(this);		
    }

    // Update is called once per frame
    protected void Update(){

        if (!broken){
            return;
        }
        
		intelligence.action();
        
    }

    //public because we want to call it from elsewhere like the projectile script
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
        walkSound.Stop();
		walkSound.loop = false;
		walkSound.PlayOneShot(fixClip);
        ActiveLevel.EnemyFixed();

        Ruby.AddExperience(20f);
        
    }

    public void SetActiveLevel(Levels level) {
        ActiveLevel = level;
    }

	protected void OnCollisionEnter2D(Collision2D other){

		RubyController player = other.gameObject.GetComponent<RubyController>();

		if (player != null){

			player.ChangeHealth(-1);
		}
	}

}