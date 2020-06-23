using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LineCreatorLevel10 : MonoBehaviour
{
    public GameObject lineP;
    public GameObject lineB;

    public TextMeshProUGUI t;
    public Image image;

    public Sprite bouncyImage;
    public Sprite normalImage;

    private bool bLinechosen = false;

    private int lineCount = 6;

    public static Line activeLine;
    bool mouseBoundary = true;
    bool aLineDrawn = true;

    void Update()
    {
        Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mPos.x >= -2.8 && mPos.x <= -0.9 && mPos.y >= 2.0 && mPos.y <= 4.8)
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
                    if (!bLinechosen)
                    {
                        GameObject LineG = Instantiate(lineP);
                        activeLine = LineG.GetComponent<Line>();
                        lineCount--;
                        ChangeLineCount();
                    }
                    else
                    {
                        GameObject LineG = Instantiate(lineB);
                        activeLine = LineG.GetComponent<Line>();
                        lineCount--;
                        ChangeLineCount();
                    }
                }
            }
            mouseBoundary = true;
        }

        if (Input.GetMouseButtonDown(1) && !PauseGame.paused)
            bLinechosen = !bLinechosen;

        if (bLinechosen)
        {
            t.color = new Color32(246, 36, 89, 255);
            image.sprite = bouncyImage;
        }
        else
        {
            t.color = new Color32(0, 0, 0, 255);
            image.sprite = normalImage;
        }

        if (Input.GetMouseButtonDown(0) && mouseBoundary && lineCount != 0 && !PauseGame.paused)
        {
            if (!bLinechosen)
            {
                GameObject LineG = Instantiate(lineP);
                activeLine = LineG.GetComponent<Line>();
                lineCount--;
                ChangeLineCount();
            }
            else
            {
                GameObject LineG = Instantiate(lineB);
                activeLine = LineG.GetComponent<Line>();
                lineCount--;
                ChangeLineCount();
            }

        }

        if (Input.GetMouseButtonUp(0) || PauseGame.paused)
        {
            activeLine = null;
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
