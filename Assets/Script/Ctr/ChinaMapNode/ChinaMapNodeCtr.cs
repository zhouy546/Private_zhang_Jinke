using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChinaMapNodeCtr : ICtr {

    public Transform CameratransformPos;

    public List<ICtr> ctrs = new List<ICtr>();


    private void OnEnable()
    {
        DealWithUDPMessage.ToIntro += hide;
        DealWithUDPMessage.ToDefaultScene += hide;
        DealWithUDPMessage.ToLogoWell += hide;
        DealWithUDPMessage.ToScreenProtect += hide;
        DealWithUDPMessage.ToStrategy += hide;

        DealWithUDPMessage.ToYeWuMoXing += hide;
        DealWithUDPMessage.ToCo += hide;
        DealWithUDPMessage.ToMatching += hide;
        DealWithUDPMessage.ToChinaMap += show;
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
        DealWithUDPMessage.ToMatching -= hide;
        DealWithUDPMessage.ToChinaMap -= show;
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

    public override void initialization()
    {
        base.initialization();

        foreach (var item in ctrs)
        {
            item.initialization();
        }

        ValueSheet.chinaMapNodeCtr.Add(this);
    }

    public override void ShowAll(float time = 1)
    {
        foreach (var ctr in ctrs)
        {
            ctr.ShowAll();
        }
    }

    public override void HideAll(float time = 1)
    {
        foreach (var ctr in ctrs)
        {
            ctr.HideAll();
        }
    }
}
