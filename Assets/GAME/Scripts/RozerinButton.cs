using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RozerinButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public float val;
    public Image img;
    public Sprite downSprite, upSprite;

    private void Start()
    {
        if (GetComponent<Image>()!=null)
        {
            img = GetComponent<Image>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        val = 1;
        img.sprite = downSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        val = 0;
        img.sprite = upSprite;
    }
}
