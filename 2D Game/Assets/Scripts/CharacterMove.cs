using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed;
    Vector3 startPos;
    public Rigidbody2D r;
    private bool collided = false;
    private bool firstAnimPlayed = false;
    float h;

    [SerializeField]
    private AudioSource regularBounce;

    [SerializeField]
    private AudioSource bouncyBounce;

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
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPos;
            h = 0;
            r.velocity = Vector3.zero;
            r.bodyType = RigidbodyType2D.Static;
            r.bodyType = RigidbodyType2D.Dynamic;
        }
        
            Vector2 rm = new Vector2(h, 0);
            r.AddForce(rm * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ResetGame")
        {
            transform.position = startPos;
            h = 0;
            r.velocity = Vector3.zero;
            r.bodyType = RigidbodyType2D.Static;
            r.bodyType = RigidbodyType2D.Dynamic;
            Line[] o = FindObjectsOfType<Line>();
            foreach (Line j in o)
            {
                Destroy(j.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("StickyLine"))
        {
            bouncyBounce.volume = Mathf.Clamp01(collision.relativeVelocity.magnitude / 40);
            bouncyBounce.Play();
        }
        else
        {
            regularBounce.volume = Mathf.Clamp01(collision.relativeVelocity.magnitude / 40);
            if(!regularBounce.isPlaying)
                regularBounce.Play();
        }
    }
}
