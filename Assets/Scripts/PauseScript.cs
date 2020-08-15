using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseMenu_Panel;
    public GameObject QuitMenu_Panel;
    public GameObject PlayerUI;

    public static bool IsGamePaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsGamePaused) Pause();
            else Resume();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        PauseMenu_Panel.SetActive(true);
        QuitMenu_Panel.SetActive(false);
        IsGamePaused = true;
        PlayerUI.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu_Panel.SetActive(false);
        QuitMenu_Panel.SetActive(false);
        PlayerUI.SetActive(true);
        IsGamePaused = false;
    }

    public void Quitbtn()
    {
        PauseMenu_Panel.SetActive(false);
        QuitMenu_Panel.SetActive(true);
        IsGamePaused = true;
    }

    public void yesQuit()
    {
        SceneManager.LoadScene("Start");
    }
}
