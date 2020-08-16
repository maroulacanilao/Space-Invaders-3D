using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text scoreText;
    public static int totalScore;

    public Slider healthSlider;
    public Image Fill;
    

    Stats mStats;

    void Start()
    {
        totalScore = 0;
        mStats = this.gameObject.GetComponent<Stats>();
    }

    void Update()
    {
        scoreText.text = "" + totalScore;
        HealthBar();
    }

    void HealthBar()
    {
        healthSlider.value = mStats.calculateHealth();
        if (mStats.getCurrentHp() >= 4)
        {
            Fill.color = Color.green;
        }
        if ((mStats.getCurrentHp() ==3 || mStats.getCurrentHp() == 2))
        {
            Fill.color = Color.yellow + Color.red;
        }
        if (mStats.getCurrentHp() ==1)
        {
            Fill.color = Color.red;
        }

        if (mStats.calculateHealth() <= 0)
        {
            //YouLoseText.gameObject.SetActive(true);
            Fill.color = Color.black;
            //Time.timeScale = 0;
        }
    }

 
}
