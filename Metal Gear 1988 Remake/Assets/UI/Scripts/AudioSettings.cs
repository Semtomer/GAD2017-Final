using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    FMOD.Studio.EventInstance SFXVolumeTestEvent;

    FMOD.Studio.Bus music;
    FMOD.Studio.Bus SFX;

    public static float musicVolume = 1f;
    float SFXVolume = 1f;

    private void Awake()
    {
        music = FMODUnity.RuntimeManager.GetBus("bus:/Bus");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/SFX");

        SFXVolumeTestEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX");

    }

    private void Update()
    {
        music.setVolume(musicVolume);
        SFX.setVolume(SFXVolume);

        if (karakterkontrol.actiontime < 5)
        {
            EnemyAI.backgroundMusic.setVolume(0f);
            EnemyAI.whenFight.setVolume(AudioSettings.musicVolume);

        }
        else
        {
            EnemyAI.backgroundMusic.setVolume(AudioSettings.musicVolume);
            EnemyAI.whenFight.setVolume(0f);
        }

        if (karakterkontrol.actiontime < 5)
        {
            EnemyAII.backgroundMusic.setVolume(0f);
            EnemyAII.whenFight.setVolume(AudioSettings.musicVolume);

        }
        else
        {
            EnemyAII.backgroundMusic.setVolume(AudioSettings.musicVolume);
            EnemyAII.whenFight.setVolume(0f);
        }

        karakterkontrol.metalwalk.setVolume(SFXVolume);
        karakterkontrol.knifeWhoosh.setVolume(SFXVolume);
        karakterkontrol.gunDraw1.setVolume(SFXVolume);
        karakterkontrol.gunDraw2.setVolume(SFXVolume);
        karakterkontrol.gunDraw3.setVolume(SFXVolume);
        karakterkontrol.knifePullOut.setVolume(SFXVolume);
        karakterkontrol.whenHit.setVolume(SFXVolume);
        bulletfire.gunShoot1.setVolume(SFXVolume);
        bulletfire.gunShoot2.setVolume(SFXVolume);
        bulletfire.gunShoot3.setVolume(SFXVolume);
        bulletfire.gunReload1.setVolume(SFXVolume);
        bulletfire.gunReload2.setVolume(SFXVolume);
        bulletfire.gunReload3.setVolume(SFXVolume);
        bulletfire.outOfBullet1.setVolume(SFXVolume);
        bulletfire.outOfBullet2.setVolume(SFXVolume);
        bulletfire.outOfBullet3.setVolume(SFXVolume);
        enemyfire.gunShoot2.setVolume(SFXVolume);
        granadescript.bomb.setVolume(SFXVolume);
        Hole_Trap.holeTrapSound.setVolume(SFXVolume);
        laserSoundController.laserSound.setVolume(SFXVolume);
        laserSoundController.rollingCylinder.setVolume(SFXVolume);
        VenomSnack.whenHit.setVolume(SFXVolume);
        VenomSnack.teleporting1.setVolume(SFXVolume);
        VenomSnack.teleporting2.setVolume(SFXVolume);
        miniboss.whenHit.setVolume(SFXVolume);
        tankboss.whenHit.setVolume(SFXVolume);
        tankboss.ropeSound.setVolume(SFXVolume);
        EnemyAI.getStabWound.setVolume(SFXVolume);
        EnemyAII.getStabWound.setVolume(SFXVolume);
        EnemyAI.noticed.setVolume(SFXVolume);
        EnemyAII.noticed.setVolume(SFXVolume);
        EnemyAI.whenHit.setVolume(SFXVolume);
        EnemyAII.whenHit.setVolume(SFXVolume);
        DialogueManager.Typewriter.setVolume(SFXVolume);
        sellersystem.buy.setVolume(SFXVolume);
        sellersystem.lackOfMoney.setVolume(SFXVolume);

    }

    public void MusicVolumeLevel(float newMusicVolume)
    {
        musicVolume = newMusicVolume;
    }

    public void SFXVolumeLevel(float newSFXVolume)
    {
        SFXVolume = newSFXVolume;

        FMOD.Studio.PLAYBACK_STATE PBState;
        SFXVolumeTestEvent.getPlaybackState(out PBState);
        if (PBState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            SFXVolumeTestEvent.start();
        }
    }
}