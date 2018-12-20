using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingNodeCtr : ICtr {
    public static MatchingNodeCtr instance;
    public Animator animator;
    public Image[] images;

    public Transform CameratransformPos;
    // Use this for initialization
    void Start()
    {
        initialization();

    }

    private void OnEnable()
    {
        DealWithUDPMessage.ToIntro += hide;
        DealWithUDPMessage.ToDefaultScene += hide;
        DealWithUDPMessage.ToLogoWell += hide;
        DealWithUDPMessage.ToScreenProtect += hide;
        DealWithUDPMessage.ToStrategy += hide;

        DealWithUDPMessage.ToYeWuMoXing += hide;
        DealWithUDPMessage.ToCo += hide;
        DealWithUDPMessage.ToMatching += show;
        DealWithUDPMessage.ToChinaMap += hide;
        DealWithUDPMessage.ToMainVideo += hide;

        DefaultNodesCtr.HideMainPic += hide;
        DefaultNodesCtr.ShowMainPic += hide;
    }

    private void OnDisable()
    {
        DealWithUDPMessage.ToIntro -= hide;
        DealWithUDPMessage.ToDefaultScene -= hide;
        DealWithUDPMessage.ToLogoWell -= hide;
        DealWithUDPMessage.ToScreenProtect -= hide;
        DealWithUDPMessage.ToStrategy -= hide;

        DealWithUDPMessage.ToYeWuMoXing -= hide;
        DealWithUDPMessage.ToCo -= hide;
        DealWithUDPMessage.ToMatching -= show;
        DealWithUDPMessage.ToChinaMap -= hide;
        DealWithUDPMessage.ToMainVideo -= hide;


        DefaultNodesCtr.HideMainPic -= hide;
        DefaultNodesCtr.ShowMainPic -= hide;
    }

    public override void initialization()
    {
        base.initialization();
        if (instance == null)
        {
            instance = this;
        }
        SetUpImage();
    }

    private void SetUpImage()
    {
        foreach (Sprite sprite in ValueSheet.MatchingUIsprites)
        {
            images[ValueSheet.MatchingUIsprites.IndexOf(sprite)].sprite = sprite;
        }

    }

    public void show()
    {

        ShowAll();
    }

    public void hide()
    {
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
}
