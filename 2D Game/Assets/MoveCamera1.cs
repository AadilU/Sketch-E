using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera1 : MonoBehaviour
{
    public static bool MoveC1 = false;
    public GameObject ColorChanger;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(ColorChanger == null)
            MoveC1 = true;
    }
}
