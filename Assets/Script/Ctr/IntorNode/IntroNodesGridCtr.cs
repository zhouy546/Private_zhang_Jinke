using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroNodesGridCtr : ICtr {
    public Image[] images;

    public Animator animator;
    public float moveDisPreUnit = 100;
	// Use this for initialization
	public override void initialization() {
        base.initialization();
        SetUpImage();

    }

    public void show() {

        ShowAll();
    }

    public void hide() {
        HideAll();
    }

    public override void HideAll(float time = 1)
    {
        animator.SetBool("Show", false);
    }

    public override void ShowAll(float time = 1)
    {
        animator.SetBool("Show", true);
    }

    private void SetUpImage()
    {
        foreach (Sprite sprite in ValueSheet.IntroUIsprites)
        {
            images[ValueSheet.IntroUIsprites.IndexOf(sprite)].sprite = sprite;
        }

    }
}
