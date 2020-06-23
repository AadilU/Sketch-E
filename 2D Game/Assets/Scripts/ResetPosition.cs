using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResetPosition: MonoBehaviour
{
    public Vector3 startPos;

    void Awake()
    {
        startPos = transform.position;
        print(startPos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Water")
        {
            print("Collided");
            transform.position = startPos;
        }
    }
}