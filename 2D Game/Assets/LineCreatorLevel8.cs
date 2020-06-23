using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineCreatorLevel8 : MonoBehaviour
{
    public GameObject lineP;
    public TextMeshProUGUI t;

    Line activeLine;
    bool mouseBoundary = true;
    bool aLineDrawn = true;
    private int lineCount = 2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && lineCount != 0 && !PauseGame.paused)
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

        if (activeLine != null && !PauseGame.paused)
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
