using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    public static int FinalScore;
    public Text FinalScoreText;
    public GameObject LoseScreenUI;
    public GameObject HSSCreen;

    public Text HSText_1;
    public Text HSText_2;
    public Text HSText_3;
    public Text HSText_4;
    public Text HSText_5;

    public Text NewHSText;

    int[] HScore_PlaceHolder = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PauseScript>().enabled = false;
        DisableAllOtherUI();
        HishScorePlaceHolder();

        FinalScore = PlayerUI.totalScore;

        FinalScoreText.text = "Final Score: " + FinalScore;
        CheckForHighScore(FinalScore);
    }

    // Update is called once per frame
    void Update()
    {

        //Debug/
        //if (Input.GetKeyDown(KeyCode.Delete))
        //{
        //    PlayerPrefs.DeleteAll();
        //}
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        SceneManager.LoadScene("Start");
    }
    void DisableAllOtherUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
        LoseScreenUI.SetActive(true);
    }

    void HishScorePlaceHolder()
    {
        for (int i = 0; i < HScore_PlaceHolder.Length; i++)
        {
            HScore_PlaceHolder[i] = PlayerPrefs.GetInt("HighScore" + i, 0);

        }
    }

    public void CheckForHighScore(int value)
    {

        for (int i = 0; i < HScore_PlaceHolder.Length; i++)
        {

            if (value > HScore_PlaceHolder[i])
            {
                for (int j = HScore_PlaceHolder.Length - 1; j > i; j--)
                {
                    HScore_PlaceHolder[j] = HScore_PlaceHolder[j - 1];
                }

                HScore_PlaceHolder[i] = value;
                NewHighScore(i);
                break;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, HScore_PlaceHolder[i]);
        }
    }

    void PrintHighScore()
    {
        for (int i = 0; i < HScore_PlaceHolder.Length; i++)
        {
            Debug.Log(HScore_PlaceHolder[i] = PlayerPrefs.GetInt("HighScore" + i, 0));

        }
    } //Debug

    public void HighScoreScreen()
    {
        LoseScreenUI.SetActive(false);
        HSSCreen.SetActive(true);

        HSText_1.text = "1st Place : " + PlayerPrefs.GetInt("HighScore" + 0, 0);
        HSText_2.text = "2nd Place : " + PlayerPrefs.GetInt("HighScore" + 1, 0);
        HSText_3.text = "3rd Place : " + PlayerPrefs.GetInt("HighScore" + 2, 0);
        HSText_4.text = "4th Place : " + PlayerPrefs.GetInt("HighScore" + 3, 0);
        HSText_5.text = "5th Place : " + PlayerPrefs.GetInt("HighScore" + 4, 0);
    }

    void NewHighScore(int i)
    {
        NewHSText.text = "New HighScore #" + (i+1) + "!";
    }
}

