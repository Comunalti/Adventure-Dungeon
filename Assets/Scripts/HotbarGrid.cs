using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class HotbarGrid : MonoBehaviour
{
    public GameObject slotPrefab;
    public GameObject dropPrefab;
    public GameObject hotbar;
    public GameObject removableSlot;
    public RectTransform rectTransform;
    public GameObject pivo;
    public bool has3Slots = true;

    private void ChangeSlots()
    {

        if (has3Slots)
        {
            has3Slots = false;
            rectTransform.sizeDelta = new Vector2 (600,150);
            var slot = Instantiate(slotPrefab, hotbar.transform, true) as GameObject;
            removableSlot = slot;
        }
        else
        {
            has3Slots = true;
            if (pivo.transform.childCount == 4)
            {
                Destroy(pivo.transform.GetChild(3).gameObject);
                var drop = Instantiate(dropPrefab,new Vector3(
                    pivo.transform.parent.gameObject.GetComponent<Transform>().position.x,
                    pivo.transform.parent.gameObject.GetComponent<Transform>().position.y),Quaternion.identity);
            }
                
            rectTransform.sizeDelta = new Vector2 (450,150);
            Destroy(removableSlot);
            
        }
        // hotbar.rectTransform.sizeDelta = new Vector2(width, height);

    }
    
    
    private void OnEnable()
    {
        InputManager.Instance.DashEvent += ChangeSlots;
    }

    private void OnDisable()
    {
        InputManager.Instance.DashEvent -= ChangeSlots;
    }
    
}
