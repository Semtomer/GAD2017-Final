using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camerafollow : MonoBehaviour
{
    public float followspeed = 2f;
    public Transform Player;
    CanvasGroup misfail;
    public GameObject oyuncu;
    void Start()
    {
        misfail = GetComponent<CanvasGroup>();
    }

    public bool thatiscam = true;
    float deathtimeing;
    void Update()
    {
        if(thatiscam == true)
        {
            Vector3 newpos = new Vector3(Player.position.x, Player.position.y, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, newpos, followspeed * Time.deltaTime);
            newpos.Normalize();
        }
        else if(thatiscam == false)
        {
            if(oyuncu == null)
            {
                deathtimeing += Time.deltaTime / 5;
                misfail.alpha = deathtimeing;
                if (deathtimeing > 1.2f)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            /*else if(karakterkontrol.health <= 0)
            {
                deathtimeing += Time.deltaTime / 5;
                misfail.alpha = deathtimeing;
                if (deathtimeing > 1.2f)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }*/
            
        }
        
    }
}
