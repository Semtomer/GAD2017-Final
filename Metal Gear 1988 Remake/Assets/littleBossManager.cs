using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class littleBossManager : MonoBehaviour
{
    public GameObject laser1;
    public GameObject laser2;

    public static bool isActive1;
    public static bool isActive2;

    private void Start()
    {
        laser1.gameObject.SetActive(false);
        laser2.gameObject.SetActive(true);

        isActive1 = false;
        isActive2 = true;
    }

    private void Update()
    {
       if(miniboss.enemyhealth <= 0)
        {
            laser1.gameObject.SetActive(false);
            laser2.gameObject.SetActive(false);

            isActive1 = false;
            isActive2 = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gamer")
        {
            StartCoroutine(wait());
        }
            
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        laser1.gameObject.SetActive(true);

        isActive1 = true;
    }
    
}
