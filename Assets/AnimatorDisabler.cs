using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorDisabler : MonoBehaviour
{
    public Animator animator;
    
    public void Disable()
    {
        animator.enabled = false;
    }

}
