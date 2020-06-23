using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public static bool MoveC = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        MoveC = true;
    }
}
