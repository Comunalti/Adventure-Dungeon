using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class GunFunctions : MonoBehaviour
{
    public GameObject pivo;
    public GameObject canvas;
    private Image images;

    private void Awake()
    {
        pivo = gameObject.transform.parent.gameObject;
        canvas = GameObject.Find("Canvas1");
    }

    public void SelectGun(int gunSelect)
    {
        // print(character.transform.GetChild(0).name);
        // print(character.transform.GetChild(0).childCount);
        for (var i = 0; i < pivo.transform.childCount; i++)
        {
            pivo.transform.GetChild(i).gameObject.SetActive(false);
        }
        pivo.transform.GetChild(gunSelect-1).gameObject.SetActive(true);
    }

    public void SelectThisGun()
    {
        for (var i = 0; i < pivo.transform.childCount; i++)
        {
            pivo.transform.GetChild(i).gameObject.SetActive(false);
        }
        gameObject.SetActive(true);
    }
    
    public void SelectSlotImage(Sprite image)
    {
        // print(canvas.transform.GetChild(0).GetChild(pivo.transform.childCount-1).GetComponent<UnityEngine.UI.Image>().sprite.name);
        // print(image.name);
        canvas.transform.GetChild(0).GetChild(pivo.transform.childCount-1).GetComponent<UnityEngine.UI.Image>().sprite = image;
        
    }
}
