using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : ICtr {
    public List<ICtr> ctrs = new List<ICtr>();

    public void OnEnable()
    {
        DealWithUDPMessage.ToDefaultScene += ShowDangQunFuWuZhongXin;
        DealWithUDPMessage.ToDefaultScene2 += ShowDangQunFuWuZhan;
        DealWithUDPMessage.ToDefaultScene3 += ShowFenXiaoXhao;
        DealWithUDPMessage.ToScreenProtect += hideAll;
    }

    public void OnDisable()
    {
        DealWithUDPMessage.ToDefaultScene -= ShowDangQunFuWuZhongXin;
        DealWithUDPMessage.ToDefaultScene2 -= ShowDangQunFuWuZhan;
        DealWithUDPMessage.ToDefaultScene3 -= ShowFenXiaoXhao;
        DealWithUDPMessage.ToScreenProtect -= hideAll;
    }

    // Use this for initialization
    public override void initialization() {
		
	}


    private void ShowDangQunFuWuZhongXin() {
        ShowOne(ctrs[0]);
    }

    private void ShowDangQunFuWuZhan() {
        ShowOne(ctrs[1]);
    }

    private void ShowFenXiaoXhao() {
        ShowOne(ctrs[2]);
    }


    public override void ShowOne(ICtr ctr)
    {
        foreach (var item in ctrs)
        {
            if (item == ctr)
            {
                ctr.ShowAll();
            }
            else {
                item.HideAll();
            }
        }
    }

    private void hideAll() {
        HideAll();
    }

    public override void HideAll(float time = 1)
    {
        foreach (ICtr item in ctrs)
        {
            item.HideAll();
        }
    }
}
