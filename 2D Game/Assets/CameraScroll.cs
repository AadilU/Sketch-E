using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(MoveCamera.MoveC && transform.position.y >= -6.61)
            transform.Translate(new Vector3(0, -4.0f * Time.deltaTime, 0));
    }
}
