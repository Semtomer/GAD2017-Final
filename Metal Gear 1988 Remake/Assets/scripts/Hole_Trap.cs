using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole_Trap : MonoBehaviour
{
    Animator hole_Trap;
    public static FMOD.Studio.EventInstance holeTrapSound;

    void Start()
    {
        holeTrapSound = FMODUnity.RuntimeManager.CreateInstance("event:/holeTrapOpening");
        hole_Trap = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gamer")
        {
            holeTrapSound.start();
            hole_Trap.SetBool("IsComing", true);
        }
    }
}
