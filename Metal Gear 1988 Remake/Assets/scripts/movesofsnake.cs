using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movesofsnake : MonoBehaviour
{
    Rigidbody2D rig;
    float speed = 10;
    public Slider slider;
    public int level;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        karakterkontrol.health = (int)slider.maxValue;
    }
    float h;
    float v;
    // Update is called once per frame
    void Update()
    {
        slider.value = karakterkontrol.health;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if(karakterkontrol.health <= 0)
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

    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + new Vector2(h, v) * speed * Time.fixedDeltaTime);
    }
}
