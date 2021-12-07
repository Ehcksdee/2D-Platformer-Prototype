using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public double time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        time--;
        if (time == 0)
        {
            SceneManager.LoadScene("Game Over3");
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(100, 10, 100, 20), "Time: " + time);
        
    }
}
