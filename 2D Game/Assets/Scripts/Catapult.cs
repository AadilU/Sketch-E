using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    private bool ballOn = false;
    public float spinSpeed;
    Vector3 m_EulerAngleVelocity;
    Rigidbody2D r;

    private void Start()
    {
        r = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        r.angularVelocity = spinSpeed;
    }

    private void FixedUpdate()
    {
        if (transform.rotation == Quaternion.Euler(0, 0, 180))
        {
            r.angularVelocity = 0;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
