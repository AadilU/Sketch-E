using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision e)
    {
        if (e.gameObject.name == "PlayerMove")
        {
            Destroy(e.gameObject);
        }
    }
}
