using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOnPlayer : MonoBehaviour
{
    public Animator a;

    void OnTriggerEnter2D(Collider2D s)
    {
        a.Play("Text3FadeIn");
    }
}
