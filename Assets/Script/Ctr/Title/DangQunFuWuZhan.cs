using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangQunFuWuZhan : ICtr {

    public Animator animator;


    public override void ShowAll(float time = 1)
    {
        animator.SetBool("Show", true);
    }

    public override void HideAll(float time = 1)
    {
        animator.SetBool("Show", false);
    }
}
