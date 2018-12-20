using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrategyNodeCtr : ICtr {
    public List<ICtr> ctrs = new List<ICtr>();

    private void Start()
    {
        initialization(); 
    }


    public override void initialization()
    {
        base.initialization();

        foreach (var ctr in ctrs)
        {
            ctr.initialization();
        }
        SetupImage();
    }

    private void OnEnable()
    {
        DealWithUDPMessage.ToDefaultScene += hide;
        DealWithUDPMessage.ToLogoWell += hide;
        DealWithUDPMessage.ToScreenProtect += hide;
        DealWithUDPMessage.ToIntro += hide;
        DealWithUDPMessage.ToStrategy += show;
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
        DealWithUDPMessage.ToDefaultScene -= hide;
        DealWithUDPMessage.ToLogoWell -= hide;
        DealWithUDPMessage.ToScreenProtect -= hide;
        DealWithUDPMessage.ToIntro -= hide;
       DealWithUDPMessage.ToStrategy -= show;
        DealWithUDPMessage.ToYeWuMoXing -= hide;
        DealWithUDPMessage.ToCo -= hide;
        DealWithUDPMessage.ToMatching -= hide;
        DealWithUDPMessage.ToChinaMap -= hide;
        DealWithUDPMessage.ToMainVideo -= hide;

        DefaultNodesCtr.HideMainPic -= hide;
        DefaultNodesCtr.ShowMainPic -= hide;
    }


    public Vector3 GetPos(int id) {
      return  ctrs[id].GetCameraPos().position;


    }

    public void SetupImage() {

        foreach (var ctr in ctrs)
        {
            ctr.GetImage().sprite = ValueSheet.StrategyUIsprites[ctrs.IndexOf(ctr)];

            //SetScale(ctr.GetImage(), ValueSheet.StrategyUIsprites[ctrs.IndexOf(ctr)]);
        }
    }

    private void SetScale(Image img,Sprite comingSprite,float Height = 30.46f) {
        float _width = Height * comingSprite.rect.width / comingSprite.rect.height;

        Rect rect = img.rectTransform.rect;

        rect.Set(0, 0, _width, Height);

        Debug.Log("width" + _width + "height" + Height);


    }

    public override void ShowAll(float time = 1)
    {
        foreach (var ctr in ctrs)
        {
            ctr.ShowAll();
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

    public override void HideAll(float time = 1)
    {
        foreach (var ctr in ctrs)
        {
            ctr.HideAll();
        }
    }

    private void hide() {
        HideAll();
    }

    private void show()
    {

        ShowAll();
    }


}
