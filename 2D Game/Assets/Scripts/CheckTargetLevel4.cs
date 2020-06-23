using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargetLevel4 : MonoBehaviour
{
    Vector3 endPos;
    public Rigidbody2D r;
    public SpriteRenderer b;
    public float endPosX;
    public float endPosY;
    public Animator a;
    public Animator d;
    public Animator c;
    public Animator t1, t2, t3, t4;
    public Animator TrackAnim;

    public GameObject LevelCompleteUI;

    private bool played = false;
    public AudioSource sound;

    void Awake()
    {
        endPos = new Vector3(endPosX, endPosY, 0.0f);
        r = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (transform.position.x > endPosX - 0.2 && transform.position.x < endPosX + 0.2 &&
            transform.position.y < endPosY + 0.2 && transform.position.y > endPosY - 0.2)
        {
            r.bodyType = RigidbodyType2D.Static;
            WinSequence();
        }
    }

    void WinSequence()
    {
        transform.position = endPos;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        Line[] o = FindObjectsOfType<Line>();
        foreach (Line j in o)
        {
            Destroy(j.gameObject);
        }
        b.sortingOrder = 2;
        if (!played)
            sound.Play();
        played = true;
        a.SetBool("Win", true);
        c.Play("TilemapAnim");
        d.SetBool("Win", true);
        t1.SetBool("Win", true);
        t2.SetBool("Win", true);
        t3.SetBool("Win", true);
        t4.SetBool("Win", true);
        TrackAnim.SetBool("Win", true);
        LevelCompleteUI.SetActive(true);
        if (PlayerPrefs.GetInt("LevelCompleted") < 4)
            PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted") + 1);
    }

}
