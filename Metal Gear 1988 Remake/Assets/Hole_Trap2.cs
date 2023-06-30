using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole_Trap2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gamer")
        {
            karakterkontrol.health -= 200;
        }
    }
}
