using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private Animator anim;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = (Input.GetAxis("Horizontal"));
        body.velocity = new Vector2(horizInput * speed, body.velocity.y);

        if (horizInput > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        if (horizInput < 0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        anim.SetBool("Idle run", horizInput != 0);
        anim.SetBool("Grounded", grounded);

    }

    private void Jump()
    { 
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        anim.SetTrigger("Jump");
        grounded = false;   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;

    }
}

