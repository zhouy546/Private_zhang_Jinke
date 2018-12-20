using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImageCtr : ICtr {

    public Animator animator;
    // Use this for initialization
    public override void initialization()
    {
        base.initialization();
    }

    public override void HideAll(float time = 1)
    {
        animator.SetBool("Show", false);
    }

    public override void ShowAll(float time = 1)
    {
        animator.SetBool("Show", true);
    }

}
