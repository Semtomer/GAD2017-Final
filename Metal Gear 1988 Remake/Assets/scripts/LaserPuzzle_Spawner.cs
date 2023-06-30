using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPuzzle_Spawner : MonoBehaviour
{
    private int rand;
    public Sprite[] Sprite_Pic;
    private int currentIndex;

    public GameObject[] Collisions;
    
    void Start()
    {
        currentIndex = 0;
        Collisions[currentIndex].SetActive(true);
        StartCoroutine(Change());
    }

    public IEnumerator Change()
    {
        while (true)
        { 
            yield return new WaitForSeconds(3);

            do
            {
                Collisions[currentIndex].SetActive(false);
                rand = Random.Range(0, Sprite_Pic.Length);

            } while (currentIndex == rand);

            GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand];
            currentIndex = rand;

            Collisions[currentIndex].SetActive(true);
        }     
    }
}
