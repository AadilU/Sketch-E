using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseUI;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        GameObject.Find("Slider").GetComponent<Slider>().value = FindObjectOfType<AudioManager>().getVol();
        GameObject.Find("Toggle").GetComponent<Toggle>().isOn = !AudioManager.muted;
    }

    public void loadLevelSelect()
    {
        Time.timeScale = 1f;
        DetectMouseOn.mouseOverRed = false;
        PauseGame.paused = false;
        SceneManager.LoadScene("LevelSelect");
    }
}
