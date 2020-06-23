using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatforms : MonoBehaviour
{
    private GameObject platform;
    public GameObject goal;

    public Animator dissapearPlatform;

    public Transform platParent;

    public static bool winnable = false;

    public int WinCondition;

    private void Start()
    {
        platform = transform.gameObject;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dissapearPlatform.Play("PlatformIdle");
        Destroy(platform, 0.8f);

        CheckForWinnable();
    }

    private void CheckForWinnable()
    {
        int i = 0;
        foreach (Transform tracks in platParent)
        {
            i++;
        }
        if (i <= WinCondition)
        {
            winnable = true;
            goal.SetActive(true);
        }
    }
}
