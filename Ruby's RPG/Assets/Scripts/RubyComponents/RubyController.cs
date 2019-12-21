using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyController : MonoBehaviour {

    private float speed = 3.0f;
	

    public const int maxHealth = 5;
    private int currentHealth;
    public int health {
        get {
            return currentHealth;
        }
    }

	private float timeInvincible = 2.0f;
    private bool isInvincible;
    private float invincibleTimer;
    //-------

    public Slider expSlider;
	public TMPro.TextMeshProUGUI levelText;
	
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

    private float maxExperience;
    //------

    public GameObject projectilePrefab;
	private float shoot_timer;
	private const float shoot_time = 0.3f;

    public GameObject defeatCanvas;
	public AudioClip hitClip;
	
	//------

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private Vector2 lookDirection = new Vector2(1, 0);
    private AudioSource audioSource;

	private Vector2 initial_position;
	//---------------------------------------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start() {

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        currentHealth = maxHealth;

        maxExperience = expSlider.maxValue;

        expSlider.value = currentExperience;
		levelText.text = ""+currentLevel;

		initial_position = rigidbody2d.position;

		shoot_timer = shoot_time;
		
    }

	//------------------------------------------------------------------------------------------------------------
	
    public void PlaySound(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }
	
    // Update is called once per frame
    void Update() {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 move = new Vector2(horizontal, vertical);
        
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position;

		
        position = position + move * speed * Time.deltaTime;


        rigidbody2d.MovePosition(position);
        

        if (Input.GetKeyDown(KeyCode.X)) {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null) {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null) {
                    character.DisplayDialog();
                }
            }
        }

		shoot_timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.C) && (shoot_timer < 0) ) {
            Launch();
			shoot_timer = shoot_time;
        }

        if (isInvincible) {

            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }


    }

    public void ChangeHealth(int amount) {

        if (amount < 0) {
            animator.SetTrigger("Hit");
			
            if (isInvincible)
                return;

			
            isInvincible = true;
            invincibleTimer = timeInvincible;
			PlaySound(hitClip);
		}

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

		if(currentHealth == 0){
			
			this.GetComponent<RubyController>().enabled = false;
			defeatCanvas.SetActive(true);
		}

        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

    }

    private void Launch() {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
		
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");

    }

    public void AddExperience(float xp) {

        
        if (currentExperience + xp >= maxExperience) {
            LevelUp();
            currentExperience = xp - (maxExperience - currentExperience);
        }
        else
            currentExperience += xp;
        

        expSlider.value = currentExperience;
    }

    private void LevelUp() {
        currentLevel++;
		levelText.text = ""+currentLevel;
    }

    public PlayerData RubyData() {

        return new PlayerData(this);
    }

    public void LoadRuby(PlayerData data) {
    
        currentLevel = data.level;
        currentExperience = data.experience;
		expSlider.value = currentExperience;
		levelText.text = ""+currentLevel;
        
    }

	public void ResetPosition(){
		if(rigidbody2d != null) //because of the first call (when ruby appears for the first time) before start()
			rigidbody2d.position = initial_position;
	}

}
