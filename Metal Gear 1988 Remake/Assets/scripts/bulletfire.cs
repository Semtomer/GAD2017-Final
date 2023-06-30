using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bulletfire : MonoBehaviour
{
    public GameObject magnummermi;
    public GameObject shotmermi;
    public Transform fireeffect;
    public GameObject fireef;
    public GameObject riflemermi;
    public Animator camshake;

    public static FMOD.Studio.EventInstance gunShoot1;
    public static FMOD.Studio.EventInstance gunShoot2;
    public static FMOD.Studio.EventInstance gunShoot3;
    public static FMOD.Studio.EventInstance outOfBullet1;
    public static FMOD.Studio.EventInstance outOfBullet2;
    public static FMOD.Studio.EventInstance outOfBullet3;
    public static FMOD.Studio.EventInstance gunReload1;
    public static FMOD.Studio.EventInstance gunReload2;
    public static FMOD.Studio.EventInstance gunReload3;

    public GameObject[] bulletamountview;
    private GameObject enemy;
    public static bool firedsound;
    public GameObject Granade;
    public static bool bombthrowed;

    private void Awake()
    {
        gunShoot1 = FMODUnity.RuntimeManager.CreateInstance("event:/ShootingWeapon/revolverShoot");
        gunShoot2 = FMODUnity.RuntimeManager.CreateInstance("event:/ShootingWeapon/rifleShoot");
        gunShoot3 = FMODUnity.RuntimeManager.CreateInstance("event:/ShootingWeapon/shotgunShoot");
        outOfBullet1 = FMODUnity.RuntimeManager.CreateInstance("event:/NoAmmoWeapon/revolverNoAmmo");
        outOfBullet2= FMODUnity.RuntimeManager.CreateInstance("event:/NoAmmoWeapon/rifleNoAmmo");
        outOfBullet3 = FMODUnity.RuntimeManager.CreateInstance("event:/NoAmmoWeapon/shotgunNoAmmo");
        gunReload1 = FMODUnity.RuntimeManager.CreateInstance("event:/ReloadingWeapon/magnumReload");
        gunReload2 = FMODUnity.RuntimeManager.CreateInstance("event:/ReloadingWeapon/rifleReload");
        gunReload3 = FMODUnity.RuntimeManager.CreateInstance("event:/ReloadingWeapon/shotgunReload");
    }

    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
    }
    float firestop = 4;
    float effectstop;
    bool effectstbool = false;
    void Update()
    {/*
        if (enemy == null)
        {
            karakterkontrol.spi.color = Color.white;
        }*/

        firestop += Time.deltaTime;
        if (karakterkontrol.yönkararý == 0)
        {
            transform.localPosition = new Vector2(-0.4f, -0.45f);
        }
        else if (karakterkontrol.yönkararý == 1)
        {
            transform.localPosition = new Vector2(0.4f, -0.3f);
        }
        else if (karakterkontrol.yönkararý == 2)
        {
            transform.localPosition = new Vector2(-0.4f, -0.3f);
        }
        else if (karakterkontrol.yönkararý == 3)
        {
            transform.localPosition = new Vector2(0.45f, -0.2f);
        }

        fireeffectt();
        if(bombthrowed == true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Instantiate<GameObject>(Granade, transform.position, Quaternion.identity);
            }
            
        }
        /*if (Input.GetKeyUp(KeyCode.B))
        {
            bombthrowed = false;
        }*/
        if (karakterkontrol.gunswip == 2)
        {
            bulletamountview[0].SetActive(true);
            bulletamountview[1].SetActive(false);
            bulletamountview[2].SetActive(false);
            if (firestop > 0.5f)
            {
                if(numberofbullet.magbullet > 0)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Instantiate<GameObject>(magnummermi, transform.position, Quaternion.identity);
                        firestop = 0;
                        fireef.SetActive(true);
                        effectstbool = true;
                        camshake.SetBool("shake", true);
                        gunShoot1.start();
                        numberofbullet.magbullet--;
                        karakterkontrol.timee = 14;
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        outOfBullet1.start();
                        firestop = 0;
                    }
                }

            }
            else
            {
                camshake.SetBool("shake", false);
            }
            int maxmagazine = 6;
            if (Input.GetKeyDown(KeyCode.R))
            {
                gunReload1.start();
                if(numberofbullet.maxmagbullet > 0)
                {

                    int amoundreload = Mathf.Min(maxmagazine - numberofbullet.magbullet,numberofbullet.maxmagbullet);
                    numberofbullet.magbullet += amoundreload;
                    numberofbullet.maxmagbullet -= amoundreload;
                    if(numberofbullet.maxmagbullet < 0)
                    {
                        numberofbullet.maxmagbullet = 0;
                       
                    }
                }

            }

        }
        else if(karakterkontrol.gunswip == 3)
        {
            bulletamountview[0].SetActive(false);
            bulletamountview[1].SetActive(true);
            bulletamountview[2].SetActive(false);
            if (firestop > 0.3f)
            {
                if (numberofbullet.riflebullet > 0)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        Instantiate<GameObject>(riflemermi, transform.position, Quaternion.identity);
                        firestop = 0;
                        fireef.SetActive(true);
                        effectstbool = true;
                        camshake.SetBool("shake", true);
                        gunShoot2.start();
                        numberofbullet.riflebullet--;
                        EnemyAII.detectedradius = 20;
                        EnemyAI.detectedradius = 20;
                        firedsound = true;
                        karakterkontrol.timee = 14;
                    }
                }
                else
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        outOfBullet2.start();
                        firestop = 0;
                    }
                }

            }
            else
            {
                camshake.SetBool("shake", false);
            }
            int maxmagazine = 15;
            if (Input.GetKeyDown(KeyCode.R))
            {
                gunReload2.start();
                if (numberofbullet.maxriflebullet > 0)
                {
                    int amoundreload = Mathf.Min(maxmagazine - numberofbullet.riflebullet,numberofbullet.maxriflebullet);
                    
                    numberofbullet.riflebullet += amoundreload;
                    numberofbullet.maxriflebullet -= amoundreload;
                    if (numberofbullet.maxriflebullet < 0)
                    {
                        numberofbullet.maxriflebullet = 0;
                        

                    }
                }

            }
        }
        else if(karakterkontrol.gunswip == 4)
        {
            bulletamountview[0].SetActive(false);
            bulletamountview[1].SetActive(false);
            bulletamountview[2].SetActive(true);
            if (firestop > 1)
            {
                if(numberofbullet.shotgunbullet > 0)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Instantiate<GameObject>(shotmermi, transform.position, Quaternion.identity);
                        }
                        firestop = 0;
                        fireef.SetActive(true);
                        effectstbool = true;
                        camshake.SetBool("shake", true);
                        gunShoot3.start();
                        numberofbullet.shotgunbullet -= 2;
                        EnemyAII.detectedradius = 20;
                        EnemyAI.detectedradius = 20;
                        firedsound = true;
                        karakterkontrol.timee = 14;
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        outOfBullet3.start();
                        firestop = 0;
                    }
                }
            }
            else
            {
                camshake.SetBool("shake", false);
            }
            int maxmagazine = 2;
            if (Input.GetKeyDown(KeyCode.R))
            {
                gunReload3.start();
                if (numberofbullet.maxshotgunbullet > 0)
                {
                    int amoundreload = Mathf.Min(maxmagazine - numberofbullet.shotgunbullet,numberofbullet.maxshotgunbullet);
                    numberofbullet.shotgunbullet += amoundreload;
                    numberofbullet.maxshotgunbullet -= amoundreload;
                    if (numberofbullet.maxshotgunbullet < 0)
                    {
                        numberofbullet.maxshotgunbullet = 0;

                    }
                }

            }
        }
        else if(karakterkontrol.gunswip == 1)
        {
            bulletamountview[0].SetActive(false);
            bulletamountview[1].SetActive(false);
            bulletamountview[2].SetActive(false);
        }

        if(effectstbool == true)
        {
            effectstop += Time.deltaTime;
            if(effectstop > 0.2f)
            {
                fireef.SetActive(false);
                effectstbool = false;
                effectstop = 0;
            }
        }

    }
    void fireeffectt()
    {
        if (karakterkontrol.yönkararý == 0)
        {
            fireeffect.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (karakterkontrol.yönkararý == 1)
        {
            fireeffect.rotation = Quaternion.Euler(0, 0, -180);
        }
        else if (karakterkontrol.yönkararý == 2)
        {
            fireeffect.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (karakterkontrol.yönkararý == 3)
        {
            fireeffect.rotation = Quaternion.Euler(0, 0, -90);
        }


        if (karakterkontrol.yönkararý == 0)
        {
            fireeffect.localPosition = new Vector2(-0.37f, -0.48f);
        }
        else if (karakterkontrol.yönkararý == 1)
        {
            fireeffect.localPosition = new Vector2(0.55f, -0.29f);
        }
        else if (karakterkontrol.yönkararý == 2)
        {
            fireeffect.localPosition = new Vector2(-0.55f, -0.31f);
        }
        else if (karakterkontrol.yönkararý == 3)
        {
            fireeffect.localPosition = new Vector2(0.45f, -0.1f);
        }
    }
}
