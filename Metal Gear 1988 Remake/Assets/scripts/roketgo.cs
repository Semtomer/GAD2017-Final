using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roketgo : MonoBehaviour
{
    FMOD.Studio.EventInstance RocketGoEvent;
    FMOD.Studio.EventInstance ExplosionEvent;

    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "undertank")
        {
            RocketGoEvent = FMODUnity.RuntimeManager.CreateInstance("event:/tankfire");
        }
        else
        {
            RocketGoEvent = FMODUnity.RuntimeManager.CreateInstance("event:/roketfire");
        }
        
        ExplosionEvent = FMODUnity.RuntimeManager.CreateInstance("event:/realexplosion");
    }

    void Update()
    {
        if (!config)
        {
            StartCoroutine("pathtogoo");
        }
    }

    public Transform[] path;
    public GameObject finisheffect;
    private void OnDrawGizmos()
    {
        for (float t = 0f; t <= 1f; t += 0.05f)
        {
            Vector2 posatt = Mathf.Pow((1 - t), 3) * path[0].position
                + 3 * Mathf.Pow((1 - t), 2) * t * path[1].position
                + 3 * (1 - t) * t * path[2].position + Mathf.Pow(t, 3) * path[3].position;

            Gizmos.DrawSphere(posatt, 0.15f);


        }
        Gizmos.color = Color.red;
        Gizmos.DrawLine(path[0].position, path[1].position);
        Gizmos.DrawLine(path[2].position, path[3].position);
    }
    [SerializeField] float speed;
    float t = 0;
    bool config = false;
    public GameObject go;
    public bool otherdirection = true;
    IEnumerator pathtogoo()
    {
        config = true;

        RocketGoEvent.start();

        while (t <= 1)
        {
            t += speed * Time.deltaTime;
            Vector3 posat = Mathf.Pow((1 - t), 3) * path[0].position
                + 3 * Mathf.Pow((1 - t), 2) * t * path[1].position
                + 3 * (1 - t) * t * path[2].position + Mathf.Pow(t, 3) * path[3].position;

            // Quaternion lookrotatoion = Quaternion.FromToRotation(transform.forward,posat - transform.position);
            //transform.rotation = lookrotatoion;
            if(otherdirection == true)
            {
                go.transform.rotation = Quaternion.FromToRotation(Vector2.right, posat - go.transform.position);
                go.transform.position = posat;
            }
            else
            {
                go.transform.rotation = Quaternion.FromToRotation(-Vector2.right, posat - go.transform.position);
                go.transform.position = posat;
            }
            //transform.LookAt(posat - transform.position, Vector3.right * -1);
            transform.position = posat;

            yield return new WaitForEndOfFrame();
        }
        t = 0;
        gameObject.SetActive(false);
        config = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("pathtogoo");
            gameObject.SetActive(false);
            t = 0;
            config = false;
            camshaker.ShakeOnce();
            Instantiate<GameObject>(finisheffect, transform.position, Quaternion.identity);
            int cangötür = Random.Range(10, 16);
            karakterkontrol.health -= cangötür;
            ExplosionEvent.start();
        }
    }
}
