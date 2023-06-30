using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gamer")
        {
            FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        }
    }
}
