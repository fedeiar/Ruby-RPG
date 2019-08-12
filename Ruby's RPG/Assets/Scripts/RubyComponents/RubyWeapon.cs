using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyWeapon : MonoBehaviour
{

    public GameObject projectilePrefab;

    private Animator animator;
    private Vector2 lookDirection = new Vector2(1, 0);
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }


        if (Input.GetKeyDown(KeyCode.C)) {
            Launch();
        }
    }

    void Launch() {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
        
    }
}
