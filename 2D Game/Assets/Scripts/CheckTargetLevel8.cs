using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargetLevel8 : MonoBehaviour
{
    Vector3 endPos;
    Vector3 endPos1;

    public Rigidbody2D r;

    public GameObject newBall;

    public SpriteRenderer b, b1;

    public bool win1 = false;
    private bool win2 = false;

    public float endPosX;
    public float endPosY;
    public float endPosX1;
    public float endPosY1;

    public Animator a;
    public Animator c;
    public Animator trackAnim2;
    public Animator trackAnim3;
    public Animator trackAnim1;
    public Animator imageAnim;
    public Animator textAnim;

    private CheckTargetLevel8 ball2;

    public GameObject LevelCompleteUI;

    private bool played = false;
    public AudioSource sound;

    void Awake()
    {
        endPos = new Vector3(endPosX, endPosY, 0.0f);
        endPos1 = new Vector3(endPosX1, endPosY1, 0.0f);

        r = GetComponent<Rigidbody2D>();

        ball2 = newBall.GetComponent<CheckTargetLevel8>();
    }
    void Update()
    {
        if (transform.position.x > endPosX - 0.25 && transform.position.x < endPosX + 0.25 &&
            transform.position.y < endPosY + 0.25 && transform.position.y > endPosY - 0.25)
        {
            r.bodyType = RigidbodyType2D.Static;
            WinSequence(endPos, b);
        }
        else
            if (transform.position.x > endPosX1 - 0.25 && transform.position.x < endPosX1 + 0.25 &&
            transform.position.y < endPosY1 + 0.25 && transform.position.y > endPosY1 - 0.25)
            {
                r.bodyType = RigidbodyType2D.Static;
                WinSequence(endPos1, b1);
            }
    }

    void WinSequence(Vector3 endPos3, SpriteRenderer b3)
    {
        win1 = true;
        transform.position = endPos3;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        b3.sortingOrder = 2;
        if (!played)
            sound.Play();
        played = true;
        a.SetBool("Win", true);
        if (ball2.win1)
        {
            win2 = true;
            Line[] o = FindObjectsOfType<Line>();
            foreach (Line j in o)
            {
                Destroy(j.gameObject);
            }
            c.Play("TilemapAnim");
            trackAnim1.SetBool("Win", true);
            trackAnim2.SetBool("Win", true);
            trackAnim3.SetBool("Win", true);
            imageAnim.SetBool("Win", true);
            textAnim.SetBool("Win", true);
            LevelCompleteUI.SetActive(true);
            if (PlayerPrefs.GetInt("LevelCompleted") < 8)
                PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted") + 1);
        }
    }

}
