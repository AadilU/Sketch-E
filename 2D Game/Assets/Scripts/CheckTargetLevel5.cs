using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckTargetLevel5 : MonoBehaviour
{
    Vector3 endPos;
    public Rigidbody2D r;
    public SpriteRenderer b;
    public float endPosX;
    public float endPosY;
    public Animator a;
    public Animator c;
    public Animator d;
    public Animator e;
    public Animator imageAnim;
    public bool win1 = false;
    private bool win2 = false;
    public GameObject b1;
    private CheckTargetLevel5 nextBall;

    public GameObject LevelCompleteUI;

    private bool played = false;
    public AudioSource sound;

    void Awake()
    {
        endPos = new Vector3(endPosX, endPosY, 0.0f);
        r = GetComponent<Rigidbody2D>();
        nextBall = b1.GetComponent <CheckTargetLevel5>();
    }
    void Update()
    {
        if (transform.position.x > endPosX - 0.25 && transform.position.x < endPosX + 0.25 &&
            transform.position.y < endPosY + 0.25 && transform.position.y > endPosY - 0.25)
        {
            r.bodyType = RigidbodyType2D.Static;
            WinSequence();
        }

        if (Input.GetKeyDown(KeyCode.R) && win2 == false)
        {
            Line[] o = FindObjectsOfType<Line>();
            foreach (Line j in o)
            {
                Destroy(j.gameObject);
            }
            PauseGame.paused = false;
            SceneManager.LoadScene("Level5");
        }
    }

    void WinSequence()
    {
        win1 = true;
        transform.position = endPos;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        b.sortingOrder = 2;
        if (!played)
            sound.Play();
        played = true;
        a.SetBool("Win", true);
        if (nextBall.win1)
        {
            win2 = true;
            Line[] o = FindObjectsOfType<Line>();
            foreach (Line j in o)
            {
                Destroy(j.gameObject);
            }
            c.Play("TilemapAnim");
            d.SetBool("Win", true);
            e.SetBool("Win", true);
            imageAnim.SetBool("Win", true);
            LevelCompleteUI.SetActive(true);
            if (PlayerPrefs.GetInt("LevelCompleted") < 5)
                PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted") + 1);
        }
    }

}
