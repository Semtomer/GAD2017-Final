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

    static public float bitiri� = 0;

    bool animonay;

    public static int health = 100;

    float speed = 3;
    float h;
    float v;
    public static int y�nkarar�;
    private CanvasGroup screenbloody;

    public Image[] slotse�im;
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
        slotse�im[0].color = Color.green;
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
    static public bool �nbox;
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
        bitiri� += Time.deltaTime;
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
        //kutui�in
        if (timee > 15)
        {
            �nbox = false;
        }
        if(�nbox == true)
        {
            timee += Time.deltaTime;
            bloureffect.SetActive(true);
            spi.enabled = false;
            box.SetActive(true);
        }
        if(�nbox == false)
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
                �nbox = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetInteger("ge�i�", 1);
            gunswip = 1;
            slotse�im[0].color = Color.green;
            slotse�im[1].color = Color.gray;
            slotse�im[2].color = Color.gray;
            slotse�im[3].color = Color.gray;
            
            knifePullOut.start();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetInteger("ge�i�", 2);
            gunswip = 2;
            slotse�im[0].color = Color.gray;
            slotse�im[1].color = Color.green;
            slotse�im[2].color = Color.gray;
            slotse�im[3].color = Color.gray;

            gunDraw1.start();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetInteger("ge�i�", 3);
            gunswip = 3;
            slotse�im[0].color = Color.gray;
            slotse�im[1].color = Color.gray;
            slotse�im[2].color = Color.green;
            slotse�im[3].color = Color.gray;

            gunDraw2.start();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {    
            anim.SetInteger("ge�i�", 4);
            gunswip = 4;
            slotse�im[0].color = Color.gray;
            slotse�im[1].color = Color.gray;
            slotse�im[2].color = Color.gray;
            slotse�im[3].color = Color.green;

            gunDraw3.start();
        }
        y�r�me();
        
        if(gunswip == 1)
        {
            if (y�nkarar� == 0)
            {
                a�a��sald�r�();
                a�a��vuru�.SetActive(true);
                sa�vuru�.SetActive(false);
                solvuru�.SetActive(false);
                yukar�vuru�.SetActive(false);
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
            else if (y�nkarar� == 1)
            {
                sa�sald�r�();
                a�a��vuru�.SetActive(false);
                sa�vuru�.SetActive(true);
                solvuru�.SetActive(false);
                yukar�vuru�.SetActive(false);
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
            else if (y�nkarar� == 2)
            {
                solsald�r�();
                a�a��vuru�.SetActive(false);
                sa�vuru�.SetActive(false);
                solvuru�.SetActive(true);
                yukar�vuru�.SetActive(false);
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
            else if (y�nkarar� == 3)
            {
                yukar�sald�r�();
                a�a��vuru�.SetActive(false);
                sa�vuru�.SetActive(false);
                solvuru�.SetActive(false);
                yukar�vuru�.SetActive(true);
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

        b�caklama += Time.deltaTime;
        if(b�caklama > 0.4f)
        {
           // camanim.SetBool("shake1", false);
            b�caklama = 0;
        }

        seszamanlama += Time.deltaTime;
        
    }
    public GameObject sa�vuru�;
    public GameObject solvuru�;
    public GameObject yukar�vuru�;
    public GameObject a�a��vuru�;
    private void FixedUpdate()
    {
        rigi.MovePosition(rigi.position + new Vector2(h, v) * speed * Time.fixedDeltaTime);
    }
    float seszamanlama = 0.6f;
    void y�r�mesesi()
    {
        
        if(seszamanlama > 0.5f)
        {
            metalwalk.start();
            seszamanlama = 0;
        }
    }
    float b�caklama = 0;
    void b�cakl�()
    {
        knifeWhoosh.start();
    }
    bool vuru�zaman� = false;
    void sa�sald�r�()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bitiri� > 0.2f)
        {
            animduration = 0;
            anim.SetBool("sald�r�", true);
            anim.SetFloat("vuru�lar", 0);
            b�cakl�();
            animonay = true;
            vuru�zaman� = true;
            timee = 14;
        }
        else
        {
            anim.SetBool("sald�r�", false);

        }
        if (animonay == true)
        {
            animduration += Time.deltaTime;
            if (animduration < 0.8f)
            {
                bitiri� = 0;

            }
            else
            {
                animonay = false;
            }
        }


    }

    void solsald�r�()
    {

        if (Input.GetKeyDown(KeyCode.Space) && bitiri� > 0.2f)
        {
            animduration = 0;
            anim.SetBool("sald�r�", true);
            anim.SetFloat("vuru�lar", 0);
            b�cakl�();
            animonay = true;
            vuru�zaman� = true;
            timee = 14;

        }
        else
        {
           
            anim.SetBool("sald�r�", false);
            
        }
        if (animonay == true)
        {
            animduration += Time.deltaTime;
            if (animduration < 0.8f)
            {
                bitiri� = 0;

            }
            else
            {
                animonay = false;
            }
        }
    }
    void yukar�sald�r�()
    {

        if (Input.GetKeyDown(KeyCode.Space) && bitiri� > 0.2f)
        {
            animduration = 0;
            anim.SetBool("sald�r�", true);
            anim.SetFloat("vuru�lar", 1);
            b�cakl�();
            animonay = true;
            vuru�zaman� = true;
            timee = 14;
        }
        else
        {
            anim.SetBool("sald�r�", false);

        }
        if (animonay == true)
        {
            animduration += Time.deltaTime;
            if (animduration < 0.8f)
            {
                bitiri� = 0;

            }
            else
            {
                animonay = false;
            }
        }
    }
    void a�a��sald�r�()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bitiri� > 0.2f)
        {
            animduration = 0;
            anim.SetBool("sald�r�", true);
            anim.SetFloat("vuru�lar", -1);
            b�cakl�();
            animonay = true;
            vuru�zaman� = true;
            timee = 14;
        }
        else
        {
            anim.SetBool("sald�r�", false);
        }
        if (animonay == true)
        {
            animduration += Time.deltaTime;
            if (animduration < 0.8f)
            {
                bitiri� = 0;

            }
            else
            {
                animonay = false;
            }
        }

    }
    public GameObject box;
    public Animator bbox;
    void y�r�me()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("haraket", true);
            anim.SetFloat("Blend", 0);
            bbox.SetFloat("Blend", 2);
            speed = 5;
            y�nkarar� = 0;
            y�r�mesesi();
            //a�a��sald�r�();
            spi.flipX = false;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("haraket", true);
            anim.SetFloat("Blend", 1);
            bbox.SetFloat("Blend", 1);
            speed = 5;
            y�nkarar� = 1;
            y�r�mesesi();
            //sa�sald�r�();
            y�nkarar� = 1;
            spi.flipX = true;

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("haraket", true);
            anim.SetFloat("Blend", 1);
            bbox.SetFloat("Blend", 1);
            speed = 5;
            y�nkarar� = 2;
            y�r�mesesi();
            //solsald�r�();
            spi.flipX = false;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("haraket", true);
            anim.SetFloat("Blend", -1);
            bbox.SetFloat("Blend", 2);
            speed = 5;
            y�nkarar� = 3;
            y�r�mesesi();
            //yukar�sald�r�();
            spi.flipX = false;

        }
        else
        {
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                anim.SetBool("haraket", false);
                bbox.SetFloat("Blend", 3);
                speed = 0;
                y�nkarar� = 0;
                metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                anim.SetBool("haraket", true);
                anim.SetFloat("Blend", 2);
                bbox.SetFloat("Blend", 0);
                speed = 0;
                metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

                y�nkarar� = 1;
                spi.flipX = true;

            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                anim.SetBool("haraket", true);
                anim.SetFloat("Blend", 2);
                bbox.SetFloat("Blend", 0);
                speed = 0;
                metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

                y�nkarar� = 2;
                spi.flipX = false;
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                anim.SetBool("haraket", true);
                anim.SetFloat("Blend", 1.5f);
                bbox.SetFloat("Blend", 3);
                speed = 0;
                metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);


                y�nkarar� = 3;
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
                 print("d��mana vuruldu");
             }
             print("d��mana menzilinde");
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
            bitiri� = 0;
        }
     
             if (animonay == true)
        {
            animduration += Time.deltaTime;
            if (animduration < 0.8f)
            {
                hammer.SetActive(true);
                hamanim.SetBool("savurum", true);
                hamanim.SetFloat("cek�c", 0);
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
