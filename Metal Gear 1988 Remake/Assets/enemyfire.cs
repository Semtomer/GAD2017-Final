using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfire : MonoBehaviour
{
    Transform player;
    public GameObject bullet;
    float timetoshot;

    public static FMOD.Studio.EventInstance gunShoot2;

    public LayerMask playerrr;
    public LayerMask Wall;
    bool attackrange = false;
    float attackradius = 8;
    public bool bossbu = false;
    float zaman = 21;

    private void Awake()
    {
        gunShoot2 = FMODUnity.RuntimeManager.CreateInstance("event:/ShootingWeapon/rifleShoot");
    }

    void Start()
    {
        player = GameObject.FindWithTag("Gamer").GetComponent<Transform>();
        //sound = GameObject.FindWithTag("enriflesound").GetComponent<AudioSource>();
    }
    void Update()
    {
        if(bossbu == false)
        {
            Vector2 dirtoplayer = (player.position - transform.position).normalized;
            float distancetoplayer = Vector2.Distance(transform.position, player.position);
            if (!Physics2D.Raycast(transform.position, dirtoplayer, distancetoplayer, Wall) /*&& bulletfire.firedsound == false*/ && karakterkontrol.Ýnbox == false)
            {
                attackrange = Physics2D.OverlapCircle(transform.position, attackradius, playerrr);
                if (attackrange == true)
                {
                    timetoshot += Time.deltaTime;
                    if (timetoshot > 1f)
                    {
                        Instantiate<GameObject>(bullet, transform.position, Quaternion.identity);
                        gunShoot2.start();
                        timetoshot = 0;
                    }
                }
            }
        }
        else if(bossbu == true)
        {
            Vector2 dirtoplayer = (player.position - transform.position).normalized;
            float distancetoplayer = Vector2.Distance(transform.position, player.position);
            zaman += Time.deltaTime;
            if (!Physics2D.Raycast(transform.position, dirtoplayer, distancetoplayer, Wall) && karakterkontrol.Ýnbox == false)
            {
                attackrange = Physics2D.OverlapCircle(transform.position, attackradius, playerrr);
                if (attackrange == true)
                {
                    timetoshot += Time.deltaTime;
                    
                    if (zaman < 20)
                    {
                        if (timetoshot > 0.3f)
                        {
                            Instantiate<GameObject>(bullet, transform.position, Quaternion.identity);
                            gunShoot2.start();
                            timetoshot = 0;
                        }
                    }
                    if(zaman >= 20)
                    {
                        if (timetoshot > 0.6f)
                        {
                            Instantiate<GameObject>(bullet, transform.position, Quaternion.identity);
                            gunShoot2.start();
                            timetoshot = 0;
                        }
                    }
                    if(zaman > 100)
                    {
                        zaman = 0;
                    }
                    
                    
                }
            }
        }
        

            
        
        if(EnemyAI.Aimway == 1 || VenomSnack.Aimway == 1 || tankboss.Aimway == 1 || miniboss.Aimway == 1) 
        {
            transform.localPosition = new Vector2(-1, -0.4f);        
        }
        else if(EnemyAI.Aimway == 2 || VenomSnack.Aimway == 2 || tankboss.Aimway == 2 || miniboss.Aimway == 2)
        {
            transform.localPosition = new Vector2(1, -0.4f);
        }
        else if (EnemyAI.Aimway == 3 || VenomSnack.Aimway == 3 || tankboss.Aimway == 3 || miniboss.Aimway == 3)
        {
            transform.localPosition = new Vector2(-0.45f, -0.85f);
        }
        else if (EnemyAI.Aimway == 4 || VenomSnack.Aimway == 4 || tankboss.Aimway == 4 || miniboss.Aimway == 4)
        {  
            transform.localPosition = new Vector2(0.45f, 0.85f);
        }

    }
}
