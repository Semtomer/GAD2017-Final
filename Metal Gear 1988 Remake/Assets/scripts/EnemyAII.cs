using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAII : MonoBehaviour
{
    private Transform target;

    private NavMeshAgent enemy;

    private Animator ani;

    private SpriteRenderer spite;
    private Animator camanim;

    public static FMOD.Studio.EventInstance backgroundMusic;
    public static FMOD.Studio.EventInstance getStabWound;
    public static FMOD.Studio.EventInstance noticed;
    public static FMOD.Studio.EventInstance whenHit;
    public static FMOD.Studio.EventInstance whenFight;
    //public GameObject backgroundMusic;

    bool attackrange = false;
    public float attackradius;

    public LayerMask playerrr;
    public LayerMask Wall;

    float attackduration;
    float extradur;
    bool timetohit;

    int enemyhealth = 100;

    public Slider enemyhealthbar;
    Rigidbody2D rigigid;
    //private AudioSource actionmusic;
    private void Awake()
    {
        backgroundMusic = FMODUnity.RuntimeManager.CreateInstance("event:/main_theme");
        getStabWound = FMODUnity.RuntimeManager.CreateInstance("event:/GetStabWound");
        noticed = FMODUnity.RuntimeManager.CreateInstance("event:/SFX");
        whenHit = FMODUnity.RuntimeManager.CreateInstance("event:/whenhit");
        whenFight = FMODUnity.RuntimeManager.CreateInstance("event:/actionMusic2");
    }

    void Start()
    {
        target = GameObject.FindWithTag("Gamer").transform;
        camanim = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        spite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
        enemy.updateRotation = false;
        enemy.updateUpAxis = false;
        rigigid = GetComponent<Rigidbody2D>();
        enemyhealth = (int)enemyhealthbar.maxValue;
        //actionmusic = GameObject.FindWithTag("EditorOnly").GetComponent<AudioSource>();
    }
    Vector2 lastposition2;
    public Transform lastposition;
    bool detected = false;
    public static float detectedradius = 5;
    public GameObject effect;
    bool athisposition;

    int herhangi;
    [Range(0, 360)] public float viewangle;
    float forgetduration;
    public Transform[] t;
    float hitpushway;
    float zamanlama;
    float zamanlama2;
    public GameObject detectedsign;
    
    void Update()
    {
       /* if (karakterkontrol.actiontime < 5)
        {
            //backgroundMusic.SetActive(false);
            //actionmusic.volume = 0.2f;

            backgroundMusic.setVolume(0f);
            whenFight.setVolume(1f);
            
        }
        else
        {
            //actionmusic.volume = 0.0f;
            //backgroundMusic.SetActive(true);

            backgroundMusic.setVolume(1f);
            whenFight.setVolume(0f);
        }*/
        //print("zaman : " + zamanlama);
        //print("attack : " + attackduration);
        enemyhealthbar.value = enemyhealth;
        attackduration += Time.deltaTime;
        lastposition2.x = lastposition.position.x;
        lastposition2.y = lastposition.position.y;
        attackrange = Physics2D.OverlapCircle(transform.position, attackradius, playerrr);
        detected = Physics2D.OverlapCircle(transform.position, detectedradius, playerrr);
        //print(herhangi);
        if (enemyhealth <= 0)
        {
            //spite.enabled = false;
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
            Instantiate<GameObject>(effect, transform.position, Quaternion.identity);
            int coinbetween = Random.Range(5, 16);
            sellersystem.Coin += coinbetween;
            Destroy(gameObject);
        }
        if(transform.position.x >= lastposition2.x - 0.5f && transform.position.x <= lastposition2.x + 0.5f && transform.position.y >= lastposition2.y - 0.5f && transform.position.y <= lastposition2.y + 0.5f)
        {
            athisposition = true;
            //print("içeride");
        }
        else
        {
           // print("daþarýda");
            athisposition = false;
        }
        Vector2 dirtoplayer = (target.position - transform.position).normalized;
        if (Vector2.Angle(transform.forward, dirtoplayer) < viewangle / 2)
        {
            //print("görüldü");
            float distancetoplayer = Vector2.Distance(transform.position, target.position);
            if (detected == true)
            {
                zamanlama += Time.deltaTime;
                if (!Physics2D.Raycast(transform.position, dirtoplayer, distancetoplayer, Wall) && bulletfire.firedsound == false)
                {

                    //whenFight.start();
                   
                    if(karakterkontrol.Ýnbox == false)
                    {
                        karakterkontrol.actiontime = 0;


                        if (zamanlama < 0.1f)
                        {
                            noticed.start();
                        }
                        if (zamanlama < 0.25f)
                        {
                            detectedsign.SetActive(true);
                        }
                        else if (zamanlama > 0.5f)
                        {
                            detectedsign.SetActive(false);
                        }
                        enemy.stoppingDistance = 1.3f;
                        float x = target.position.x - transform.position.x;
                        float y = target.position.y - transform.position.y;
                        if (pullback == true)
                        {
                            if (hitpushway == 1)
                            {
                                enemy.SetDestination(t[0].position);
                            }
                            else if (hitpushway == 2)
                            {
                                enemy.SetDestination(t[1].position);
                            }
                            else if (hitpushway == 3)
                            {
                                enemy.SetDestination(t[2].position);
                                enemy.speed = 3;
                            }
                            else if (hitpushway == 4)
                            {
                                enemy.SetDestination(t[3].position);
                            }
                            spite.color = Color.red;
                        }
                        else if (pullback == false)
                        {
                            try
                            {
                                enemy.SetDestination(target.position);
                            }
                            catch { }
                            spite.color = Color.white;
                            enemy.speed = 1.5f;
                        }

                        if ((target.position.x < transform.position.x) && y > x)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 1);
                            spite.flipX = false;
                            hitpushway = 4;
                            enemy.speed = 1.5f;
                        }
                        else if ((target.position.x > transform.position.x) && y < x)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 1);
                            spite.flipX = true;
                            hitpushway = 3;
                            enemy.speed = 1.5f;
                        }
                        else if ((target.position.y < transform.position.y) && x > y)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", -1);
                            spite.flipX = false;
                            hitpushway = 1;
                            enemy.speed = 3;
                        }
                        else if ((target.position.y > transform.position.y) && x < y)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 0);
                            spite.flipX = false;
                            hitpushway = 2;
                            enemy.speed = 1.5f;
                        }
                    }
                }
                else if(bulletfire.firedsound == true)
                {
                    zamanlama2 += Time.deltaTime;
                    if(zamanlama2 < 5)
                    {
                        if (zamanlama < 0.1)
                        {
                            noticed.start();
                        }
                        if (zamanlama < 0.25f)
                        {
                            detectedsign.SetActive(true);
                        }
                        else if (zamanlama > 0.5f)
                        {
                            detectedsign.SetActive(false);
                        }
                        enemy.stoppingDistance = 1.3f;
                        float x = target.position.x - transform.position.x;
                        float y = target.position.y - transform.position.y;
                        if (pullback == true)
                        {
                            if (hitpushway == 1)
                            {
                                enemy.SetDestination(t[0].position);
                            }
                            else if (hitpushway == 2)
                            {
                                enemy.SetDestination(t[1].position);
                            }
                            else if (hitpushway == 3)
                            {
                                enemy.SetDestination(t[2].position);
                                enemy.speed = 3;
                            }
                            else if (hitpushway == 4)
                            {
                                enemy.SetDestination(t[3].position);
                            }
                            spite.color = Color.red;
                        }
                        else if (pullback == false)
                        {
                            try
                            {
                                enemy.SetDestination(target.position);
                            }
                            catch { }
                            spite.color = Color.white;
                            enemy.speed = 1.5f;
                        }

                        if ((target.position.x < transform.position.x) && y > x)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 1);
                            spite.flipX = false;
                            hitpushway = 4;
                            enemy.speed = 1.5f;
                        }
                        else if ((target.position.x > transform.position.x) && y < x)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 1);
                            spite.flipX = true;
                            hitpushway = 3;
                            enemy.speed = 1.5f;
                        }
                        else if ((target.position.y < transform.position.y) && x > y)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", -1);
                            spite.flipX = false;
                            hitpushway = 1;
                            enemy.speed = 3;
                        }
                        else if ((target.position.y > transform.position.y) && x < y)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 0);
                            spite.flipX = false;
                            hitpushway = 2;
                            enemy.speed = 1.5f;
                        }
                    }
                    else if(zamanlama2 > 5)
                    {
                        detectedradius = 5;
                        zamanlama2 = 0;
                        bulletfire.firedsound = false;
                    }
                }
                
            }
            else
            {
                //whenFight.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                
                zamanlama = 0;
                if (athisposition == false)
                {
                    enemy.stoppingDistance = 0.5f;
                    forgetduration += Time.deltaTime;
                    if (forgetduration > 1f)
                    {
                        float x = lastposition.position.x - transform.position.x;
                        float y = lastposition.position.y - transform.position.y;
                        enemy.SetDestination(lastposition.position);
                        if ((lastposition.position.x < transform.position.x) && y > x)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 1);
                            spite.flipX = false;
                        }
                        else if ((lastposition.position.x > transform.position.x) && y < x)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 1);
                            spite.flipX = true;
                        }
                        else if ((lastposition.position.y < transform.position.y) && x > y)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", -1);
                            spite.flipX = false;
                        }
                        else if ((lastposition.position.y > transform.position.y) && x < y)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 0);
                            spite.flipX = false;
                        }
                        forgetduration = 0;
                    }
                }
                else
                {

                    ani.SetBool("walk", true);
                    ani.SetFloat("durma", herhangi);

                }

                
            }
        }



        if (attackrange == true && pullback == false && karakterkontrol.Ýnbox == false)
        {
            //enemy.SetDestination(target.position);
            if (attackduration > 0.2f && attackduration <= 0.8f)
            {
                float x = target.position.x - transform.position.x;
                float y = target.position.y - transform.position.y;
                hurtsound = true;
                if ((target.position.x < transform.position.x) && y > x)
                {
                    ani.SetFloat("vuruþ", 0);
                    spite.flipX = false;
                }
                else if ((target.position.x > transform.position.x) && y < x)
                {
                    ani.SetFloat("vuruþ", 0);
                    spite.flipX = true;
                }
                else if ((target.position.y < transform.position.y) && x > y)
                {
                    ani.SetFloat("vuruþ", 1);
                    spite.flipX = false;
                }
                else if ((target.position.y > transform.position.y) && x < y)
                {
                    ani.SetFloat("vuruþ", -1);
                    spite.flipX = false;

                }
                if (attackduration > 0.6f && attackduration < 0.605f)
                {
                    karakterkontrol.health -= 5;
                    Instantiate<GameObject>(bloodeffect, target.position, Quaternion.identity);
                    karakterkontrol.spi.color = Color.red;
                    getStabWound.start();
                    whenHit.start();
                    //camanim.SetBool("shake1", true);

                }
                else if (attackduration > 0.7f)
                {
                    karakterkontrol.spi.color = Color.white;
                    //camanim.SetBool("shake1", false);
                }

                timetohit = true;
            }
            else if (attackduration > 0.8f)
            {
                timetohit = false;
                hurtsound = false;
            }
            
            if (timetohit == true)
            {
                extradur += Time.deltaTime;
                if (extradur < 0.2f)
                {
                    ani.SetBool("hýzlýgeç", true);
                    //ani.SetBool("walk", false);
                }
                else
                {
                    ani.SetBool("hýzlýgeç", false);
                    ani.SetBool("onayvur", true);
                }

            }
            else
            {
                ani.SetBool("onayvur", false);
                //ani.SetBool("walk", false);
            }
        }
        else if (attackrange == false)
        {
            ani.SetBool("onayvur", false);
            ani.SetBool("hýzlýgeç", false);
            extradur = 0;
            //camanim.SetBool("shake1", false);
            karakterkontrol.spi.color = Color.white;
        }

        if (attackduration > 1.3f)
        {
            attackduration = 0;
        }
        if(gameObject != null)
        {
            karakterkontrol.spi.color = Color.white;
        }

        if(atinrange == true)
        {
            timeee += Time.deltaTime;
            if(karakterkontrol.gunswip == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space) && timeee > 0.7f)
                {
                    
                    pullback = true;
                    Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
                    damagetype.SetActive(true);

                    getStabWound.start();
                    whenHit.start();
                    timeee = 0;
                    if(karakterkontrol.Ýnbox == false)
                    {
                        enemyhealth -= 20;
                        textchange.text = "20";
                    }
                    else
                    {
                        enemyhealth -= 100;
                        textchange.text = "100";
                    }
                    karakterkontrol.Ýnbox = false;
                }
                /* else if (karakterkontrol.animduration > 0.7f)
                 {
                     pullback = false;
                 }*/
            }
            
        }
        if(gunshot == true)
        {
            if(karakterkontrol.gunswip == 2 || karakterkontrol.gunswip == 4 || karakterkontrol.gunswip == 3)
            {
                gerisayým += Time.deltaTime;
                if (gerisayým < 0.5f)
                {
                    pullback = true;
                    
                }
                else
                {
                    pullback = false;
                    gunshot = false;
                    gerisayým = 0;
                }
            }
        }
    }
    float timeee;
    float gerisayým;
    public static bool hurtsound;
    bool gunshot = false;
    bool pullback = false;
    bool atinrange = false;
  /*  public void inrayy()
    {
        atinrange = true;
        print("çalýþtý2");
    }
    public void notinrayy()
    {
        atinrange = false;
        pullback = false;
    }*/
     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.tag == "Trigger")
         {
             atinrange = true;
             herhangi = Random.Range(-1, 2);
         }
         if(collision.gameObject.tag == "bomb")
        {
            enemyhealth -= 100;
        }

     }
     private void OnTriggerExit2D(Collider2D collisionnn)
     {
         if (collisionnn.gameObject.tag == "Trigger")
         {
             atinrange = false;
             pullback = false;
         }
     }
    public GameObject bloodeffect;
    public Text textchange;
    public GameObject damagetype;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "magmermi")
        {
            Destroy(other.gameObject);
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
            enemyhealth -= 15;
            damagetype.SetActive(true);
            textchange.text = karakterkontrol.magdamage.ToString();
            gunshot = true;
            herhangi = Random.Range(-1, 2);
            getStabWound.start();
            whenHit.start();
        }
        if (other.gameObject.tag == "shotmermi")
        {
            Destroy(other.gameObject);
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
            enemyhealth -= 25;
            damagetype.SetActive(true);
            textchange.text = karakterkontrol.shotgundamage.ToString();
            gunshot = true;
            herhangi = Random.Range(-1, 2);
            getStabWound.start();
            whenHit.start();
        }
        if (other.gameObject.tag == "riflemermi")
        {
            Destroy(other.gameObject);
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
            enemyhealth -= 10;
            damagetype.SetActive(true);
            textchange.text = karakterkontrol.rifledamage.ToString();
            gunshot = true;
            herhangi = Random.Range(-1, 2);
            getStabWound.start();
            whenHit.start();
        }
    }
   


    /*void SeeVisiblePlayer()
    {
        Vector2 dirtoplayer = (target.position - transform.position).normalized;
        if (Vector2.Angle(transform.forward, dirtoplayer) < viewangle / 2)
        {
            float distancetoplayer = Vector2.Distance(transform.position, target.position);
            if (!Physics2D.Raycast(transform.position, dirtoplayer, distancetoplayer, Wall))
            {
                enemy.SetDestination(target.position);
            }
        }
    }*/
}
