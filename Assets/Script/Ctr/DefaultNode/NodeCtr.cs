using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeCtr : ICtr {
    public Transform cameraSetTrans;
    public List<ICtr> ctrs = new List<ICtr>();
    public string ID;

    public Image MainImage;
    public Image DescriptionImage;

    public void Start()
    {
        initialization();
    }

    // Use this for initialization
    public override void initialization() {
        base.initialization();
        ID = gameObject.name;
        foreach (var item in ctrs)
        {
            item.initialization();
        }

        SetUpImage();

    }

    private void OnEnable()
    {

        DealWithUDPMessage.ToDefaultScene += showMainImage;
        DealWithUDPMessage.ToLogoWell += HideAllImage;
        DealWithUDPMessage.ToScreenProtect += HideAllImage;
        DealWithUDPMessage.ToIntro += HideAllImage;
        DealWithUDPMessage.ToStrategy += HideAllImage;
        DealWithUDPMessage.ToYeWuMoXing += HideAllImage;
        DealWithUDPMessage.ToCo += HideAllImage;
        DealWithUDPMessage.ToMatching += HideAllImage;
        DealWithUDPMessage.ToChinaMap += HideAllImage;
        DealWithUDPMessage.ToMainVideo += HideAllImage;

        DefaultNodesCtr.HideMainPic += hideMainPic;
        DefaultNodesCtr.ShowMainPic += showMainImage;
    }

    private void OnDisable()
    {
        DealWithUDPMessage.ToDefaultScene -= showMainImage;
        DealWithUDPMessage.ToLogoWell -= HideAllImage;
        DealWithUDPMessage.ToScreenProtect -= HideAllImage;
        DealWithUDPMessage.ToIntro -= HideAllImage;
        DealWithUDPMessage.ToStrategy -= HideAllImage;
        DealWithUDPMessage.ToYeWuMoXing -= HideAllImage;
        DealWithUDPMessage.ToCo -= HideAllImage;
        DealWithUDPMessage.ToMatching -= HideAllImage;
        DealWithUDPMessage.ToChinaMap -= HideAllImage;
        DealWithUDPMessage.ToMainVideo -= HideAllImage;

        DefaultNodesCtr.HideMainPic -= hideMainPic;
        DefaultNodesCtr.ShowMainPic -= showMainImage;
    }


    void Update () {

	}

    public void ShowDescription() {
        ShowOne(ctrs[1]);
    }

    private void hideMainPic() {
        HideOne(ctrs[0]);
    }

    private void showMainImage() {
        ShowOne(ctrs[0]);
    }

    private void HideAllImage() {
        HideAll();
    }

    public override void HideAll(float time = 1)
    {
        foreach (var item in ctrs)
        {
            item.HideAll();
        }
    }

    public override void ShowAll(float time = 1)
    {
        foreach (var item in ctrs)
        {
            item.ShowAll();
        }
    }

    public override void ShowOne(ICtr ctr)
    {
        for (int i = 0; i < ctrs.Count; i++)
        {
            if (i == ctrs.IndexOf(ctr))
            {
                ctrs[i].ShowAll();
            }
            else {
                ctrs[i].HideAll();
            }
        }
    }

    public override void HideOne(ICtr ctr)
    {
        for (int i = 0; i < ctrs.Count; i++)
        {
            if (i == ctrs.IndexOf(ctr))
            {
                ctrs[i].HideAll();
            }
        }
    }

    private void SetUpImage()
    {

        MainImage.sprite = ValueSheet.MainUIsprites[int.Parse(ID)];

        DescriptionImage.sprite = ValueSheet.DescriptionkeyValuePairs[int.Parse(ID)][0];
    }

}
