using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escapeController : MonoBehaviour
{
    public GameObject EscapeBox;

    float time;
    bool timestop;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;

            openingAnim();
            //
            timestop = true;      
        }

        if(timestop == true)
        {
            time += Time.deltaTime;
            if(time > 0.7f)
            {
                Time.timeScale = 0.01f;
                timestop = false;
                time = 0;
            }
        }
    }

    void openingAnim()
    {
        EscapeBox.SetActive(true);
    }

    public void ResumeButton()
    {
        EscapeBox.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
