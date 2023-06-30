using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class numberofbullet : MonoBehaviour
{
    private TextMeshProUGUI bullettext;
    public int number;
    public static int magbullet = 6;
    public static int riflebullet = 15;
    public static int shotgunbullet = 2;
    public static int maxmagbullet = 18;
    public static int maxriflebullet = 45;
    public static int maxshotgunbullet = 12;
    void Start()
    {
        bullettext = GetComponent<TextMeshProUGUI>();
        /* magbullet = 6;
         riflebullet = 15;
         shotgunbullet = 2;
         maxmagbullet = 18;
         maxriflebullet = 45;
         maxshotgunbullet = 12;*/
        //load2();
        /*if (SceneManager.GetActiveScene().name == "FinalBoss" || SceneManager.GetActiveScene().name == "TankBoss" || SceneManager.GetActiveScene().name == "Helicapter Boss" || SceneManager.GetActiveScene().name == "Level_2" || SceneManager.GetActiveScene().name == "Level_3")
        {
            load2();
        }*/
    }
    public void save2()
    {
        savesystem.saveplayer2(this);
    }
    public void load2()
    {
        Data datas = savesystem.loadplayer();
        magbullet = datas.magbullet;
        riflebullet = datas.riflebullet;
        shotgunbullet = datas.shotgunbullet;
        maxmagbullet = datas.maxmagbullet;
        maxriflebullet = datas.maxriflebullet;
        maxshotgunbullet = datas.maxshotgunbullet;
    }

    public bool notheresave;
    void Update()
    {
        /*if (level1gamecontroller.saveagree == true)
        {
            
        }*/
        if (!notheresave)
        {
            save2();
        }
        
        if (DialogueManager.loadagree == true)
        {
            load2();
            DialogueManager.loadagree = false;
        }
        if (number == 1)
        {
            bullettext.text = ("Ammo: " + magbullet.ToString() + "/" + maxmagbullet.ToString());
        }
        else if(number == 2)
        {
            bullettext.text = ("Ammo: " + riflebullet.ToString() + "/" + maxriflebullet.ToString());
        }
        else if(number == 3)
        {
            bullettext.text = ("Ammo: " + shotgunbullet.ToString() + "/" + maxshotgunbullet.ToString());
        }
        
    }
}
