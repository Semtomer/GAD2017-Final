using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagesymbol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(1, 3);
        dsa = GetComponent<CanvasGroup>();
    }

    float t = 1f;
    int random;
    float speed = 3f;
    public Transform[] ways;
    CanvasGroup dsa;
     public bool thatisrifle;
    void Update()
    {
        //Vector2 pos = transform.position;
        //ways[0].position = transform.position;
        //float dif = Vector2.Distance(ways[0].position, ways[1].position);
        //float fsf = transform.position.magnitude;
        //
        //ways[0].position = transform.position;
        Vector3 pos = new Vector3(6, 111, 0);
        Vector3 pos1 = new Vector3(0, -6, 0);
        dsa.alpha = t;
        t -= Time.deltaTime * speed;
        if(random == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, ways[0].position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, ways[1].position, Time.deltaTime * speed);
        }

        if(t <= 0f)
        {
            if(thatisrifle == true)
            {
                transform.localPosition = pos;
                gameObject.SetActive(false);
            }
            else
            {
                transform.localPosition = pos1;
                gameObject.SetActive(false);
            }
            t = 1f;
        }


    }

    
}
