using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class karakterkontrol : MonoBehaviour
{
    Rigidbody2D rigi;

    Animator anim;
    //EnemyAI en1;
    //EnemyAII en2;

    public static SpriteRenderer spi;

    public static FMOD.Studio.EventInstance metalwalk;
    public static FMOD.Studio.EventInstance knifeWhoosh;
    public static FMOD.Studio.EventInstance gunDraw1;
    public static FMOD.Studio.EventInstance gunDraw2;
    public static FMOD.Studio.EventInstance gunDraw3;
    public static FMOD.Studio.EventInstance knifePullOut;
    public static FMOD.Studio.EventInstance whenHit;

    //public GameObject downbody;

    static public float animduration = 0;

    static public float bitiriþ = 0;

    bool animonay;

    public static int health = 100;

    float speed = 3;
    float h;
    float v;
    public static int yönkararý;
    private CanvasGroup screenbloody;

    public Image[] slotseçim;
    public Slider[] cooldown;
    float cooldowntime = 1f;
    float cooldowntime1 = 1f;
    float cooldowntime2 = 1f;
    bool timecool = false;
    private Animator camanim;
    public UnityEvent kniferay;
    public static int magdamage = 15;
    public static int rifledamage = 10;
    public static int shotgundamage = 25;
    private void Awake()
    {
        Cursor.visible = false;

        metalwalk = FMODUnity.RuntimeManager.CreateInstance("event:/OnMetalSurface/Walking");
        knifeWhoosh = FMODUnity.RuntimeManager.CreateInstance("event:/KnifeWhoosh");
        gunDraw1 = FMODUnity.RuntimeManager.CreateInstance("event:/DrawingWeapon/gunDraw1");
        gunDraw2 = FMODUnity.RuntimeManager.CreateInstance("event:/DrawingWeapon/gunDraw2");
        gunDraw3 = FMODUnity.RuntimeManager.CreateInstance("event:/DrawingWeapon/gunDraw3");
        knifePullOut = FMODUnity.RuntimeManager.CreateInstance("event:/DrawingWeapon/knifePullOut");
        whenHit = FMODUnity.RuntimeManager.CreateInstance("event:/whenhit");
    }
    public void save()
    {
        savesystem.saveplayer(this);
    }
    public void load()
    {
        Data datas = savesystem.loadplayer();
        health = datas.health;
        magdamage = datas.magdamage;
        rifledamage = datas.rifledamage;
        shotgundamage = datas.shotdamage;
    } 
    void Start()
    {
       // en1 = FindObjectOfType<EnemyAI>();
       // en2 = FindObjectOfType<EnemyAII>();
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spi = GetComponent<SpriteRenderer>();
        health = (int)slider.maxValue;
        camanim = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        screenbloody = GameObject.FindWithTag("screenblood").GetComponent<CanvasGroup>();
        gunswip = 1;
        slotseçim[0].color = Color.green;
        cooldowntime = (float)cooldown[0].maxValue;
        cooldowntime1 = (float)cooldown[1].maxValue;
        cooldowntime2 = (float)cooldown[2].maxValue;
        if (kniferay == null)
        {
            kniferay = new UnityEvent();
        }
        //
        /*if(SceneManager.GetActiveScene().name == "FinalBoss" || SceneManager.GetActiveScene().name == "TankBoss" || SceneManager.GetActiveScene().name == "Helicapter Boss" || SceneManager.GetActiveScene().name == "Level_2" || SceneManager.GetActiveScene().name == "Level_3")
        {
            load();
        }*/
    }
    public Slider slider;
    public static int gunswip;
    public LayerMask Enemy;
    static public bool Ýnbox;
    public static float timee;
    public GameObject bloureffect;
    public static float actiontime = 11;
    public bool notheresave;
    void Update()
    {
        actiontime += Time.deltaTime;
        slider.value = health;
        cooldown[0].value = cooldowntime;
        cooldown[1].value = cooldowntime1;
        cooldown[2].value = cooldowntime2;
        if (health > 70)
        {
            screenbloody.alpha = 0f;
        }
        else if(health < 70 && health > 50)
        {
            screenbloody.alpha = 0.1f;
        }
        else if(health < 50 && health > 25)
        {
            screenbloody.alpha = 0.35f;
        }
        else if(health < 25)
        {
            screenbloody.alpha = 0.6f;
        }
        if (health <= 0)
        {
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
        /*if(level1gamecontroller.saveagree == true)
        {
            
        }*/
        if (!notheresave)
        {
            save();
        }
        if (DialogueManager.loadagree == true)
        {
            load();
            DialogueManager.loadagree = false;
        }
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        bitiriþ += Time.deltaTime;
        //yemek
          cooldowntime -= Time.deltaTime;
          if(cooldowntime < 0)
          {
            if (Input.GetKeyDown(KeyCode.G))
            {
                health += 30;
                cooldowntime = 20;
                
            }
            
          }
          //bomba
        cooldowntime1 -= Time.deltaTime;
        if (cooldowntime1 < 0)
        {
            if (Input.GetKeyDown(KeyCode.B) && sellersystem.granadee > 0)
            {
                cooldowntime1 = 10;
                sellersystem.granadee--;
                bulletfire.bombthrowed = true;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            bulletfire.bombthrowed = false;
        }
        //kutuiçin
        if (timee > 15)
        {
            Ýnbox = false;
        }
        if(Ýnbox == true)
        {
            timee += Time.deltaTime;
            bloureffect.SetActive(true);
            spi.enabled = false;
            box.SetActive(true);
        }
        if(Ýnbox == false)
        {
            cooldowntime2 -= Time.deltaTime;
            bloureffect.SetActive(false);
            spi.enabled = true;
            box.SetActive(false);
            timee = 0;
        }
        if (cooldowntime2 < 0)
        {
            if (Input.GetKeyDown(KeyCode.H) && sellersystem.boxx > 0)
            {
                cooldowntime2 = 10;
                sellersystem.boxx--;
                Ýnbox = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetInteger("geçiþ", 1);
            gunswip = 1;
            slotseçim[0].color = Color.green;
            slotseçim[1].color = Color.gray;
            slotseçim[2].color = Color.gray;
            slotseçim[3].color = Color.gray;
            
            knifePullOut.start();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetInteger("geçiþ", 2);
            gunswip = 2;
            slotseçim[0].color = Color.gray;
            slotseçim[1].color = Color.green;
            slotseçim[2].color = Color.gray;
            slotseçim[3].color = Color.gray;

            gunDraw1.start();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetInteger("geçiþ", 3);
            gunswip = 3;
            slotseçim[0].color = Color.gray;
            slotseçim[1].color = Color.gray;
            slotseçim[2].color = Color.green;
            slotseçim[3].color = Color.gray;

            gunDraw2.start();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {    
            anim.SetInteger("geçiþ", 4);
            gunswip = 4;
            slotseçim[0].color = Color.gray;
            slotseçim[1].color = Color.gray;
            slotseçim[2].color = Color.gray;
            slotseçim[3].color = Color.green;

            gunDraw3.start();
        }
        yürüme();
        
        if(gunswip == 1)
        {
            if (yönkararý == 0)
            {
                aþaðýsaldýrý();
                aþaðývuruþ.SetActive(true);
                saðvuruþ.SetActive(false);
                solvuruþ.SetActive(false);
                yukarývuruþ.SetActive(false);
                /*if (Physics2D.Raycast(transform.position, -Vector2.up, 1.2f, Enemy))
                {
                    en1.inray();
                    en2.inrayy();
                }
                else
                {
                    en1.notinray();
                    en2.notinrayy();
                }*/

            }
            else if (yönkararý == 1)
            {
                saðsaldýrý();
                aþaðývuruþ.SetActive(false);
                saðvuruþ.SetActive(true);
                solvuruþ.SetActive(false);
                yukarývuruþ.SetActive(false);
               /* if (Physics2D.Raycast(transform.position, Vector2.right, 0.85f, Enemy))
                {
                    en1.inray();
                    en2.inrayy();
                   // Debug.DrawLine(transform.position,transform.forward, Color.red, 0.85f);
                }
                else
                {
                    en1.notinray();
                    en2.notinrayy();
                }*/
            }
            else if (yönkararý == 2)
            {
                solsaldýrý();
                aþaðývuruþ.SetActive(false);
                saðvuruþ.SetActive(false);
                solvuruþ.SetActive(true);
                yukarývuruþ.SetActive(false);
               /* if (Physics2D.Raycast(transform.position, -Vector2.right, 0.85f, Enemy))
                {
                    en1.inray();
                    en2.inrayy();
                }
                else
                {
                    en1.notinray();
                    en2.notinrayy();
                }*/
            }
            else if (yönkararý == 3)
            {
                yukarýsaldýrý();
                aþaðývuruþ.SetActive(false);
                saðvuruþ.SetActive(false);
                solvuruþ.SetActive(false);
                yukarývuruþ.SetActive(true);
                /*if (Physics2D.Raycast(transform.position, Vector2.up, 1.2f, Enemy))
                {
                    en1.inray();
                    en2.inrayy();
                   // kniferay.Invoke();
                }
                else
                {
                    en1.notinray();
                    en2.notinrayy();
                }*/
            }
        }

        býcaklama += Time.deltaTime;
        if(býcaklama > 0.4f)
        {
           // camanim.SetBool("shake1", false);
            býcaklama = 0;
        }

        seszamanlama += Time.deltaTime;
        
    }
    public GameObject saðvuruþ;
    public GameObject solvuruþ;
    public GameObject yukarývuruþ;
    public GameObject aþaðývuruþ;
    private void FixedUpdate()
    {
        rigi.MovePosition(rigi.position + new Vector2(h, v) * speed * Time.fixedDeltaTime);
    }
    float seszamanlama = 0.6f;
    void yürümesesi()
    {
        
        if(seszamanlama > 0.5f)
        {
            metalwalk.start();
            seszamanlama = 0;
        }
    }
    float býcaklama = 0;
    void býcaklý()
    {
        knifeWhoosh.start();
    }
    bool vuruþzamaný = false;
    void saðsaldýrý()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bitiriþ > 0.2f)
        {
            animduration = 0;
            anim.SetBool("saldýrý", true);
            anim.SetFloat("vuruþlar", 0);
            býcaklý();
            animonay = true;
            vuruþzamaný = true;
            timee = 14;
        }
        else
        {
            anim.SetBool("saldýrý", false);

        }
        if (animonay == true)
        {
            animduration += Time.deltaTime;
            if (animduration < 0.8f)
            {
                bitiriþ = 0;

            }
            else
            {
                animonay = false;
            }
        }


    }

    void solsaldýrý()
    {

        if (Input.GetKeyDown(KeyCode.Space) && bitiriþ > 0.2f)
        {
            animduration = 0;
            anim.SetBool("saldýrý", true);
            anim.SetFloat("vuruþlar", 0);
            býcaklý();
            animonay = true;
            vuruþzamaný = true;
            timee = 14;

        }
        else
        {
           
            anim.SetBool("saldýrý", false);
            
        }
        if (animonay == true)
        {
            animduration += Time.deltaTime;
            if (animduration < 0.8f)
            {
                bitiriþ = 0;

            }
            else
            {
                animonay = false;
            }
        }
    }
    void yukarýsaldýrý()
    {

        if (Input.GetKeyDown(KeyCode.Space) && bitiriþ > 0.2f)
        {
            animduration = 0;
            anim.SetBool("saldýrý", true);
            anim.SetFloat("vuruþlar", 1);
            býcaklý();
            animonay = true;
            vuruþzamaný = true;
            timee = 14;
        }
        else
        {
            anim.SetBool("saldýrý", false);

        }
        if (animonay == true)
        {
            animduration += Time.deltaTime;
            if (animduration < 0.8f)
            {
                bitiriþ = 0;

            }
            else
            {
                animonay = false;
            }
        }
    }
    void aþaðýsaldýrý()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bitiriþ > 0.2f)
        {
            animduration = 0;
            anim.SetBool("saldýrý", true);
            anim.SetFloat("vuruþlar", -1);
            býcaklý();
            animonay = true;
            vuruþzamaný = true;
            timee = 14;
        }
        else
        {
            anim.SetBool("saldýrý", false);
        }
        if (animonay == true)
        {
            animduration += Time.deltaTime;
            if (animduration < 0.8f)
            {
                bitiriþ = 0;

            }
            else
            {
                animonay = false;
            }
        }

    }
    public GameObject box;
    public Animator bbox;
    void yürüme()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("haraket", true);
            anim.SetFloat("Blend", 0);
            bbox.SetFloat("Blend", 2);
            speed = 5;
            yönkararý = 0;
            yürümesesi();
            //aþaðýsaldýrý();
            spi.flipX = false;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("haraket", true);
            anim.SetFloat("Blend", 1);
            bbox.SetFloat("Blend", 1);
            speed = 5;
            yönkararý = 1;
            yürümesesi();
            //saðsaldýrý();
            yönkararý = 1;
            spi.flipX = true;

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("haraket", true);
            anim.SetFloat("Blend", 1);
            bbox.SetFloat("Blend", 1);
            speed = 5;
            yönkararý = 2;
            yürümesesi();
            //solsaldýrý();
            spi.flipX = false;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("haraket", true);
            anim.SetFloat("Blend", -1);
            bbox.SetFloat("Blend", 2);
            speed = 5;
            yönkararý = 3;
            yürümesesi();
            //yukarýsaldýrý();
            spi.flipX = false;

        }
        else
        {
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                anim.SetBool("haraket", false);
                bbox.SetFloat("Blend", 3);
                speed = 0;
                yönkararý = 0;
                metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                anim.SetBool("haraket", true);
                anim.SetFloat("Blend", 2);
                bbox.SetFloat("Blend", 0);
                speed = 0;
                metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

                yönkararý = 1;
                spi.flipX = true;

            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                anim.SetBool("haraket", true);
                anim.SetFloat("Blend", 2);
                bbox.SetFloat("Blend", 0);
                speed = 0;
                metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

                yönkararý = 2;
                spi.flipX = false;
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                anim.SetBool("haraket", true);
                anim.SetFloat("Blend", 1.5f);
                bbox.SetFloat("Blend", 3);
                speed = 0;
                metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);


                yönkararý = 3;
                spi.flipX = false;

            }
        }
    }



    //static public bool pullback = false;
    /* private void OnTriggerStay2D(Collider2D other)
     {
         if (other.gameObject.tag == "Enemy")
         {
             if (Input.GetKeyDown(KeyCode.Space))
             {
                 EnemyAI.enemyhealth -= 15;
                 pullback = true;
                 print("düþmana vuruldu");
             }
             print("düþmana menzilinde");
         }
     }*/
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "lazertouch")
        {
            health -= 20;
        }
    }*/

    public GameObject bloodeffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enriflemermi")
        {
            health -= 5;
            //camanim.SetBool("shake1", true);
            Destroy(collision.gameObject);
            Instantiate<GameObject>(bloodeffect, transform.position, Quaternion.identity);

            whenHit.start();
        }
    }
    /*
            if (hammer.activeInHierarchy == true)
        {
            bitiriþ = 0;
        }
     
             if (animonay == true)
        {
            animduration += Time.deltaTime;
            if (animduration < 0.8f)
            {
                hammer.SetActive(true);
                hamanim.SetBool("savurum", true);
                hamanim.SetFloat("cekýc", 0);
                hamrspi.flipX = true;
            }
            else
            {
                
                //animduration = 0;
                animonay = false;
            }
        }
        else if (animonay == false)
        {
            hammer.SetActive(false);
            
            //hamanim.SetBool("savurum", false);
            animduration = 0;

        }
     */

}
