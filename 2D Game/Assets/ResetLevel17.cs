using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel17 : MonoBehaviour
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
            DisappearingPlatforms.winnable = false;
            PauseGame.paused = false;
            DetectMouseOn.mouseOverRed = false;
            SceneManager.LoadScene("Level17");
        }
    }
}
