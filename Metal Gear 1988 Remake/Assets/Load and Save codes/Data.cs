using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    //player
    public int health;
    public int magdamage;
    public int rifledamage;
    public int shotdamage;

    //sellersystem
    public int coin;
    public int granadee;
    public int boxx;

    //numberofbullet
    public int magbullet;
    public int riflebullet;
    public int shotgunbullet;
    public int maxmagbullet;
    public int maxriflebullet;
    public int maxshotgunbullet;

    public Data (karakterkontrol player)
    {
        health = karakterkontrol.health;
        magdamage = karakterkontrol.magdamage;
        rifledamage = karakterkontrol.rifledamage;
        shotdamage = karakterkontrol.shotgundamage;
    }

    public Data(sellersystem seller)
    {
        coin = sellersystem.Coin;
        granadee = sellersystem.granadee;
        boxx = sellersystem.boxx;
    }

    public Data(numberofbullet bullets)
    {
        magbullet = numberofbullet.magbullet;
        riflebullet = numberofbullet.riflebullet;
        shotgunbullet = numberofbullet.shotgunbullet;
        maxmagbullet = numberofbullet.maxmagbullet;
        maxriflebullet = numberofbullet.maxriflebullet;
        maxshotgunbullet = numberofbullet.maxshotgunbullet;
    }
}