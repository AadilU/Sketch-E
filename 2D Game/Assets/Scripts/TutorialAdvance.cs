using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAdvance : MonoBehaviour
{
    public Animator text1;
    public Animator text2;
    private bool collided = false;
    private bool firstAnimPlayed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collided == false)
            text1.Play("Text1FadeIn");
        collided = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            text2.SetBool("Move1", true);
        }

        if (Input.GetAxis("Horizontal") != 0 && collided == true && firstAnimPlayed == false)
        {
            text1.SetBool("Move", true);
            text2.Play("Text2FadeIn");
            firstAnimPlayed = true;
        }
    }
}
