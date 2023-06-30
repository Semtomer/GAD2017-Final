using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;

        StartCoroutine(WaitForSceneLoad());
    }
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Start");
    }
}
