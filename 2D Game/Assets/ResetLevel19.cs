﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel19 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Line[] o = FindObjectsOfType<Line>();
            foreach (Line j in o)
            {
                Destroy(j.gameObject);
            }
            MoveCamera.MoveC = false;
            MoveCamera1.MoveC1 = false;
            DetectMouseOn.mouseOverRed = false;
            PauseGame.paused = false;
            SceneManager.LoadScene("Level19");
        }
    }
}
