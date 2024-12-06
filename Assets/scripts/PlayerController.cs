using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed =5;
    private Animator animator;
    public GameObject BulletPref;   
    private GameManagerController gameManagerController;
    private bool Dead=false;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        gameManagerController = GameObject.Find("GameManager").GetComponent<GameManagerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
        // rb.velocity=new Vector2(10,rb.velocity.y);
        if(speed>0){
            transform.Translate(Vector2.right * speed *Time.deltaTime);
            animator.SetInteger("salto",3);
        }
        
        if(Input.GetKeyUp(KeyCode.Space)){
            rb.velocity=new Vector2(rb.velocity.x,10);
            animator.SetInteger("salto",5);
        }

        if(Input.GetKeyUp(KeyCode.R)){
            gameManagerController.ResetGame();
        }

        if(Input.GetKeyUp(KeyCode.X) && gameManagerController.getBullets() > 0)
        {
            GameObject bullet = Instantiate(BulletPref, transform.position, Quaternion.identity);
            gameManagerController.ReduceBullets();
        }
        if(Dead){
            // rb.velocity=new Vector2(0,0);
            speed=0;
            animator.SetInteger("salto",0);
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy") {
                Debug.Log("Colision con Enemigo");
                Dead=true;
                
                // gameManagerController.GetComponent<GameManagerController>().RemoveLife();

            }        
        }
}
