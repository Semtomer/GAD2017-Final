using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
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

    public LayerMask playerrr;
    public LayerMask Wall;

    float attackduration;
    float extradur;
    bool timetohit;

    int enemyhealth = 100;

    public Slider enemyhealthbar;
    Rigidbody2D rigigid;

    public GameObject detectedsign;

    public Text textchange;
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
    public static float detectedradius = 13;
    public GameObject effect;
    bool athisposition;

    int herhangi;
    [Range(0, 360)] public float viewangle;
    float forgetduration;
    public Transform[] t;
    float hitpushway;
    float zamanlama;
    float zamanlama2;
    public static int Aimway;
    void Update()
    {
        /*if (karakterkontrol.actiontime < 5)
        {
            //backgroundMusic.SetActive(false);
            //actionmusic.volume = 0.4f;

            backgroundMusic.setVolume(0f);
            whenFight.setVolume(1f);
        }
        else
        {
            backgroundMusic.setVolume(1f);
            whenFight.setVolume(0f);

            //actionmusic.volume = 0.0f;
            //backgroundMusic.SetActive(true);
        }*/
            enemyhealthbar.value = enemyhealth;
        
        attackduration += Time.deltaTime;
        lastposition2.x = lastposition.position.x;
        lastposition2.y = lastposition.position.y;
        detected = Physics2D.OverlapCircle(transform.position, detectedradius, playerrr);
        if (enemyhealth <= 0)
        {
            //spite.enabled = false;
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
            Instantiate<GameObject>(effect, transform.position, Quaternion.identity);
            int coinbetween = Random.Range(5, 16);
            sellersystem.Coin += coinbetween;
            Destroy(gameObject); 
        }
        if (transform.position.x >= lastposition2.x - 0.5f && transform.position.x <= lastposition2.x + 0.5f && transform.position.y >= lastposition2.y - 0.5f && transform.position.y <= lastposition2.y + 0.5f)
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
                        enemy.stoppingDistance = 4f;
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

                        if ((target.position.x < transform.position.x) && y > x)//sol
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 1);
                            spite.flipX = false;
                            hitpushway = 4;
                            enemy.speed = 1.5f;
                            Aimway = 1;
                        }
                        else if ((target.position.x > transform.position.x) && y < x)//sað
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 1);
                            spite.flipX = true;
                            hitpushway = 3;
                            enemy.speed = 1.5f;
                            Aimway = 2;
                        }
                        else if ((target.position.y < transform.position.y) && x > y)//önü
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", -1);
                            spite.flipX = false;
                            hitpushway = 1;
                            enemy.speed = 3;
                            Aimway = 3;
                        }
                        else if ((target.position.y > transform.position.y) && x < y)//arkasý
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 0);
                            spite.flipX = false;
                            hitpushway = 2;
                            enemy.speed = 1.5f;
                            Aimway = 4;
                        }
                    }
                }
                else if (bulletfire.firedsound == true)
                {
                    
                    zamanlama2 += Time.deltaTime;
                    if (zamanlama2 < 5)
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
                        enemy.stoppingDistance = 4f;
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
                            Aimway = 1;
                        }
                        else if ((target.position.x > transform.position.x) && y < x)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 1);
                            spite.flipX = true;
                            hitpushway = 3;
                            enemy.speed = 1.5f;
                            Aimway = 2;
                        }
                        else if ((target.position.y < transform.position.y) && x > y)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", -1);
                            spite.flipX = false;
                            hitpushway = 1;
                            enemy.speed = 3;
                            Aimway = 3;
                        }
                        else if ((target.position.y > transform.position.y) && x < y)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 0);
                            spite.flipX = false;
                            hitpushway = 2;
                            enemy.speed = 1.5f;
                            Aimway = 4;
                        }
                    }
                    else if (zamanlama2 > 5)
                    {
                        detectedradius = 13;
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
                            Aimway = 1;
                        }
                        else if ((lastposition.position.x > transform.position.x) && y < x)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 1);
                            spite.flipX = true;
                            Aimway = 2;
                        }
                        else if ((lastposition.position.y < transform.position.y) && x > y)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", -1);
                            spite.flipX = false;
                            Aimway = 3;
                        }
                        else if ((lastposition.position.y > transform.position.y) && x < y)
                        {
                            ani.SetBool("walk", false);
                            ani.SetFloat("yurume", 0);
                            spite.flipX = false;
                            Aimway = 4;
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


        /*
        if (attackrange == true && pullback == false)
        {
            //enemy.SetDestination(target.position);
            
            if (attackduration > 0.2f && attackduration <= 0.8f)
            {
                float x = target.position.x - transform.position.x;
                float y = target.position.y - transform.position.y;
                hurtsound = true;
                if ((target.position.x < transform.position.x) && y > x)//sol
                {
                    ani.SetFloat("vuruþ", 0);
                    spite.flipX = false;
                }
                else if ((target.position.x > transform.position.x) && y < x)//sað
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
            camanim.SetBool("shake1", false);
            karakterkontrol.spi.color = Color.white;
        }*/

        if (attackduration > 1.3f)
        {
            attackduration = 0;
        }
        if (gameObject != null)
        {
            karakterkontrol.spi.color = Color.white;
        }
        if (atinrange == true)
        {
            timeee += Time.deltaTime;
            if (karakterkontrol.gunswip == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space) && timeee > 0.7f)
                {
                    pullback = true;
                    Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
                    damagetype.SetActive(true);

                    getStabWound.start();
                    whenHit.start();
                    timeee = 0;
                    if (karakterkontrol.Ýnbox == false)
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
                /*else if (timeee > 1.5f)
                {
                    pullback = false;
                }*/
            }

        }
        if (gunshot == true)
        {
            if (karakterkontrol.gunswip == 2 || karakterkontrol.gunswip == 4 || karakterkontrol.gunswip == 3)
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
                damagetype.SetActive(true);
            }
            if(karakterkontrol.gunswip == 2)
            {
                textchange.text = karakterkontrol.magdamage.ToString();
                
            }
            else if(karakterkontrol.gunswip == 3)
            {
                textchange.text = karakterkontrol.rifledamage.ToString();
            }
            else if (karakterkontrol.gunswip == 4)
            {
               // int sda = karakterkontrol.shotgundamage * 2;
                textchange.text = karakterkontrol.shotgundamage.ToString();
            }

        }
    }
    float timeee;
    float gerisayým;
    public static bool hurtsound;
    bool pullback = false;
    bool atinrange = false;
   /* public void inray()
    {
        atinrange = true;
        print("çalýþtý1");
    }
    public void notinray()
    {
        atinrange = false;
        pullback = false;
    }*/
    bool gunshot = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            atinrange = true;
            herhangi = Random.Range(-1, 2);
        }
        if (collision.gameObject.tag == "bomb")
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
    public GameObject damagetype;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "magmermi")
        {
            Destroy(other.gameObject);
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
            enemyhealth -= karakterkontrol.magdamage;
            gunshot = true;
            herhangi = Random.Range(-1, 2);
            getStabWound.start();
            whenHit.start();
        }
        if (other.gameObject.tag == "shotmermi")
        {
            Destroy(other.gameObject);
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
            enemyhealth -= karakterkontrol.shotgundamage;
            gunshot = true;
            herhangi = Random.Range(-1, 2);
            getStabWound.start();
            whenHit.start();
        }
        if (other.gameObject.tag == "riflemermi")
        {
            Destroy(other.gameObject);
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
            enemyhealth -= karakterkontrol.rifledamage;
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
