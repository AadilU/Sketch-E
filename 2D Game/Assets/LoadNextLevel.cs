using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public Animator t;
    public void clicked1()
    {
        StartCoroutine(LoadL(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadL(int lIndex)
    {
        t.SetTrigger("clicked");

        yield return new WaitForSeconds(0.8f);

        SceneManager.LoadScene(lIndex);
    }

}
