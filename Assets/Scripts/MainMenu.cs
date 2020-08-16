using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text HSText_1;
    public Text HSText_2;
    public Text HSText_3;
    public Text HSText_4;
    public Text HSText_5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckHighScore();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("CLICK");
    }

    public void CheckHighScore()
    {
        HSText_1.text = "1st Place : " + PlayerPrefs.GetInt("HighScore" + 0, 0);
        HSText_2.text = "2nd Place : " + PlayerPrefs.GetInt("HighScore" + 1, 0);
        HSText_3.text = "3rd Place : " + PlayerPrefs.GetInt("HighScore" + 2, 0);
        HSText_4.text = "4th Place : " + PlayerPrefs.GetInt("HighScore" + 3, 0);
        HSText_5.text = "5th Place : " + PlayerPrefs.GetInt("HighScore" + 4, 0);
    }

}
