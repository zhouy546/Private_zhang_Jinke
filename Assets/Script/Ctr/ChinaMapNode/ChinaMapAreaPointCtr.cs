using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChinaMapAreaPointCtr : ICtr {
    public Animator animator;

    // Use this for initialization
    public override void initialization()
    {
        base.initialization();
    }

    // Update is called once per frame
    void Update () {
		
	}
    public override void ShowAll(float time = 1)
    {
        animator.SetBool("Show", true);
    }

    public override void HideAll(float time = 1)
    {
        animator.SetBool("Show", false);
    }
}
