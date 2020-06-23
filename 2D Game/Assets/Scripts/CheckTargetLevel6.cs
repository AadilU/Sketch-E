using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargetLevel6 : MonoBehaviour
{
    Vector3 endPos;
    Vector3 endPos1;
    Vector3 endPos2;
    Vector3 endPos3;

    public Rigidbody2D r;
    private Rigidbody2D r1, r2, r3;

    public SpriteRenderer b, b1, b2, b3;

    public bool levelComplete = false;

    public float endPosX;
    public float endPosY;
    public float endPosX1;
    public float endPosY1;
    public float endPosX2;
    public float endPosY2;
    public float endPosX3;
    public float endPosY3;

    public Animator a;
    public Animator d;
    public Animator c;
    public Animator e;

    public GameObject LevelCompleteUI;

    bool played = false;
    public AudioSource sound;

    void Awake()
    {
        endPos = new Vector3(endPosX, endPosY, 0.0f);
        endPos1 = new Vector3(endPosX1, endPosY1, 0.0f);
        endPos2 = new Vector3(endPosX2, endPosY2, 0.0f);
        endPos3 = new Vector3(endPosX3, endPosY3, 0.0f);

        r = GetComponent<Rigidbody2D>();
        r1 = GameObject.Find("PlayerMove (1)").GetComponent<Rigidbody2D>();
        r2 = GameObject.Find("PlayerMove (2)").GetComponent<Rigidbody2D>();
        r3 = GameObject.Find("PlayerMove (3)").GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (transform.position.x > endPosX - 0.25 && transform.position.x < endPosX + 0.25 &&
            transform.position.y < endPosY + 0.25 && transform.position.y > endPosY - 0.25)
        {

            WinSequence(endPos, b);
        }
        else
            if (transform.position.x > endPosX1 - 0.25 && transform.position.x < endPosX1 + 0.25 &&
            transform.position.y < endPosY1 + 0.25 && transform.position.y > endPosY1 - 0.25)
            {
                WinSequence(endPos1, b1);
            }
            else
                if (transform.position.x > endPosX2 - 0.25 && transform.position.x < endPosX2 + 0.25 &&
                transform.position.y < endPosY2 + 0.25 && transform.position.y > endPosY2 - 0.25)
                {
                    WinSequence(endPos2, b2);
                }
                else
                    if (transform.position.x > endPosX3 - 0.25 && transform.position.x < endPosX3 + 0.25 &&
                        transform.position.y < endPosY3 + 0.25 && transform.position.y > endPosY3 - 0.25)
                     {
                         WinSequence(endPos3, b3);
                     }



    }

    void WinSequence(Vector3 endP, SpriteRenderer bq)
    {
        r.bodyType = RigidbodyType2D.Static;
        transform.position = endP;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        bq.sortingOrder = 2;
        a.SetBool("Win", true);
        if (!played)
            sound.Play();
        played = true;
        switch (gameObject.name)
        {
            case ("PlayerMove"):
                {
                    r1.bodyType = RigidbodyType2D.Dynamic;
                    break;
                }
            case ("PlayerMove (1)"):
                {
                    r2.bodyType = RigidbodyType2D.Dynamic;
                    break;
                }
            case ("PlayerMove (2)"):
                {
                    r3.bodyType = RigidbodyType2D.Dynamic;
                    break;
                }
            case ("PlayerMove (3)"):
                {
                    Line[] o = FindObjectsOfType<Line>();
                    foreach (Line j in o)
                    {
                        Destroy(j.gameObject);
                    }
                    c.Play("TilemapAnim");
                    d.SetBool("Win", true);
                    e.SetBool("Win", true);
                    levelComplete = true;
                    LevelCompleteUI.SetActive(true);
                    if (PlayerPrefs.GetInt("LevelCompleted") < 6)
                        PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted") + 1);
                    break;
                }
        }
    }

}
