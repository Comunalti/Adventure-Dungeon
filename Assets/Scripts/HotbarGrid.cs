using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class HotbarGrid : MonoBehaviour
{
    public GameObject slotPrefab;
    public GameObject hotbar;
    public GameObject removableSlot;
    public RectTransform rectTransform;
    public bool slots3 = true;

    private void ChangeSlots()
    {

        if (slots3)
        {
            slots3 = false;
            rectTransform.sizeDelta = new Vector2 (450,150);
            Destroy(removableSlot);
        }
        else
        {
            slots3 = true;
            rectTransform.sizeDelta = new Vector2 (600,150);
            var slot = Instantiate(slotPrefab, hotbar.transform, true) as GameObject;
            removableSlot = slot;
            
        }
        // hotbar.rectTransform.sizeDelta = new Vector2(width, height);

    }
    
    
    private void OnEnable()
    {
        InputManager.Instance.MouseLeftClickEvent += ChangeSlots;
    }

    private void OnDisable()
    {
        InputManager.Instance.MouseLeftClickEvent -= ChangeSlots;
    }
    
}
