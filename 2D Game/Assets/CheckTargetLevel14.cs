using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargetLevel14 : MonoBehaviour
{
    Vector3 endPos;
    public Rigidbody2D r;
    public SpriteRenderer b;
    public float endPosX;
    public float endPosY;
    public Animator a;
    public Animator UIText;
    public Animator ImageAnim;
    public Animator tileAnim;

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
        UIText.SetBool("Win", true);
        ImageAnim.SetBool("Win", true);
        tileAnim.Play("TilemapAnim");
        LevelCompleteUI.SetActive(true);
        if (PlayerPrefs.GetInt("LevelCompleted") < 14)
            PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted") + 1);
    }

}
