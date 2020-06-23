using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel8 : MonoBehaviour
{
    bool levelComplete;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Line[] o = FindObjectsOfType<Line>();
            foreach (Line j in o)
            {
                Destroy(j.gameObject);
            }
            PauseGame.paused = false;
            SceneManager.LoadScene("Level8");
        }
    }
}
