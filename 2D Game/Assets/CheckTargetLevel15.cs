using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargetLevel15 : MonoBehaviour
{
    Vector3 endPos;
    Vector3 endPos1;

    public Rigidbody2D r;
    private Rigidbody2D r1;

    public SpriteRenderer b, b1;

    public bool levelComplete = false;

    public float endPosX;
    public float endPosY;
    public float endPosX1;
    public float endPosY1;

    public Animator a;
    public Animator tMapAnim;
    public Animator track1;
    public Animator track2;
    public Animator UIText;
    public Animator imageAnim;
    public Animator ColorChangerFade;
    public Animator track3, track4, track5, track6, track7, track8;

    public GameObject LevelCompleteUI;

    private bool played = false;
    public AudioSource sound;

    void Awake()
    {
        endPos = new Vector3(endPosX, endPosY, 0.0f);
        endPos1 = new Vector3(endPosX1, endPosY1, 0.0f);

        r = GetComponent<Rigidbody2D>();
        r1 = GameObject.Find("PlayerMove (1)").GetComponent<Rigidbody2D>();
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
                    Line[] o = FindObjectsOfType<Line>();
                    foreach (Line j in o)
                    {
                        Destroy(j.gameObject);
                    }
                    a.SetBool("Win", true);
                    tMapAnim.Play("TilemapAnim");
                    track1.SetBool("Win", true);
                    track2.SetBool("Win", true);
                    UIText.SetBool("Win", true);
                    imageAnim.SetBool("Win", true);
                    if(ColorChangerFade != null)
                        ColorChangerFade.SetBool("Win", true);

                    if(track3 != null)
                        track3.SetBool("Win", true);

                    if (track4 != null)
                        track4.SetBool("Win", true);

                    if (track5 != null)
                        track5.SetBool("Win", true);

                    if (track6 != null)
                        track6.SetBool("Win", true);

                    if (track7 != null)
                        track7.SetBool("Win", true);

                    if (track8 != null)
                        track8.SetBool("Win", true);
                    DetectMouseOn.mouseOverRed = false;
                    levelComplete = true;
                    LevelCompleteUI.SetActive(true);
                    if (PlayerPrefs.GetInt("LevelCompleted") < 15)
                        PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted") + 1);
                    break;
                }
        }
    }

}
