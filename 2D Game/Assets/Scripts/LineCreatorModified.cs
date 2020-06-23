using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreatorModified : MonoBehaviour
{
    public GameObject lineP;

    Line activeLine;
    bool mouseBoundary = true;
    bool aLineDrawn = true;

    void Update()
    {
        if (DetectMouseOn.mouseOverRed)
        {
            activeLine = null;
        }

        if (Input.GetMouseButtonDown(0) && mouseBoundary && !PauseGame.paused && !DetectMouseOn.mouseOverRed)
        {
            GameObject LineG = Instantiate(lineP);
            activeLine = LineG.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0) || PauseGame.paused)
        {
            activeLine = null;
        }

        if (Input.GetKeyDown(KeyCode.R) && !PauseGame.paused)
        {
            Line[] o = FindObjectsOfType<Line>();
            foreach (Line j in o)
            {
                Destroy(j.gameObject);
            }
        }

        if (activeLine != null && mouseBoundary && !PauseGame.paused && !DetectMouseOn.mouseOverRed)
        {
            Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mPos, true);
        }
    }
}
