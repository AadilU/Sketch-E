using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouseOver = false;

    [SerializeField]
    private GameObject background;

    void Update()
    {
        if (!LevelLoad.colorchange)
        {
            if (mouseOver)
                background.SetActive(true);
            else
                background.SetActive(false);
        }
    }
    public void OnPointerEnter(PointerEventData data)
    {
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData data)
    {
        mouseOver = false;
    }
}
