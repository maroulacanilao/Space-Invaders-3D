using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    public static int FinalScore;
    public Text FinalScoreText;
    public Text HighScoreText;
    public GameObject PUI;
    // Start is called before the first frame update
    void Start()
    {
        PUI.SetActive(false);
        FinalScore = PlayerUI.totalScore;

        FinalScoreText.text = "Final Score: \n" + FinalScore;

        //if (FinalScore > PlayerPrefs.GetInt("HighScore", 0))
        //{
        //    PlayerPrefs.SetInt("HighScore", FinalScore);
        //}
        //HighScoreText.text = "High Score: \n" + PlayerPrefs.GetInt("HighScore", 0).ToString();

        FinalScore = 50;
        //for (int i = 0; i < 7;i++)
        //{
        //    PlayerPrefs.SetInt("HighScore" + i, 0);
        //}


        for (int i=0;i<5;i++)
        {
            string l = PlayerPrefs.GetInt("HighScore" + i, 0).ToString();
            Debug.Log(l);
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        SceneManager.LoadScene("Start");
    }
}
