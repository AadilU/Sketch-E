using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LineCreatorLevel9 : MonoBehaviour
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
    void Update()
    {
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

        if (Input.GetMouseButtonDown(0) && lineCount != 0 && !PauseGame.paused)
        {   if (!bLinechosen)
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

        if (Input.GetKeyDown(KeyCode.R) && !PauseGame.paused)
        {
            Line[] o = FindObjectsOfType<Line>();
            foreach (Line j in o)
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

    private void ChangeLineCount()
    {
        t.text = lineCount.ToString();
    }
}
