using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyController : MonoBehaviour {

    private float speed = 3.0f;
    //---
    public const int maxHealth = 5;
    private float timeInvincible = 2.0f;
    private int currentHealth;
    public int health {
        get {
            return currentHealth;
        }
    }
    private bool isInvincible;
    private float invincibleTimer;
    //---

    public Slider expSlider;

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
    //---

    public GameObject projectilePrefab;
    //---

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private Vector2 lookDirection = new Vector2(1, 0);
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        currentHealth = maxHealth;

        maxExperience = expSlider.maxValue;

        expSlider.value = currentExperience;
    }

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

        if (Input.GetKeyDown(KeyCode.C)) {
            Launch();
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
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

    }

    private void Launch() {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");

    }

    public void AddExperience(float xp) {

        Debug.Log("XP received: " + xp);
        Debug.Log("Before: " + currentExperience);
        if (currentExperience + xp >= maxExperience) {
            LevelUp();
            currentExperience = xp - (maxExperience - currentExperience);
        }
        else
            currentExperience += xp;
        Debug.Log("After: " + currentExperience);


        expSlider.value = currentExperience;
    }

    private void LevelUp() {
        currentLevel++;
    }

    public PlayerData RubyData() {

        return new PlayerData(this);
    }

    public void LoadRuby(PlayerData data) {
    
        currentLevel = data.level;
        currentExperience = data.experience;
		expSlider.value = currentExperience;
        
    }

}
