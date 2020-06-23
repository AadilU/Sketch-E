using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouseOn : MonoBehaviour
{
    public static bool mouseOverRed = false;
    void OnMouseOver()
    {
        mouseOverRed = true;
    }

    void OnMouseExit()
    {
        mouseOverRed = false;
    }
}
