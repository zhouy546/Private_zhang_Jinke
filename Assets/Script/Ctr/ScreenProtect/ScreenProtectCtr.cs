using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenProtectCtr : ICtr {
    public static ScreenProtectCtr instance;
    public List<ICtr> ctrs = new List<ICtr>();
    public ICtr logoCtr;
    public Transform CameratransformPos;
	// Use this for initialization
	public override void initialization() {
        base.initialization();
        logoCtr.initialization();
        logoCtr.ShowAll();


        foreach (ICtr ctr in ctrs)
        {
            float time =Random.Range(0.5f, 1f);
            ctr.initialization();
           StartCoroutine( ctr.show(time));
            
        }

        if (instance == null) {
            instance = this;
        }
	}

    private void OnEnable()
    {
        DealWithUDPMessage.ToScreenProtect += show;
        DealWithUDPMessage.ToDefaultScene += hide;
        DealWithUDPMessage.ToLogoWell += hide;
        DealWithUDPMessage.ToIntro += hide;
        DealWithUDPMessage.ToStrategy += hide;
        DealWithUDPMessage.ToYeWuMoXing += hide;
        DealWithUDPMessage.ToCo += hide;
        DealWithUDPMessage.ToMatching += hide;
        DealWithUDPMessage.ToChinaMap += hide;
        DealWithUDPMessage.ToMainVideo += hide;

        DefaultNodesCtr.HideMainPic += hide;
        DefaultNodesCtr.ShowMainPic += hide;
    }

    private void OnDisable()
    {
        DealWithUDPMessage.ToScreenProtect -= show;
        DealWithUDPMessage.ToDefaultScene -= hide;
        DealWithUDPMessage.ToLogoWell -= hide;
        DealWithUDPMessage.ToIntro -= hide;
        DealWithUDPMessage.ToStrategy -= hide;
        DealWithUDPMessage.ToYeWuMoXing -= hide;
        DealWithUDPMessage.ToCo -= hide;
        DealWithUDPMessage.ToMatching -= hide;
        DealWithUDPMessage.ToChinaMap -= hide;
        DealWithUDPMessage.ToMainVideo -= hide;

        DefaultNodesCtr.HideMainPic -= hide;
        DefaultNodesCtr.ShowMainPic -= hide;
    }

    private void show() {
        ShowAll();
    }

    private void hide() {
        HideAll();
    }

    public override void ShowAll(float time = 1)
    {
        showAnim();
    }

    public override void HideAll(float time = 1)
    {
        foreach (ICtr ctr in ctrs)
        {
            ctr.HideAll();
        }

        logoCtr.HideAll();
    }


    private void showAnim() {
        foreach (ICtr ctr in ctrs)
        {
            float time = Random.Range(0.5f,1f);
           
            StartCoroutine(ctr.show(time));

        }

        logoCtr.ShowAll();
    }
}
