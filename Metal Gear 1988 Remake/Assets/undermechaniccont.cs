using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class undermechaniccont : MonoBehaviour
{
    public GameObject[] rokets;
    public GameObject[] lazers;
    public GameObject[] buttons;
    int enemyhealth = 100;
    public Slider slider;
    public GameObject[] explosions;
    FMOD.Studio.EventInstance damageGive;
    FMOD.Studio.EventInstance relaxMusic;
    FMOD.Studio.EventInstance battleMusic;
    float itgoesdark;
    public CanvasGroup screenpass;
    public GameObject explotionsound;
    public Animator anim;

    private void Awake()
    {
        Cursor.visible = true;

        damageGive = FMODUnity.RuntimeManager.CreateInstance("event:/damagegivet");
        relaxMusic = FMODUnity.RuntimeManager.CreateInstance("event:/relaxmusic");
        battleMusic = FMODUnity.RuntimeManager.CreateInstance("event:/battlemusic");
    }

    void Start()
    {
        enemyhealth = (int)slider.maxValue;
        anim = GameObject.FindWithTag("Enemy").GetComponent<Animator>();

        relaxMusic.start();

        if(level == 3)
        {
            enemyhealth = 200;
        }
        else if(level == 2)
        {
            enemyhealth = 150;
        }
        else if(level == 1)
        {
            enemyhealth = 100;
        }
    }

    static bool startfight = false;
    float time1;
    int herhangi;
    float time2;
    float time3;
    float time5;
    public float level;
    void Update()
    {
        print(time5);
        screenpass.alpha = itgoesdark;
        if (enemyhealth <= 0)
        {
            time5 += Time.deltaTime;
            if (time5 > 0)
            {
                explotionsound.SetActive(true);
                explosions[0].SetActive(true);
            }
            if (time5 > 0.5f)
            {
                explosions[1].SetActive(true);
            }
            if (time5 > 1f)
            {
                explosions[2].SetActive(true);
            }
            if (time5 > 1.5f)
            {
                explosions[3].SetActive(true);
            }
            if (time5 > 1.6f)
            {
                itgoesdark += Time.deltaTime / 3;
                if(itgoesdark >= 1)
                {
                    if(level == 3)
                    {
                        SceneManager.LoadScene(11);
                        battleMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    }
                    else if(level == 2)
                    {
                        SceneManager.LoadScene(6);
                        battleMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    }
                    else if(level == 1)
                    {
                        SceneManager.LoadScene(4);
                        battleMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    }
                    
                }

            }
        }
        if (level == 3)
        {
            slider.value = enemyhealth;
            if (startfight == true)
            {
                time1 += Time.deltaTime;
                float zamansýklýðý = Random.Range(1, 2);
                if (time1 > zamansýklýðý)
                {
                    herhangi = Random.Range(1, 5);
                    if (herhangi == 1)
                    {
                        rokets[0].SetActive(true);
                    }
                    else if (herhangi == 2)
                    {
                        rokets[1].SetActive(true);
                    }
                    else if (herhangi == 3)
                    {
                        rokets[2].SetActive(true);
                    }
                    else if (herhangi == 4)
                    {
                        rokets[3].SetActive(true);
                    }
                    time1 = 0;
                }
                if (enemyhealth <= 0)
                {
                    SceneManager.LoadScene("Level_2");
                }
                time2 += Time.deltaTime;
                float zamansýklýý2 = Random.Range(7, 10);
                if (time2 > zamansýklýý2)
                {
                    herhangi = Random.Range(1, 4);
                    if (herhangi == 1)
                    {
                        lazers[0].SetActive(true);
                    }
                    else if (herhangi == 2)
                    {
                        lazers[1].SetActive(true);
                    }
                    else if (herhangi == 3)
                    {
                        lazers[2].SetActive(true);
                    }
                    time2 = 0;
                }
                time3 += Time.deltaTime;
                if (time3 > 25)
                {
                    startfight = false;

                    battleMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    relaxMusic.start();

                    buttons[0].SetActive(true);
                    //buttons[1].SetActive(true);
                    buttons[2].SetActive(true);
                    time3 = 0;
                }


            }
        }
        else if(level == 2)
        {
            slider.value = enemyhealth;
            if (startfight == true)
            {
                time1 += Time.deltaTime;
                float zamansýklýðý = Random.Range(1, 2);
                if (time1 > zamansýklýðý)
                {
                    herhangi = Random.Range(1, 8);
                    if (herhangi == 1)
                    {
                        rokets[0].SetActive(true);
                    }
                    else if (herhangi == 2)
                    {
                        rokets[1].SetActive(true);
                    }
                    else if (herhangi == 3)
                    {
                        rokets[2].SetActive(true);
                    }
                    else if (herhangi == 4)
                    {
                        rokets[3].SetActive(true);
                    }
                    else if(herhangi == 5)
                    {
                        lazers[0].SetActive(true);
                    }
                    else if (herhangi == 6)
                    {
                        lazers[1].SetActive(true);
                    }
                    else if (herhangi == 7)
                    {
                        lazers[2].SetActive(true);
                    }
                    time1 = 0;
                }
               
                time3 += Time.deltaTime;
                if (time3 > 25)
                {
                    startfight = false;

                    battleMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    relaxMusic.start();

                    buttons[0].SetActive(true);
                    //buttons[1].SetActive(true);
                    buttons[2].SetActive(true);
                    time3 = 0;
                }


            }
        }
        else if(level == 1)
        {
            slider.value = enemyhealth;
            if (startfight == true)
            {
                time1 += Time.deltaTime;
                float zamansýklýðý = Random.Range(1, 2);
                if (time1 > zamansýklýðý)
                {
                    herhangi = Random.Range(1, 5);
                    if (herhangi == 1)
                    {
                        rokets[0].SetActive(true);
                    }
                    else if (herhangi == 2)
                    {
                        rokets[1].SetActive(true);
                    }
                    else if (herhangi == 3)
                    {
                        rokets[2].SetActive(true);
                    }
                    else if (herhangi == 4)
                    {
                        rokets[3].SetActive(true);
                    }
                    time1 = 0;
                }
               /* if (enemyhealth <= 0)
                {
                    if(level == 1)
                    {
                        SceneManager.LoadScene(4);
                    }
                    else if(level == 2)
                    {
                        SceneManager.LoadScene(6);
                    }
                    
                }*/
                time3 += Time.deltaTime;
                if (time3 > 25)
                {
                    startfight = false;

                    battleMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    relaxMusic.start();

                    buttons[0].SetActive(true);
                    //buttons[1].SetActive(true);
                    buttons[2].SetActive(true);
                    time3 = 0;
                }


            }
        }
        if(enemyhealth > 0)
        {
            if (attaked)
            {

                buttons[0].SetActive(false);
                //buttons[1].SetActive(false);
                buttons[2].SetActive(false);
                time4 += Time.deltaTime;
                if (time4 < 1)
                {
                    enemyrenk.color = Color.red;
                }
                else if (time4 > 1)
                {
                    enemyrenk.color = Color.white;

                }
                if (time4 > 0.1f)
                {
                    anim.SetBool("sallanma", false);
                }

                if (time4 > 4)
                {
                    startfight = true;
                    attaked = false;
                    time4 = 0;
                }
            }
        }
        
    }

    bool attaked;
    float time4;
    public SpriteRenderer enemyrenk;
    public void attack()
    {
        int canalma = Random.Range(20, 35);
        enemyhealth -= canalma;
        attaked = true;
        anim.SetBool("sallanma", true);

        damageGive.start();
        relaxMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        battleMusic.start();
    }

    public void item()
    {

    }

    public void flee()
    {
        int bb = Random.Range(0, 2);
        if(bb == 0)
        {
            attaked = true;
        }
        else if(bb == 1)
        {
            if (level == 1)
            {
                SceneManager.LoadScene(14);
            }
            else if (level == 2)
            {
                SceneManager.LoadScene(12);
            }
            else if (level == 3)
            {
                SceneManager.LoadScene(13);
            }
        }
        
    }

}
