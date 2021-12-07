using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = player.position.x;
        float playerY = player.position.y;
        float z = transform.position.z;
        transform.position = new Vector3(playerX, playerY, z);
    }
}
