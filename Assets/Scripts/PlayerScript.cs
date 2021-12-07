using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    Animator playerAnimator; //Instantiate Animator for player
    Rigidbody2D prb;

    public float speedXAxis;
    public float jumpSpeed;
    public float health;
    public float score;
    public float levelScore;
    public int level;

    bool facingRight, jumping;
    float speed;


    void Start()
    {
        playerAnimator = GetComponent<Animator>(); //Instantiate Animator for player
        prb = GetComponent<Rigidbody2D>();
        facingRight = true;
        jumping = false;
        health = 3;
        levelScore = ScoreTracker.score; // at start of level set what score you start the level as
        if (level == 1) 
        {
            ScoreTracker.score = 0; // resets score whenever the game is started
        }
    }

    // Update is called once per frame
    void Update()
    {
        //changes Rigidbody velocity to move player
        PlayerMovement(speed);

        //flips the players scale so the sprite is looking the correct direction
        Flip();

        //move left
        if (Input.GetKey(KeyCode.A))
        {
            speed = -speedXAxis;
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                speed = speedXAxis;
            }
            else
            {
                speed = 0;
            }
        }
        //jump
        if (!jumping)
        {
            if (Input.GetKey(KeyCode.A))
            {
                playerAnimator.SetInteger("State", 1);
            }
            else
            {
                if (Input.GetKey(KeyCode.D))
                {
                    playerAnimator.SetInteger("State", 1);
                }
                else
                {
                    playerAnimator.SetInteger("State", 0);
                }
            }
                if (Input.GetKeyDown(KeyCode.Space))
            {
                jumping = true;
                prb.AddForce(new Vector2(prb.velocity.x, jumpSpeed));
                playerAnimator.SetInteger("State", 2);

            }
            
        }
        //game over when health reaches 0
        if(health == 0)
        {
            if (level == 1)
            {
                ScoreTracker.score = levelScore; //reset score to what it was at the start of the level
                SceneManager.LoadScene("Game Over");
            }
            if (level == 2)
            {
                ScoreTracker.score = levelScore;
                SceneManager.LoadScene("Game Over2");
            }
            if (level == 3)
            {
                ScoreTracker.score = levelScore;
                SceneManager.LoadScene("Game Over3");
            }

        }
        
        if(score == 10) // gives extra health whenever score reaches 10 
        {
            ScoreTracker.score += score;
            score = 0;
            health++;
        }
    }

    void PlayerMovement(float playerSpeed)
    {
        prb.velocity = new Vector2(playerSpeed, prb.velocity.y);
    }

    void Flip()
    {
        if(speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scaleTemp = transform.localScale;
            scaleTemp.x *= -1;
            transform.localScale = scaleTemp;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            jumping = false;
            playerAnimator.SetInteger("State", 0);
        }

    }

    private void OnGUI()
    {
        if (level == 4)
        {
            GUI.Label(new Rect(10, 10, 200, 40), "FINAL SCORE: " + ScoreTracker.score);
        }
        else { 
            GUI.Label(new Rect(10, 10, 100, 20), "Health: " + health);
            GUI.Label(new Rect(10, 40, 100, 20), "Score: " + (score + ScoreTracker.score));
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
             health = health - 1;
            if (facingRight)
            {
                prb.AddForce(new Vector2(-7000, 10));

            }
            else
            {
                prb.AddForce(new Vector2(7000, 10));
            }
            
            
        }
        if (collision.gameObject.tag == "Door")
        {
            ScoreTracker.score += score;
            SceneManager.LoadScene("Beat Level 1");
        }
        if (collision.gameObject.tag == "Door2")
        {
            ScoreTracker.score += score;
            SceneManager.LoadScene("Beat Level 2");
        }
        if (collision.gameObject.tag == "Door3")
        {
            ScoreTracker.score += score;
            SceneManager.LoadScene("Beat Level 3");
        }


    }




}

public static class ScoreTracker {
    public static float score { get; set; }
}