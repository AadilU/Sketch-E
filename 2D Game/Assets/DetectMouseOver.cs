using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouseOver : MonoBehaviour
{
    public static bool MouseOverZone = false;
    void OnMouseOver()
    {
        print("collided");
        MouseOverZone = true;
    }
}
