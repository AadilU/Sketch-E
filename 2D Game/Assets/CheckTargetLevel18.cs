using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargetLevel18 : MonoBehaviour
{
    Vector3 endPos;
    public Rigidbody2D r;
    public SpriteRenderer b;
    public float endPosX;
    public float endPosY;
    public Animator a;
    public Animator tMapAnim;
    public Animator catapult1, catapult2;
    public Animator UIText;
    public Animator UIImage;

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
        
        Destroy(b);
        if (!played)
            sound.Play();
        played = true;
        a.SetBool("Win", true);
        tMapAnim.Play("TilemapAnim");
        catapult1.SetBool("Win", true);
        catapult2.SetBool("Win", true);
        UIText.SetBool("Win", true);
        UIImage.SetBool("Win", true);
        MoveCamera.MoveC = false;
        MoveCamera1.MoveC1 = false;

        LevelCompleteUI.SetActive(true);
        if (PlayerPrefs.GetInt("LevelCompleted") < 18)
            PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted") + 1);
    }

}
