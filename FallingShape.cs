using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingShape : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;     //Currently = 5
    public float dropSpeed;     //Currently = -1
    private bool dropped;
    private float currentMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        dropped = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        // Drop block
        if(Input.GetKeyDown("space") & !dropped)
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 1;
            dropped = true;
            gameObject.tag = "bad";
        }

        // Move block left and right
        if(!dropped)
        {
            if(Input.GetKey("right"))
            {
                currentMoveSpeed = moveSpeed;
            }
            else if(Input.GetKey("left"))
            {
                currentMoveSpeed = -1 * moveSpeed;
            }
            else
            {
                currentMoveSpeed = 0;
            }

            rb.velocity = new Vector2(currentMoveSpeed, dropSpeed);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "bad")
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 1;
            dropped = true;
            gameObject.tag = "bad";
        }
    }
}
