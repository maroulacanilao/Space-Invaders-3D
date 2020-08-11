using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Text TitleText;
    public Text HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void CheckHighScore()
    {
        TitleText.enabled = false;
        HighScoreText.enabled = true;
    }
    

    public void Quit()
    {
        Debug.Log("CLICK");
    }


}
