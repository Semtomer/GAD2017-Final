using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granadescript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        coli = GetComponent<Collider2D>();
    }

    Collider2D coli;
    Rigidbody2D rigi;
    float speed = 250;
    float time = 50;
    public GameObject explosioneffect;
    SpriteRenderer spi;
    float timetopass = 1.3f;

    public static FMOD.Studio.EventInstance bomb;

    private void Awake()
    {
        bomb = FMODUnity.RuntimeManager.CreateInstance("event:/realexplosion");
    }

    void Update()
    {
        rigi.velocity = transform.up * speed * Time.deltaTime;
        time -= Time.deltaTime * 25;
        if (timetopass > 1.2f)
        {
            if (karakterkontrol.yönkararý == 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (karakterkontrol.yönkararý == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (karakterkontrol.yönkararý == 2)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (karakterkontrol.yönkararý == 3)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            timetopass = 0;
        }
        if (time <= 1)
        {
            
            bomb.start();
            coli.enabled = true;
            Instantiate<GameObject>(explosioneffect, transform.position, Quaternion.identity);
            Destroy(gameObject,0.07f);
        }
    }
}
