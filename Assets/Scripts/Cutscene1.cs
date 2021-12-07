using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cutscene1 : MonoBehaviour
{
    public void Play2()
    {
        SceneManager.LoadScene("Cutscene1_2");
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
