using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChinaMapMainUiCtr : ICtr {
    public List<ICtr> ctrs = new List<ICtr>();

    public Animator animator;
    public Image MainImage;
    public Image DesImage;

    public override void initialization()
    {
        base.initialization();

        foreach (var item in ctrs)
        {
            item.initialization();
        }
        SetupImage();

    }

    public override void ShowAll(float time = 1)
    {
        animator.SetBool("Show", true);

        foreach (var ctr in ctrs)
        {
            ctr.ShowAll();
        }
    }

    public override void HideAll(float time = 1)
    {
        animator.SetBool("Show", false);

        foreach (var ctr in ctrs)
        {
            ctr.HideAll();
        }
    }

    public void SetupImage() {
        MainImage.sprite = ValueSheet.ChinaMapUIsprites[0];
        DesImage.sprite = ValueSheet.ChinaMapUIsprites[1];
    }

}
