using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazershot : MonoBehaviour
{
    Collider2D coli;
    float time;

    //FMOD.Studio.EventInstance lazerEvent;
    public AudioSource lazerEvent;

    Transform ccamera;
    void Start()
    {
        //lazerEvent = FMODUnity.RuntimeManager.CreateInstance("event:/lazertime");

        coli = GetComponent<Collider2D>();
        coli.enabled = false;

    }
    
    void Update()
    {

        time += Time.deltaTime;
        if (time < 1)
        {
            transform.localScale = new Vector2(0.3f, 0.05f);
        }
        else if (time > 1)
        {
            transform.localScale = new Vector2(0.3f, 0.3f);
            coli.enabled = true;
            //lazerEvent.start();
            lazerEvent.Play();
            
        }
        if (time > 2)
        {
            gameObject.SetActive(false);
            coli.enabled = false;
            //lazerEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            lazerEvent.Stop();
            time = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camshaker.ShakeOnce();
            int cangötür = Random.Range(10, 16);
            karakterkontrol.health -= cangötür;
        }
    }
}
