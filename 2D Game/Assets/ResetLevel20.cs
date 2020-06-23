﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel20 : MonoBehaviour
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
            DetectMouseOn.mouseOverRed = false;
            DisappearingPlatforms.winnable = false;
            PauseGame.paused = false;
            SceneManager.LoadScene("Level20");
        }
    }
}
