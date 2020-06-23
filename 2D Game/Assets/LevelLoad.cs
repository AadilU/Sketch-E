using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{

    public Animator t, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19;
    public GameObject[] b;

    public static bool colorchange = false;

    private void OnEnable()
    {
        colorchange = false;
    }

    public void clicked(int levelNum)
    {
        switch (levelNum)
        {
            case 1:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 0)
                    {
                        LoadLevel(levelNum, t);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 2:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 1)
                    {
                        LoadLevel(levelNum, t1);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 3:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 2)
                    {
                        LoadLevel(levelNum, t2);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 4:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 3)
                    {
                        LoadLevel(levelNum, t3);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 5:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 4)
                    {
                        LoadLevel(levelNum, t4);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 6:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 5)
                    {
                        LoadLevel(levelNum, t5);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 7:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 6)
                    {
                        LoadLevel(levelNum, t6);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 8:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 7)
                    {
                        LoadLevel(levelNum, t7);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 9:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 8)
                    {
                        LoadLevel(levelNum, t8);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 10:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 9)
                    {
                        LoadLevel(levelNum, t9);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 11:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 10)
                    {
                        LoadLevel(levelNum, t10);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 12:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 11)
                    {
                        LoadLevel(levelNum, t11);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 13:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 12)
                    {
                        LoadLevel(levelNum, t12);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 14:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 13)
                    {
                        LoadLevel(levelNum, t13);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 15:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 14)
                    {
                        LoadLevel(levelNum, t14);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 16:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 15)
                    {
                        LoadLevel(levelNum, t15);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 17:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 16)
                    {
                        LoadLevel(levelNum, t16);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 18:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 17)
                    {
                        LoadLevel(levelNum, t17);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 19:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 18)
                    {
                        LoadLevel(levelNum, t18);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }
            case 20:
                {
                    if (PlayerPrefs.GetInt("LevelCompleted") >= 19)
                    {
                        LoadLevel(levelNum, t19);
                        b[levelNum - 1].GetComponent<Canvas>().overrideSorting = true;
                        colorchange = true;
                    }
                    break;
                }

        }
    }

    public void LoadLevel(int level, Animator ballAnim1)
    {
        StartCoroutine(LoadLevel1(level, ballAnim1));
    }

    IEnumerator LoadLevel1(int Level, Animator ballAnim)
    {
        ballAnim.SetTrigger("Clicked");

        yield return new WaitForSeconds(0.8f);

        DetectMouseOn.mouseOverRed = false;
        SceneManager.LoadScene(Level);
    }
}
