using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrategySubNodeCtr : ICtr {
    public Transform CameraTransformPos;

    public Image image;

    public Animator animator;

    public override Transform GetCameraPos()
    {
        return CameraTransformPos;
    }

    public override Image GetImage()
    {
        return image;
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
