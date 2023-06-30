using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletsgone : MonoBehaviour
{
    Rigidbody2D rigi;
    Transform player;
    float speed = 50;
    float speed1 = 200;
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Gamer").GetComponent<Transform>();
        if(whosebulllet == true)
        {
            if (karakterkontrol.gunswip == 3)
            {
                Destroy(gameObject, 3);
            }
            else
            {
                Destroy(gameObject, 1);
            }
        }
        else if(whosebulllet == false)
        {
            Destroy(gameObject, 3);
        }
    }
    float timetopass = 1.3f;
    public bool whosebulllet = true;
    void Update()
    {
        if(whosebulllet == true)
        {
            if (karakterkontrol.gunswip == 2)
            {
                if (timetopass > 1.2f)
                {
                    if (karakterkontrol.yönkararý == 0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                    else if (karakterkontrol.yönkararý == 1)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                    else if (karakterkontrol.yönkararý == 2)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                    else if (karakterkontrol.yönkararý == 3)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    timetopass = 0;
                }
            }
            else if (karakterkontrol.gunswip == 3)
            {
                if (timetopass > 1.2f)
                {
                    if (karakterkontrol.yönkararý == 0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                    else if (karakterkontrol.yönkararý == 1)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                    else if (karakterkontrol.yönkararý == 2)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                    else if (karakterkontrol.yönkararý == 3)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    timetopass = 0;
                }
            }
            else if (karakterkontrol.gunswip == 4)
            {
                if (timetopass > 1.2f)
                {
                    for (int i = 0; i < 2; i++)
                    {

                        if (karakterkontrol.yönkararý == 0)
                        {
                            switch (i)
                            {
                                case 1:
                                    transform.rotation = Quaternion.Euler(0, 0, -180);
                                    break;
                            }
                        }
                        if (karakterkontrol.yönkararý == 1)
                        {
                            switch (i)
                            {
                                case 1:
                                    transform.rotation = Quaternion.Euler(0, 0, -90);
                                    break;
                            }
                        }
                        if (karakterkontrol.yönkararý == 2)
                        {
                            switch (i)
                            {
                                case 1:
                                    transform.rotation = Quaternion.Euler(0, 0, 90);
                                    break;
                            }
                        }
                        if (karakterkontrol.yönkararý == 3)
                        {
                            switch (i)
                            {
                                case 1:
                                    transform.rotation = Quaternion.Euler(0, 0, 0);
                                    break;
                            }
                        }

                    }

                    timetopass = 0;
                }
            }
        }
        else if(whosebulllet == false)
        {
            if(timetopass > 1.2f)
            {
                transform.rotation = Quaternion.FromToRotation(-Vector2.up, transform.position - player.transform.position);
                //transform.LookAt(player,Vector3.forward*-1);
                timetopass = 0;
            }
            
        }
    }
    private void FixedUpdate()
    {
        if(whosebulllet == true)
        {
            rigi.velocity = transform.up * speed1 * Time.fixedDeltaTime;
        }
        else if(whosebulllet == false)
        {
            rigi.velocity = transform.up * speed * 4 * Time.fixedDeltaTime;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "enriflemermi")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "riflemermi")
        {
            Destroy(gameObject);
        }
    }


}
