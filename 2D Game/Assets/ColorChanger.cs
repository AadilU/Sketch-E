using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Transform trackType;
    public ParticleSystem r;

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        FindObjectOfType<AudioManager>().Play("ColorChangeSound");

        ParticleSystem.MainModule m = r.main;
        m.startColor = transform.GetComponent<SpriteRenderer>().color;

        Destroy(transform.gameObject);
        r.Play();
        Destroy(r, 0.45f);
        
        foreach(Transform track in trackType)
        {
            Destroy(track.gameObject);
        }

    }
}
