using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMoveLevel6 : MonoBehaviour
{
    public float speed;
    Vector3 startPos;
    public Rigidbody2D r;
    private bool collided = false;
    private bool firstAnimPlayed = false;
    float h;

    void Start()
    {
        startPos = transform.position;
        r = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))
        {
            h = -1;
        }
        else
            if (Input.GetKeyDown(KeyCode.D))
        {
            h = 1;
        }

        Vector2 rm = new Vector2(h, 0);
        r.AddForce(rm * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ResetGame")
        {
            Line[] o = FindObjectsOfType<Line>();
            foreach (Line j in o)
            {
                Destroy(j.gameObject);
            }
            SceneManager.LoadScene("Level5");
        }
    }
}
