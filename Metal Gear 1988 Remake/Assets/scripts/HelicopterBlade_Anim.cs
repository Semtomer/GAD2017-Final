using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterBlade_Anim : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, speed) * Time.deltaTime);
    }
}
