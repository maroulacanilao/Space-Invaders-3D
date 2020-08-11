using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    public Text scoreText;
    public static int totalScore;
    void Start()
    {
        totalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + totalScore;
    }
}
