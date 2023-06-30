using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class miniboss : MonoBehaviour
{
    private Transform target;

    private NavMeshAgent enemy;

    private Animator ani;

    private SpriteRenderer spite;
    private Animator camanim;

    public LayerMask playerrr;
    public LayerMask Wall;

    float attackduration;

    public static int enemyhealth = 300;

    public Slider enemyhealthbar;
    Rigidbody2D rigigid;

    public GameObject minibosstalk;
    public Text textchange;

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
    }
    Vector2 lastposition2;
    bool detected = false;
    public static float detectedradius = 10;
    float retreadrange = 2;
    bool retread;
    public GameObject effect;
    [Range(0, 360)] public float viewangle;
    float forgetduration;
    public Transform[] t;
    float hitpushway;
    float zamanlama;
    float zamanlama2;
    public static int Aimway;
    public GameObject teleporteffect;
    bool runOnce = true;

    public static FMOD.Studio.EventInstance whenHit;

    private void Awake()
    {
        whenHit = FMODUnity.RuntimeManager.CreateInstance("event:/whenhit");
    }
    public Transform[] points;
    void Update()
    {
        enemyhealthbar.value = enemyhealth;
        zamanlama += Time.deltaTime;
        attackduration += Time.deltaTime;
        retread = Physics2D.OverlapCircle(transform.position, retreadrange, playerrr);
        detected = Physics2D.OverlapCircle(transform.position, detectedradius, playerrr);
        //print(herhangi);
        if (enemyhealth <= 0 && runOnce)
        {
            //spite.enabled = false;
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
            Instantiate<GameObject>(effect, transform.position, Quaternion.identity);
            int coinbetween = Random.Range(10, 25);
            sellersystem.Coin += coinbetween;
            minibosstalk.SetActive(true);
            Destroy(gameObject);
            runOnce = false;
        }
        Vector2 dirtoplayer = (target.position - transform.position).normalized;
        if (Vector2.Angle(transform.forward, dirtoplayer) < viewangle / 2)
        {
            float distancetoplayer = Vector2.Distance(transform.position, target.position);
            if (detected == true)
            {
                if (!Physics2D.Raycast(transform.position, dirtoplayer, distancetoplayer, Wall) && karakterkontrol.�nbox == false)
                {


                    float x = target.position.x - transform.position.x;
                    float y = target.position.y - transform.position.y;
                    if (ipegitme == false)
                    {
                        if (retread == true)
                        {
                            if (hitpushway == 1)
                            {
                                enemy.SetDestination(t[0].position);
                                enemy.speed = 3f;
                            }
                            else if (hitpushway == 2)
                            {
                                enemy.SetDestination(t[1].position);
                                enemy.speed = 3f;
                            }
                            else if (hitpushway == 3)
                            {
                                enemy.SetDestination(t[2].position);
                                enemy.speed = 3f;
                            }
                            else if (hitpushway == 4)
                            {
                                enemy.SetDestination(t[3].position);
                                enemy.speed = 3f;
                            }
                        }
                        else
                        {
                            enemy.stoppingDistance = 4f;
                            try
                            {
                                enemy.SetDestination(target.position);
                            }
                            catch { }
                            spite.color = Color.white;
                            enemy.speed = 1.5f;
                        }
                    }
                    else
                    {
                        enemy.SetDestination(end.position);
                        enemy.speed = 10;
                    }


                    if ((target.position.x < transform.position.x) && y > x)//sol
                    {
                        ani.SetBool("walk", false);
                        ani.SetFloat("yurume", 1);
                        spite.flipX = false;
                        hitpushway = 4;
                        if (ipegitme == false)
                        {
                            if (retread == false)
                            {
                                enemy.speed = 1.5f;
                            }
                        }
                        Aimway = 1;
                    }
                    else if ((target.position.x > transform.position.x) && y < x)//sa�
                    {
                        ani.SetBool("walk", false);
                        ani.SetFloat("yurume", 1);
                        spite.flipX = true;
                        hitpushway = 3;
                        if (ipegitme == false)
                        {
                            if (retread == false)
                            {
                                enemy.speed = 1.5f;
                            }

                        }
                        Aimway = 2;
                    }
                    else if ((target.position.y < transform.position.y) && x > y)//�n�
                    {
                        ani.SetBool("walk", false);
                        ani.SetFloat("yurume", -1);
                        spite.flipX = false;
                        hitpushway = 1;
                        if (ipegitme == false)
                        {
                            if (retread == false)
                            {
                                enemy.speed = 3f;
                            }
                        }
                        Aimway = 3;
                    }
                    else if ((target.position.y > transform.position.y) && x < y)//arkas�
                    {
                        ani.SetBool("walk", false);
                        ani.SetFloat("yurume", 0);
                        spite.flipX = false;
                        hitpushway = 2;
                        if (ipegitme == false)
                        {
                            if (retread == false)
                            {
                                enemy.speed = 1.5f;
                            }
                        }
                        Aimway = 4;
                    }
                }
                else if (Physics2D.Raycast(transform.position, dirtoplayer, distancetoplayer, Wall))
                {
                    float x = target.position.x - transform.position.x;
                    float y = target.position.y - transform.position.y;
                    if (ipegitme == false)
                    {
                        enemy.stoppingDistance = 1f;

                        try
                        {
                            enemy.SetDestination(target.position);
                        }
                        catch { }
                        spite.color = Color.white;
                        enemy.speed = 1.5f;
                    }
                    else
                    {
                        enemy.SetDestination(end.position);
                        enemy.speed = 10;
                    }


                    if ((target.position.x < transform.position.x) && y > x)//sol
                    {
                        ani.SetBool("walk", false);
                        ani.SetFloat("yurume", 1);
                        spite.flipX = false;
                        hitpushway = 4;
                        if (ipegitme == false)
                        {
                            if (retread == false)
                            {
                                enemy.speed = 1.5f;
                            }
                        }

                        Aimway = 1;
                    }
                    else if ((target.position.x > transform.position.x) && y < x)//sa�
                    {
                        ani.SetBool("walk", false);
                        ani.SetFloat("yurume", 1);
                        spite.flipX = true;
                        hitpushway = 3;
                        if (ipegitme == false)
                        {
                            if (retread == false)
                            {
                                enemy.speed = 1.5f;
                            }
                        }

                        Aimway = 2;
                    }
                    else if ((target.position.y < transform.position.y) && x > y)//�n�
                    {
                        ani.SetBool("walk", false);
                        ani.SetFloat("yurume", -1);
                        spite.flipX = false;
                        hitpushway = 1;
                        if (ipegitme == false)
                        {
                            if (retread == false)
                            {
                                enemy.speed = 3f;
                            }
                        }

                        Aimway = 3;
                    }
                    else if ((target.position.y > transform.position.y) && x < y)//arkas�
                    {
                        ani.SetBool("walk", false);
                        ani.SetFloat("yurume", 0);
                        spite.flipX = false;
                        hitpushway = 2;
                        if (ipegitme == false)
                        {
                            if (retread == false)
                            {
                                enemy.speed = 1.5f;
                            }
                        }

                        Aimway = 4;
                    }
                }

            }

        }

        zamanlama2 += Time.deltaTime;
        if (zamanlama2 > 8)
        {

            ���nlanmazaman� += Time.deltaTime;

            if (biryer == 1)
            {
                end.position = new Vector3(11, -9, 0);

                if (���nlanmazaman� > 1f)
                {
                    ipegitme = true;
                }
                if (���nlanmazaman� > 3f)
                {
                    ipegitme = false;
                    biryer = Random.Range(1, 5);
                    ���nlanmazaman� = 0;
                    zamanlama2 = 0;
                }

            }
            else if (biryer == 2)
            {
                end.position = new Vector3(23, -9, 0);

                if (���nlanmazaman� > 1f)
                {
                    ipegitme = true;
                }
                if (���nlanmazaman� > 3f)
                {
                    ipegitme = false;
                    biryer = Random.Range(1, 5);
                    ���nlanmazaman� = 0;
                    zamanlama2 = 0;
                }

            }
            else if (biryer == 3)
            {
                end.position = new Vector3(23, -17, 0);

                if (���nlanmazaman� > 1f)
                {
                    ipegitme = true;
                }
                if (���nlanmazaman� > 3f)
                {
                    ipegitme = false;
                    biryer = Random.Range(1, 5);
                    ���nlanmazaman� = 0;
                    zamanlama2 = 0;
                }

            }
            else if (biryer == 4)
            {
                end.position = new Vector3(11, -17, 0);

                if (���nlanmazaman� > 1f)
                {
                    ipegitme = true;
                }
                if (���nlanmazaman� > 3f)
                {
                    ipegitme = false;
                    biryer = Random.Range(1, 5);
                    ���nlanmazaman� = 0;
                    zamanlama2 = 0;
                }
            }

        }

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
                    //pullback = true;
                    Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
                    //damagetype.SetActive(true);

                    //sounds[0].Play();
                    whenHit.start();

                    timeee = 0;
                    if (karakterkontrol.�nbox == false)
                    {
                        enemyhealth -= 20;
                        //textchange.text = "20";
                    }
                    else
                    {
                        enemyhealth -= 100;
                        // textchange.text = "100";
                    }
                    karakterkontrol.�nbox = false;
                }
                /*else if (timeee > 1.5f)
                {
                    pullback = false;
                }*/
            }

        }
        /*  if (gunshot == true)
          {
              if (karakterkontrol.gunswip == 2 || karakterkontrol.gunswip == 4 || karakterkontrol.gunswip == 3)
              {
                  damagetype.SetActive(true);
              }
              if (karakterkontrol.gunswip == 2)
              {
                  textchange.text = karakterkontrol.magdamage.ToString();

              }
              else if (karakterkontrol.gunswip == 3)
              {
                  textchange.text = karakterkontrol.rifledamage.ToString();
              }
              else if (karakterkontrol.gunswip == 4)
              {
                  // int sda = karakterkontrol.shotgundamage * 2;
                  textchange.text = karakterkontrol.shotgundamage.ToString();
              }

          }*/
    }
    public Transform end;
    bool ipegitme;
    float ���nlanmazaman� = 0;
    int biryer = 2;
    float timeee;
    float gerisay�m;
    public static bool hurtsound;
    bool pullback = false;
    bool atinrange = false;
    /* public void inray()
     {
         atinrange = true;
         print("�al��t�1");
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

            whenHit.start();
            //sounds[0].Play();
        }
        if (other.gameObject.tag == "shotmermi")
        {
            Destroy(other.gameObject);
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
            enemyhealth -= karakterkontrol.shotgundamage;
            gunshot = true;

            whenHit.start();
            //sounds[0].Play();
        }
        if (other.gameObject.tag == "riflemermi")
        {
            Destroy(other.gameObject);
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
            enemyhealth -= karakterkontrol.rifledamage;
            gunshot = true;

            whenHit.start();
            //sounds[0].Play();
        }
    }
    /* public Transform[] path;
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
     float p = 0;
     bool config = false;
     public Transform tracker;
     public Transform gitmeyerleri;
     int so�umas�resi = 1;
     bool takibib�rak;
     //public GameObject go;
     //public bool otherdirection = true;
     IEnumerator pathtogoo()
     {
         config = true;
         takibib�rak = true;
         while (p <= 1)
         {
             p += speed * Time.deltaTime;
             Vector3 posat = Mathf.Pow((1 - p), 3) * path[0].position
                 + 3 * Mathf.Pow((1 - p), 2) * p * path[1].position
                 + 3 * (1 - p) * p * path[2].position + Mathf.Pow(p, 3) * path[3].position;

             yield return new WaitForEndOfFrame();
         }
         //p = 0;
         so�umas�resi = Random.Range(8, 13);
         config = false;
         takibib�rak = false;
     }*/
}
//berk hocaya sor
// Quaternion lookrotatoion = Quaternion.FromToRotation(transform.forward,posat - transform.position);
//transform.rotation = lookrotatoion;
/*if (otherdirection == true)
{
    go.transform.rotation = Quaternion.FromToRotation(Vector2.right, posat - go.transform.position);
    go.transform.position = posat;
}
else
{
    go.transform.rotation = Quaternion.FromToRotation(-Vector2.right, posat - go.transform.position);
    go.transform.position = posat;
}*/
//transform.LookAt(posat - transform.position, Vector3.right * -1);
//transform.position = posat;
