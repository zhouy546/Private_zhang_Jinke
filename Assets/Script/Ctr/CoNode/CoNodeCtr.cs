using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoNodeCtr : ICtr {
    public static CoNodeCtr instance;
    public Animator animator;
    public Image[] images;

    public Transform CameratransformPos;
    // Use this for initialization
    void Start()
    {
        initialization();

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

    private void OnEnable()
    {
        DealWithUDPMessage.ToIntro += hide;
        DealWithUDPMessage.ToDefaultScene += hide;
        DealWithUDPMessage.ToLogoWell += hide;
        DealWithUDPMessage.ToScreenProtect += hide;
        DealWithUDPMessage.ToStrategy += hide;

        DealWithUDPMessage.ToYeWuMoXing += hide;
        DealWithUDPMessage.ToCo += show;
        DealWithUDPMessage.ToMatching += hide;
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
        DealWithUDPMessage.ToCo -= show;
        DealWithUDPMessage.ToMatching -= hide;
        DealWithUDPMessage.ToChinaMap -= hide;
        DealWithUDPMessage.ToMainVideo -= hide;

        DefaultNodesCtr.HideMainPic -= hide;
        DefaultNodesCtr.ShowMainPic -= hide;
    }

    private void SetUpImage()
    {
        foreach (Sprite sprite in ValueSheet.CoNodeUIsprites)
        {
            images[ValueSheet.CoNodeUIsprites.IndexOf(sprite)].sprite = sprite;
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
