using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargetLevel9 : MonoBehaviour
{
    Vector3 endPos;
    public Rigidbody2D r;
    public SpriteRenderer b;
    public float endPosX;
    public float endPosY;
    public Animator a;
    public Animator tileAnim;
    public Animator textAnim;
    public Animator imageAnim;
    public Animator imageAnim1;
    public bool levelComplete = false;

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
        if (transform.position.x > endPosX - 0.25 && transform.position.x < endPosX + 0.25 &&
            transform.position.y < endPosY + 0.25 && transform.position.y > endPosY - 0.25)
        {
            r.bodyType = RigidbodyType2D.Static;
            WinSequence();
        }
    }

    void WinSequence()
    {
        levelComplete = true;
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
        tileAnim.Play("TilemapAnim");
        textAnim.SetBool("Win", true);
        imageAnim.SetBool("Win", true);
        imageAnim1.SetBool("Win", true);
        LevelCompleteUI.SetActive(true);
        if (PlayerPrefs.GetInt("LevelCompleted") < 9)
            PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted") + 1);
    }

}
