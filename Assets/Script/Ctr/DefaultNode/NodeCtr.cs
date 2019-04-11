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
        //initialization();
    }

    // Use this for initialization
    public void initialization(List<Sprite> mainUIsprite, Dictionary<int, List<Sprite>> DescriptionkeyValuePairs) {
        base.initialization();
        ID = gameObject.name;
        foreach (var item in ctrs)
        {
            item.initialization();
        }

        SetUpImage(mainUIsprite, DescriptionkeyValuePairs);

        if (ValueSheet.nodeCtrs.Contains(this))
        {
            DefaultNodesCtr.HideMainPic += hideMainPic;

            DefaultNodesCtr.ShowMainPic += showMainImage;

            DealWithUDPMessage.ToDefaultScene += showMainImage;

            DealWithUDPMessage.ToDefaultScene2 += HideAllImage;

            DealWithUDPMessage.ToDefaultScene3 += HideAllImage;
        }
        else if (ValueSheet.nodeCtrs2.Contains(this)) {
            DefaultNodesCtr2.HideMainPic += hideMainPic;
            DefaultNodesCtr2.ShowMainPic += showMainImage;
            DealWithUDPMessage.ToDefaultScene2 += showMainImage;
            DealWithUDPMessage.ToDefaultScene += HideAllImage;
            DealWithUDPMessage.ToDefaultScene3 += HideAllImage;
        } else if (ValueSheet.nodeCtrs3.Contains(this)){
            DefaultNodesCtr3.HideMainPic += hideMainPic;
            DefaultNodesCtr3.ShowMainPic += showMainImage;
            DealWithUDPMessage.ToDefaultScene2 += HideAllImage;
            DealWithUDPMessage.ToDefaultScene += HideAllImage;
            DealWithUDPMessage.ToDefaultScene3 += showMainImage;
        }

        //Debug.Log(ValueSheet.nodeCtrs3.Count + "Node3 Number");
    }

    private void OnEnable()
    {

   
        //DealWithUDPMessage.ToLogoWell += HideAllImage;
        DealWithUDPMessage.ToScreenProtect += HideAllImage;
        //DealWithUDPMessage.ToIntro += HideAllImage;
        //DealWithUDPMessage.ToStrategy += HideAllImage;
        //DealWithUDPMessage.ToYeWuMoXing += HideAllImage;
        //DealWithUDPMessage.ToCo += HideAllImage;
        //DealWithUDPMessage.ToMatching += HideAllImage;
        //DealWithUDPMessage.ToChinaMap += HideAllImage;
        DealWithUDPMessage.ToMainVideo += HideAllImage;




    }

    private void OnDisable()
    {
        DealWithUDPMessage.ToDefaultScene -= showMainImage;
        //DealWithUDPMessage.ToLogoWell -= HideAllImage;
        DealWithUDPMessage.ToScreenProtect -= HideAllImage;
        //DealWithUDPMessage.ToIntro -= HideAllImage;
        //DealWithUDPMessage.ToStrategy -= HideAllImage;
        //DealWithUDPMessage.ToYeWuMoXing -= HideAllImage;
        //DealWithUDPMessage.ToCo -= HideAllImage;
        //DealWithUDPMessage.ToMatching -= HideAllImage;
        //DealWithUDPMessage.ToChinaMap -= HideAllImage;
        DealWithUDPMessage.ToMainVideo -= HideAllImage;

        DefaultNodesCtr.HideMainPic -= hideMainPic;
        DefaultNodesCtr.ShowMainPic -= showMainImage;
        DefaultNodesCtr2.HideMainPic -= hideMainPic;
        DefaultNodesCtr2.ShowMainPic -= showMainImage;
        DefaultNodesCtr3.HideMainPic -= hideMainPic;
        DefaultNodesCtr3.ShowMainPic -= showMainImage;
    }


    void Update () {

	}

    public void ShowDescription(List<Node> nodes) {
       
        for (int i = 0; i < ctrs.Count; i++)
        {
            if (i == ctrs.IndexOf(ctrs[1]))
            {
                ctrs[i].ShowAll(nodes);
            }
            else
            {
                ctrs[i].HideAll();
            }
        }
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
            else
            {
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

    private void SetUpImage(List<Sprite> mainUIsprite,Dictionary<int,List<Sprite>> DescriptionkeyValuePairs)
    {

        MainImage.sprite = mainUIsprite[int.Parse(ID)];

        //Debug.Log("id"+int.Parse(ID));

        //Debug.Log(DescriptionkeyValuePairs[int.Parse(ID)]);

        DescriptionImage.sprite = DescriptionkeyValuePairs[int.Parse(ID)][0];
    }

}
