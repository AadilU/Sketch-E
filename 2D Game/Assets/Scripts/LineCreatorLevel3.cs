using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreatorLevel3 : MonoBehaviour
{
    public GameObject lineP;

    Line activeLine;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject LineG = Instantiate(lineP);
            activeLine = LineG.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
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

        if (activeLine != null)
        {
            Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mPos.x > -1 && mPos.x < 2)
            {
                return;
            }
            else
                activeLine.UpdateLine(mPos, true);

        }
    }
}
