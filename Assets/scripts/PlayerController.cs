using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed =5;
    private Animator animator;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        // rb.velocity=new Vector2(10,rb.velocity.y);
        transform.Translate(Vector2.right * speed *Time.deltaTime);
            animator.SetInteger("salto",3);
        

        if(Input.GetKeyUp(KeyCode.Space)){
            rb.velocity=new Vector2(rb.velocity.x,10);
            animator.SetInteger("salto",5);
        }

    }
}
