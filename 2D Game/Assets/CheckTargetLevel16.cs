using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargetLevel16 : MonoBehaviour
{
    Vector3 endPos;
    public Rigidbody2D r;
    public SpriteRenderer b;
    public float endPosX;
    public float endPosY;
    public Animator a;
    public Animator UIText;
    public Animator ImageAnim;
    public Animator changeTrack1, changeTrack2;
    public Animator catapult;
    public Animator tMapAnim;
    public Animator changeIcon1, changeIcon2;

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
        UIText.SetBool("Win", true);
        ImageAnim.SetBool("Win", true);
        tMapAnim.Play("TilemapAnim");

        if(changeTrack1 != null)
            changeTrack1.SetBool("Win", true);

        if(changeTrack2 != null)
            changeTrack2.SetBool("Win", true);

        if(changeIcon1 != null)
            changeIcon1.SetBool("Win", true);

        if(changeIcon2 != null)
            changeIcon2.SetBool("Win", true);

        catapult.SetBool("Win", true);
        LevelCompleteUI.SetActive(true);
        if (PlayerPrefs.GetInt("LevelCompleted") < 16)
            PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted") + 1);
    }

}
