using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineCreatorLevel7 : MonoBehaviour
{
    public GameObject lineP;
    public TextMeshProUGUI t;

    Line activeLine;
    bool mouseBoundary = true;
    bool aLineDrawn = true;
    private int lineCount = 2;

    void Update()
    {
        Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mPos.x >= -7.5 && mPos.x <= 10)
        {
            mouseBoundary = false;
            activeLine = null;
            aLineDrawn = false;
        }
        else
        {
            if (aLineDrawn == false)
            {
                aLineDrawn = true;
                if (Input.GetMouseButton(0) && lineCount != 0 && !PauseGame.paused)
                {
                    GameObject LineG = Instantiate(lineP);
                    activeLine = LineG.GetComponent<Line>();
                    lineCount--;
                    ChangeLineCount();
                }
            }
            mouseBoundary = true;
        }

        if (Input.GetMouseButtonDown(0) && mouseBoundary && lineCount != 0 && !PauseGame.paused)
        {
            GameObject LineG = Instantiate(lineP);
            activeLine = LineG.GetComponent<Line>();
            lineCount--;
            ChangeLineCount();
        }

        if (Input.GetMouseButtonUp(0) || PauseGame.paused)
        {
            activeLine = null;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Line[] o = FindObjectsOfType<Line>();
            foreach (Line j in o)
            {
                Destroy(j.gameObject);
            }
        }

        if (activeLine != null && mouseBoundary && !PauseGame.paused)
        {
            Vector2 mPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mPos1, true);
        }
    }

    private void ChangeLineCount()
    {
        t.text = lineCount.ToString();
    }
}
