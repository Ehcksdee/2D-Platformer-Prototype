using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{

    Rigidbody2D srb;
    public int track; //current value 
    public int max; //maximum value 
    // Start is called before the first frame update
    void Start()
    {
        srb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        if (track > 0)
        {
            srb.velocity = new Vector2(-2, srb.velocity.y); //move left
            track--;//count down
            if (track == 1)//when it hits 1
            {
                track -= max;//current value is now -max value
            }
        }
        if (track < 0)
        {
            srb.velocity = new Vector2(2, srb.velocity.y); //move right
            track++;//count up
            if (track == -1)//when it hits -1
            {
                track = max;//current value is now max value
            }
        }

    }
}
