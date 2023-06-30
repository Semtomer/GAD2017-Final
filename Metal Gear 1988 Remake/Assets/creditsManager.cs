using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsManager : MonoBehaviour
{
    public Animator creditAnim;

    void Start()
    {
        Cursor.visible = false;

        creditAnim.SetBool("isStart", true);
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(19f);
        SceneManager.LoadScene(1);
    }
}
