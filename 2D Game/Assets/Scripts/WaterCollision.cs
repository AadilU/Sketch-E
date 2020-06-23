using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    private Vector3 startPos;
    void Awake()
    {
        startPos = transform.position;   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Water")
        {
            transform.position = startPos;
        }
    }
}
