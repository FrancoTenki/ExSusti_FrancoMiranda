using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float defaultVelocityX = 15;
    Rigidbody2D rb;
    GameObject gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector2(defaultVelocityX, rb.velocity.y);
        // gameManager.GetComponent<GameManagerController>().ReduceBullets();

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            gameManager.GetComponent<GameManagerController>().ReduceBullets();
        }
    }
}
