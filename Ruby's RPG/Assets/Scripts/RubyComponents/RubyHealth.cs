using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyHealth : MonoBehaviour
{

    public const int maxHealth = 5;
    public float timeInvincible = 2.0f;

    private Animator animator;
    private AudioSource audioSource;

    private int currentHealth;
    public int health {
        get {
            return currentHealth;
        }
    }

    private bool isInvincible;
    private float invincibleTimer;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
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

    public void PlaySound(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }
}
