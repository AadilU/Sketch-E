using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargetLevel17 : MonoBehaviour
{
    Vector3 endPos;
    public Rigidbody2D r;
    public SpriteRenderer b;
    public float endPosX;
    public float endPosY;
    public Animator a;
    public Animator tMapAnim;
    public Animator CI1, CI2, CI3, CI4, CI5, CI6, CI7, CI8;
    private Animator[] CIAnims;
    public Animator[] tracks;
    public Animator Redzone;
    public Animator TextUI;
    public Animator ImageUI;

    public GameObject LevelCompleteUI;

    private bool played = false;
    public AudioSource sound;

    void Awake()
    {
        endPos = new Vector3(endPosX, endPosY, 0.0f);
        r = GetComponent<Rigidbody2D>();
        CIAnims = new Animator[] { CI1, CI2, CI3, CI4, CI5, CI6, CI7, CI8 };
    }
    void Update()
    {
        if (transform.position.x > endPosX - 0.25 && transform.position.x < endPosX + 0.25 &&
            transform.position.y < endPosY + 0.25 && transform.position.y > endPosY - 0.25 && DisappearingPlatforms.winnable)
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
        tMapAnim.Play("TilemapAnim");

        foreach(Animator a1 in CIAnims)
        {
            if (a1 != null)
                a1.SetBool("Win", true);
        }

        foreach (Animator a2 in tracks)
        {
            if (a2 != null)
                a2.SetBool("Win", true);
        }

        Redzone.SetBool("Win", true);
        TextUI.SetBool("Win", true);
        ImageUI.SetBool("Win", true);
        DetectMouseOn.mouseOverRed = false;

        LevelCompleteUI.SetActive(true);
        if (PlayerPrefs.GetInt("LevelCompleted") < 17)
            PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted") + 1);
    }

}
