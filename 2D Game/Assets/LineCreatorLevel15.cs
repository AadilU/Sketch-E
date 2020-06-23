using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LineCreatorLevel15 : MonoBehaviour
{
    public GameObject lineP;
    public GameObject lineB;

    public TextMeshProUGUI t;
    public Image image;

    public Sprite bouncyImage;
    public Sprite normalImage;

    private bool bLinechosen = false;

    public int lineCount;

    public static Line activeLine;
    bool mouseBoundary = true;
    bool aLineDrawn = true;

    void Update()
    {
        Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (DetectMouseOn.mouseOverRed)
        {
            activeLine = null;
        }

        if (Input.GetMouseButtonDown(1) && !PauseGame.paused && !DetectMouseOn.mouseOverRed)
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

        if (Input.GetMouseButtonDown(0) && mouseBoundary && lineCount != 0 && !PauseGame.paused && !DetectMouseOn.mouseOverRed)
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

        if (activeLine != null && mouseBoundary && !PauseGame.paused && !DetectMouseOn.mouseOverRed)
        {
            activeLine.lvl12UpdateLine(mPos, true);
        }
    }

    private void ChangeLineCount()
    {
        t.text = lineCount.ToString();
    }
}
