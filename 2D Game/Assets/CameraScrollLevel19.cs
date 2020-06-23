using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrollLevel19 : MonoBehaviour
{
    public GameObject b;
    private bool b1 = false;
    // Update is called once per frame
    void Update()
    {
        if (MoveCamera.MoveC && !b1)
        {
            if(transform.position.y <= 7.62)
                transform.Translate(new Vector3(0, 4.0f * Time.deltaTime, 0));
        }

        if (MoveCamera1.MoveC1)
        {
            b1 = true;
            if(transform.position.y >= 0)
                transform.Translate(new Vector3(0, -4.0f * Time.deltaTime, 0));
        }
    }
}
