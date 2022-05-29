using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class MousePointerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private static readonly int MousePressed = Animator.StringToHash("MousePressed");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        InputManager.Instance.MouseRightClickEvent += MouseClicked;
        InputManager.Instance.MouseRightClickEndedEvent += MouseEndedClick;
    }

    private void MouseEndedClick()
    {
        _animator.SetBool(MousePressed,false);
    }

    private void MouseClicked()
    {
        _animator.SetBool(MousePressed,true);
    }

    private void OnDisable()
    {
        InputManager.Instance.MouseRightClickEvent -= MouseClicked;
        InputManager.Instance.MouseRightClickEndedEvent -= MouseEndedClick;
    }
}
