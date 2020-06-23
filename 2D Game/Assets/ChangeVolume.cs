using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolume : MonoBehaviour
{
    public void changeVol(float val)
    {
        FindObjectOfType<AudioManager>().updateVol(val);
    }

}
