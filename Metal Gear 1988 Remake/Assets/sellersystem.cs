using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sellersystem : MonoBehaviour
{
    
    public GameObject press_symbol;
    public Text presstext;
    public CanvasGroup textofinfo;
    public static int Coin = 0;
    public GameObject[] magupgrates;
    public GameObject[] rifleupgrates;
    public GameObject[] shotgunuprates;
    public GameObject shop;
    public Text CoinShow;
    bool atinarea;
    float radius = 2;
    public LayerMask player;
    float onay = 1.2f;
    float görünme;

    public static FMOD.Studio.EventInstance buy;
    public static FMOD.Studio.EventInstance lackOfMoney;
    void Start()
    {
        /*if (SceneManager.GetActiveScene().name == "FinalBoss" || SceneManager.GetActiveScene().name == "TankBoss" || SceneManager.GetActiveScene().name == "Helicapter Boss" || SceneManager.GetActiveScene().name == "Level_2" || SceneManager.GetActiveScene().name == "Level_3")
        {
            load1();
        }*/
    }
    public void save1()
    {
        savesystem.saveplayer1(this);
    }
    public void load1()
    {
        Data datas = savesystem.loadplayer();
        Coin = datas.coin;
        granadee = datas.granadee;
        boxx = datas.boxx;
    }
    private void Awake()
    {
        buy = FMODUnity.RuntimeManager.CreateInstance("event:/SuccessfullBuy");
        lackOfMoney = FMODUnity.RuntimeManager.CreateInstance("event:/UnsuccessfullBuy");
    }
    public bool notheresave;
    void Update()
    {
        /*if (level1gamecontroller.saveagree == true)
        {
            
        }*/
        if (!notheresave)
        {
            save1();
        }
        
        if (DialogueManager.loadagree == true)
        {
            load1();
            DialogueManager.loadagree = false;
        }
        CoinShow.text = Coin.ToString();
        atinarea = Physics2D.OverlapCircle(transform.position, radius, player);
        textofinfo.alpha = görünme;
        görünme -= Time.deltaTime / 2;
        if(atinarea == true)
        {
            if(onay > 1)
            {
                press_symbol.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                onay = 0;
                görünme = 1;
                presstext.text = "Welcome";
                press_symbol.SetActive(false);
                shop.SetActive(true);
            }
        }
        else
        {
            onay = 1.2f;
            press_symbol.SetActive(false);
            shop.SetActive(false);
            Cursor.visible = true;
        }
        if(magupgratee >= 1)
        {
            magupgrates[0].SetActive(true);
        }
        else if(magupgratee >= 2)
        {
            magupgrates[1].SetActive(true);
        }
        else if (magupgratee == 3)
        {
            magupgrates[2].SetActive(true);
        }

        if (rifleupgradee >= 1)
        {
            rifleupgrates[0].SetActive(true);
        }
        else if (rifleupgradee >= 2)
        {
            rifleupgrates[1].SetActive(true);
        }
        else if (rifleupgradee == 3)
        {
            rifleupgrates[2].SetActive(true);
        }

        if (shougunupgratee >= 1)
        {
            shotgunuprates[0].SetActive(true);
        }
        else if (shougunupgratee >= 2)
        {
            shotgunuprates[1].SetActive(true);
        }
        else if (shougunupgratee == 3)
        {
            shotgunuprates[2].SetActive(true);
        }

        boxtext.text = "X" + boxx;
        granadetext.text = "X" + granadee;
    }

    public void exit()
    {
        press_symbol.SetActive(true);
        shop.SetActive(false);

        Cursor.visible = false;
    }
    int magupgratee;
    public void magupgrate()
    {
        if( Coin >= 10 && magupgratee <3)
        {
            Coin -= 10;
            magupgratee++;
            karakterkontrol.magdamage += 5;
            görünme = 1;
            presstext.text = "your weapon upgraded";
            buy.start();
        }
        else if (Coin < 10)
        {
            görünme = 1;
            presstext.text = "you do not have enough coin";
            lackOfMoney.start();
        }
        else if (magupgratee > 3)
        {
            görünme = 1;
            presstext.text = "that is max level";
            lackOfMoney.start();
        }
    }
    int rifleupgradee;
    public void rifleupgrade()
    {
        if (Coin >= 20 && rifleupgradee < 2)
        {
            Coin -= 20;
            rifleupgradee++;
            karakterkontrol.rifledamage += 5;
            görünme = 1;
            presstext.text = "your weapon upgraded";
            buy.start();
        }
        else if (Coin < 20)
        {
            görünme = 1;
            presstext.text = "you do not have enough coin";
            lackOfMoney.start();
        }
        else if (rifleupgradee > 3)
        {
            görünme = 1;
            presstext.text = "that is max level";
            lackOfMoney.start();
        }
    }
    int shougunupgratee;
    public void shotgunupgrade()
    {
        if (Coin >= 15 && shougunupgratee < 3)
        {
            Coin -= 15;
            shougunupgratee++;
            karakterkontrol.shotgundamage += 10;
            görünme = 1;
            presstext.text = "your weapon upgraded";
            buy.start();
        }
        else if(Coin < 15)
        {
            görünme = 1;
            presstext.text = "you do not have enough coin";
            lackOfMoney.start();
        }
        else if(shougunupgratee > 3)
        {
            görünme = 1;
            presstext.text = "that is max level";
            lackOfMoney.start();
        }
    }

    public void magammo()
    {
        if(Coin >= 5)
        {
            Coin -= 5;
            numberofbullet.maxmagbullet += 6;
            buy.start();
        }
        else
        {
            görünme = 1;
            presstext.text = "you do not have enough coin";
            lackOfMoney.start();
        }
    }

    public void rifleammo()
    {
        if(Coin >= 5)
        {
            Coin -= 5;
            numberofbullet.maxriflebullet += 15;
            buy.start();
        }
        else
        {
            görünme = 1;
            presstext.text = "you do not have enough coin";
            lackOfMoney.start();
        }
    }

    public void shotgunammo()
    {
        if (Coin >= 5)
        {
            Coin -= 5;
            numberofbullet.maxshotgunbullet += 2;
            buy.start();
        }
        else
        {
            görünme = 1;
            presstext.text = "you do not have enough coin";
            lackOfMoney.start();
        }
    }
    public static int granadee = 1;
    public Text granadetext;
    public void granade()
    {
        if (Coin >= 15)
        {
            Coin -= 15;
            granadee += 1;
            buy.start();
        }
        else
        {
            görünme = 1;
            presstext.text = "you do not have enough coin";
            lackOfMoney.start();
        }
    }
    public static int boxx = 1;
    public Text boxtext;
    public void box()
    {
        if (Coin >= 10)
        {
            Coin -= 10;
            boxx += 1;
            buy.start();
        }
        else
        {
            görünme = 1;
            presstext.text = "you do not have enough coin";
            lackOfMoney.start();
        }
    }
}
