using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Page : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }

    public void StartB()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitB()
    {
        Application.Quit();
    }
}
