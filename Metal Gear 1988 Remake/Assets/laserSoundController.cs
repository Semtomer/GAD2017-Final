using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserSoundController : MonoBehaviour
{
    public static FMOD.Studio.EventInstance laserSound;
    public static FMOD.Studio.EventInstance rollingCylinder;

    private void Awake()
    {
        laserSound = FMODUnity.RuntimeManager.CreateInstance("event:/laserOnLevel");
        rollingCylinder = FMODUnity.RuntimeManager.CreateInstance("event:/metalRolling");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "laser1")
        {
            if (littleBossManager.isActive1 == true)
            {
                laserSound.start();
            }
            else
            {
                laserSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }   
        }
        else if (gameObject.tag == "laser2")
        {
            if (littleBossManager.isActive2 == true)
            {
                laserSound.start();
            }
            else
            {
                laserSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }
        else if (gameObject.tag == "laser3")
        {
            if (collision.gameObject.tag == "Gamer")
            {
                laserSound.start();
            }
        }
        else if (gameObject.tag == "rollingCylinder")
        {
            rollingCylinder.start();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gamer")
        {
            laserSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            rollingCylinder.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
