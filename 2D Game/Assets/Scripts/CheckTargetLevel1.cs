using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargetLevel1 : MonoBehaviour
{
    Vector3 endPos;

    public Rigidbody2D r;
    public SpriteRenderer b;
    public Animator a;
    public Animator d;
    public Animator c;

    public GameObject LevelCompleteUI;

    public AudioSource sound;
    private bool played = false;


    void Awake()
    {
        endPos = new Vector3(6.52f, -3.64f, 0.0f);
        r = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (transform.position.x > 6.28 && transform.position.x < 6.8 &&
            transform.position.y < -3.27 && transform.position.y > -3.77)
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
        c.SetBool("Win", true);
        d.SetBool("Win", true);
        LevelCompleteUI.SetActive(true);
        if(PlayerPrefs.GetInt("LevelCompleted") < 1)
            PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted") + 1);
    }

}
