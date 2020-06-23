using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] m;
    private int t;

    private void Update()
    {
        for (int i = 0; i < m.Length; i++)
        {
            if (i == t)
            {
                m[i].SetActive(true);
            }
            else
            {
                m[i].SetActive(false);
            }
        }
        if (t == 0)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                t++;
            }
        }
        else
            if (t == 1)
            {
                if (Input.GetMouseButton(0))
                {
                    t++;
                }
            }
    }
}
