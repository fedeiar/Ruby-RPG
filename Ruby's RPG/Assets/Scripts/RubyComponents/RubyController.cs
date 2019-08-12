using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyController : MonoBehaviour {

    public float speed = 3.0f;
    
    
    

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private Vector2 lookDirection = new Vector2(1, 0);
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
     
    }

    public void PlaySound(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update() {


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 move = new Vector2(horizontal, vertical);

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
    }


    



}
