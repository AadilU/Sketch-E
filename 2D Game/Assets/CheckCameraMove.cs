using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCameraMove : MonoBehaviour
{
    public Camera c;
    public Camera Mainc;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerMove")
        {
            LineCreatorLevel20.activeLine = null;
            Mainc.enabled = false;
            c.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerMove")
        {
            LineCreatorLevel20.activeLine = null;
            Mainc.enabled = true;
            c.enabled = false;

        }
    }
}
