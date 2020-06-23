using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel7 : MonoBehaviour
{
    public GameObject g;
    bool levelComplete;
    void Update()
    {
        levelComplete = g.GetComponent<CheckTargetLevel7>().levelComplete;
        if (Input.GetKeyDown(KeyCode.R) && !levelComplete)
        {
            Line[] o = FindObjectsOfType<Line>();
            foreach (Line j in o)
            {
                Destroy(j.gameObject);
            }
            PauseGame.paused = false;
            SceneManager.LoadScene("Level7");
        }
    }
}
