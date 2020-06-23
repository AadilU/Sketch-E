using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public GameObject lineP;

    public static Line activeLine;

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !PauseGame.paused)
        {
            GameObject LineG = Instantiate(lineP);
            activeLine = LineG.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0) || PauseGame.paused)
        {
            activeLine = null;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Line[] o = FindObjectsOfType<Line>();
            foreach(Line j in o)
            {
                Destroy(j.gameObject);
            }
        }

        if (activeLine != null && !PauseGame.paused)
        {
            Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mPos, true);
        }
    }
}
