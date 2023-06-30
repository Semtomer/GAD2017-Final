using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1gamecontroller : MonoBehaviour
{
    //FMOD.Studio.EventInstance metalwalk;
    
    void Start()
    {
        EnemyAI.whenFight.start();
        EnemyAI.whenFight.setVolume(0f);
        EnemyAII.whenFight.start();
        EnemyAII.whenFight.setVolume(0f);
        EnemyAI.backgroundMusic.start();
        EnemyAII.backgroundMusic.start();
        //SceneManager.GetActiveScene().name == "FinalBoss"
       /* if (SceneManager.GetActiveScene().name == "FinalBoss" || SceneManager.GetActiveScene().name == "TankBoss" || SceneManager.GetActiveScene().name == "Helicapter Boss" || SceneManager.GetActiveScene().name == "Level_1" || SceneManager.GetActiveScene().name == "Level_2" || SceneManager.GetActiveScene().name == "Level_3" || SceneManager.GetActiveScene().name == "Underhecopter" || SceneManager.GetActiveScene().name == "Undertale" || SceneManager.GetActiveScene().name == "undertank")
        {

            //
            
        }
        else
        {
            
            //EnemyAI.whenFight.start();
            //EnemyAII.whenFight.start();

        }*/
        
        karakterkontrol.metalwalk = FMODUnity.RuntimeManager.CreateInstance("event:/OnMetalSurface/Walking");
        //screenpass = GetComponent<CanvasGroup>();
        //enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyAI>();
        //enemyy = GameObject.FindWithTag("Enemy").GetComponent<EnemyAII>();
    }
    public static bool conversationwork;
    public EnemyAI[] enemy;
    public EnemyAII[] enemyy;
    public enemyfire[] fireenemy;
    public karakterkontrol player;
    public bulletfire fire;
    public CanvasGroup screenpass;
    public miniboss miniboss;
    public tankboss tankboss;
    public VenomSnack bigboss;
    bool whenleave = false;
    public int level;
    bool atinrange = false;
    public GameObject pressE;
    float screen = 1;
    void Update()
    {
        if(level == 1 || level == 3)
        {
            if (atinrange == false)
            {
                if (conversationwork == true)
                {
                    karakterkontrol.metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    whenleave = true;
                    for (int i = 0; i < enemy.Length; i++)
                    {
                        enemy[i].enabled = false;
                    }
                    for (int i = 0; i < enemyy.Length; i++)
                    {
                        enemyy[i].enabled = false;
                    }
                    for (int i = 0; i < fireenemy.Length; i++)
                    {
                        fireenemy[i].enabled = false;
                    }
                    player.enabled = false;
                    fire.enabled = false;
                }
                else
                {
                    whenleave = false;
                    for (int i = 0; i < enemy.Length; i++)
                    {
                        enemy[i].enabled = true;
                    }
                    for (int i = 0; i < enemyy.Length; i++)
                    {
                        enemyy[i].enabled = true;
                    }
                    for (int i = 0; i < fireenemy.Length; i++)
                    {
                        fireenemy[i].enabled = true;
                    }
                    player.enabled = true;
                    fire.enabled = true;
                }
            }
        }
        else if(level == 2)
        {
            if (atinrange == false)
            {
                if (conversationwork == true)
                {
                    karakterkontrol.metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    whenleave = true;
                    for (int i = 0; i < enemy.Length; i++)
                    {
                        enemy[i].enabled = false;
                    }
                    for (int i = 0; i < enemyy.Length; i++)
                    {
                        enemyy[i].enabled = false;
                    }
                    for (int i = 0; i < fireenemy.Length; i++)
                    {
                        fireenemy[i].enabled = false;
                    }
                    player.enabled = false;
                    fire.enabled = false;
                    miniboss.enabled = false;
                }
                else
                {
                    whenleave = false;
                    for (int i = 0; i < enemy.Length; i++)
                    {
                        enemy[i].enabled = true;
                    }
                    for (int i = 0; i < enemyy.Length; i++)
                    {
                        enemyy[i].enabled = true;
                    }
                    for (int i = 0; i < fireenemy.Length; i++)
                    {
                        fireenemy[i].enabled = true;
                    }
                    player.enabled = true;
                    fire.enabled = true;
                    miniboss.enabled = true;
                }
            }
        }
        else if(level == 3)
        {
            if (atinrange == false)
            {
                if (conversationwork == true)
                {
                    karakterkontrol.metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    whenleave = true;
                    for (int i = 0; i < enemy.Length; i++)
                    {
                        enemy[i].enabled = false;
                    }
                    for (int i = 0; i < enemyy.Length; i++)
                    {
                        enemyy[i].enabled = false;
                    }
                    for (int i = 0; i < fireenemy.Length; i++)
                    {
                        fireenemy[i].enabled = false;
                    }
                    player.enabled = false;
                    fire.enabled = false;
                }
                else
                {
                    whenleave = false;
                    for (int i = 0; i < enemy.Length; i++)
                    {
                        enemy[i].enabled = true;
                    }
                    for (int i = 0; i < enemyy.Length; i++)
                    {
                        enemyy[i].enabled = true;
                    }
                    for (int i = 0; i < fireenemy.Length; i++)
                    {
                        fireenemy[i].enabled = true;
                    }
                    player.enabled = true;
                    fire.enabled = true;
                }
            }
        }
        else if(level == 4)
        {
            if (atinrange == false)
            {
                if (conversationwork == true)
                {
                    karakterkontrol.metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    whenleave = true;
                    player.enabled = false;
                    fire.enabled = false;
                }
                else
                {
                    whenleave = false; 
                    player.enabled = true;
                    fire.enabled = true;

                }
            }
        }
        else if(level == 5)
        {
            if (atinrange == false)
            {
                if (conversationwork == true)
                {
                    karakterkontrol.metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    whenleave = true;
                    tankboss.enabled = false;
                    fireenemy[0].enabled = false;
                    player.enabled = false;
                    fire.enabled = false;
                }
                else
                {
                    whenleave = false;
                    tankboss.enabled = true;
                    fireenemy[0].enabled = true;
                    player.enabled = true;
                    fire.enabled = true;
                }
            }
        }
        else if(level == 6)
        {
            if (atinrange == false)
            {
                if (conversationwork == true)
                {
                    karakterkontrol.metalwalk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    whenleave = true;
                    bigboss.enabled = false;
                    fireenemy[0].enabled = false;
                    player.enabled = false;
                    fire.enabled = false;
                }
                else
                {
                    whenleave = false;
                    bigboss.enabled = true;
                    fireenemy[0].enabled = true;
                    player.enabled = true;
                    fire.enabled = true;
                }
            }
        }
        

        screenpass.alpha = screen;
         if(whenleave == false)
         {
             screen -= Time.deltaTime/3;
         }
         else
         {
             screen += Time.deltaTime/3;
         }
        if(screen >= 1)
        {
            screen = 1;
        }
        else if(screen <= 0)
        {
            screen = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            whenleave = true;
        }
        if (atinrange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                zamanýgelince = true;
                whenleave = true;
                print("selam");
            }
            if (zamanýgelince == true)
            {
                if(screen >= 0.99f)
                {
                    if (level == 1)
                    {
                        saveagree = true;
                        SceneManager.LoadScene(3);
                        saveagree = false;
                        EnemyAI.backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAII.backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAI.whenFight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAII.whenFight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    }
                    else if (level == 2)
                    {
                        saveagree = true;
                        SceneManager.LoadScene(5);
                        saveagree = false;
                        EnemyAI.backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAII.backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAI.whenFight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAII.whenFight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    }
                    else if (level == 3)
                    {
                        saveagree = true;
                        SceneManager.LoadScene(7);
                        saveagree = false;
                        EnemyAI.backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAII.backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAI.whenFight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAII.whenFight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    }
                    else if(level == 4)
                    {
                        saveagree = true;
                        SceneManager.LoadScene(9);
                        saveagree = false;
                        EnemyAI.backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAII.backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAI.whenFight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAII.whenFight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    }
                    else if(level == 7)//final
                    {
                        SceneManager.LoadScene(8);
                        EnemyAI.backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAII.backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAI.whenFight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAII.whenFight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    }
                    else if(level == 8)//tank
                    {
                        SceneManager.LoadScene(10);
                        EnemyAI.backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAII.backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAI.whenFight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        EnemyAII.whenFight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    }
                    zamanýgelince = false;
                    whenleave = false;
                }
                
            }
        }
    }
    public static bool saveagree;
    bool zamanýgelince;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gamer")
        {
            pressE.SetActive(true);
            atinrange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collisionnn)
    {
        if (collisionnn.gameObject.tag == "Gamer")
        {
            atinrange = false;
            pressE.SetActive(false);
        }
    }
}
