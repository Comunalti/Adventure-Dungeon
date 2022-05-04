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
    public GameObject character;
    public GameObject canvas;
    private Image images;

    private void Awake()
    {
        pivo = gameObject.transform.parent.gameObject;
    }

    private void Start()
    {
        // print(character.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.name);
        // print(canvas.transform.GetChild(0).GetChild(pivo.transform.childCount-1).gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name);
        SelectSlotImage(character.transform.GetChild(0).GetChild(0).gameObject.GetComponent<UnityEngine.UI.Image>().sprite);
    }

    public void SelectGun(int gunSelect)
    {
        // print(character.transform.GetChild(0).name);
        // print(character.transform.GetChild(0).childCount);
        for (var i = 0; i < character.transform.GetChild(0).childCount; i++)
        {
            character.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
        }
        character.transform.GetChild(0).GetChild(gunSelect-1).gameObject.SetActive(true);
    }

    private void SelectThisGun()
    {
        for (var i = 0; i < pivo.transform.childCount; i++)
        {
            pivo.transform.GetChild(i).gameObject.SetActive(false);
        }
        gameObject.SetActive(true);
    }
    
    private void SelectSlotImage(Sprite image)
    {
        // print(canvas.transform.GetChild(0).GetChild(pivo.transform.childCount-1).gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name);
        canvas.transform.GetChild(0).GetChild(pivo.transform.childCount-1).gameObject.GetComponent<UnityEngine.UI.Image>().sprite = image;
    }
}
