using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class NumberSlotChanger : MonoBehaviour
{
    public int slotNumber;
    public GameObject slotPrefab;
    
    public event Action SlotNumberChangedEvent;
    
    public void SetSlotNumber(int slotNumber)
    {
        this.slotNumber = slotNumber;
        SlotNumberChangedEvent?.Invoke();
    }

    private void ChangeSlotNumber()
    {
        if (slotNumber == gameObject.transform.childCount) return;
        if (slotNumber > gameObject.transform.childCount)
        {
            var slotsToCreate = slotNumber - gameObject.transform.childCount;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (slotNumber*150,150);
            for (int i = 0; i < slotsToCreate; i++)
            {
                var slot = Instantiate(slotPrefab, gameObject.transform, true) as GameObject;
            }
        }
        else
        {
            var slotsToDelete = gameObject.transform.childCount - slotNumber;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (slotNumber*150,150);
            for (int i = 0; i < slotsToDelete; i++)
            {
                Destroy(gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject);
            }
        }
    }
    private void OnEnable()
    {
        SlotNumberChangedEvent += ChangeSlotNumber;
    }

    private void OnDisable()
    {
        SlotNumberChangedEvent -= ChangeSlotNumber;
    }
}
