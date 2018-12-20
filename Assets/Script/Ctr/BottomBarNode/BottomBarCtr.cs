using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtility;
public class BottomBarCtr : ICtr {
    private float canvasWidth = 2428;

    public Transform arrow;

    public Transform colorBar;


    public static BottomBarCtr instance;

    public Animator animator;

    public void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }

    private void OnEnable()
    {
        DealWithUDPMessage.ToDefaultScene += Show;
        DealWithUDPMessage.ToLogoWell+= Hide;
        DealWithUDPMessage.ToIntro+=Show;
        DealWithUDPMessage.ToStrategy += Show;
        DealWithUDPMessage.ToScreenProtect+= Hide;
        DealWithUDPMessage.ToYeWuMoXing+= Hide;
        DealWithUDPMessage.ToCo+= Hide;
        DealWithUDPMessage.ToMatching+= Hide;
        DealWithUDPMessage.ToChinaMap+= Hide;
        DealWithUDPMessage.ToMainVideo+= Hide;
}

    private void OnDisable()
    {
        DealWithUDPMessage.ToDefaultScene -= Show;
        DealWithUDPMessage.ToLogoWell -= Hide;
        DealWithUDPMessage.ToIntro -= Show;
        DealWithUDPMessage.ToStrategy -= Show;
        DealWithUDPMessage.ToScreenProtect -= Hide;
        DealWithUDPMessage.ToYeWuMoXing -= Hide;
        DealWithUDPMessage.ToCo -= Hide;
        DealWithUDPMessage.ToMatching -= Hide;
        DealWithUDPMessage.ToChinaMap -= Hide;
        DealWithUDPMessage.ToMainVideo -= Hide;
    }

    private void Show() {
        ShowAll();
    }

    private void Hide() {
        HideAll();
    }

    public override void ShowAll(float time = 1)
    {
        animator.SetBool("Show", true);
    }

    public override void HideAll(float time = 1)
    {
        animator.SetBool("Show", false);
    }

    public void updateBar(int num,float barMax) {

        MoveBar(getTargetPosX(num, barMax));

        MoveColorBar(getScaleX(num, barMax));

    }

    private float getTargetPosX(int num,float barMax) {
        float barVal = (float)num+1f;
       
        float targetPosX = Utility.Maping(barVal, 0f, barMax, -canvasWidth/2, canvasWidth/2, true);


        return targetPosX;
    }

    private float getScaleX(int num, float barMax) {
        float barVal = (float)num + 1f;

        float ScaleX = Utility.Maping(barVal, 0f, barMax, 0, 1f, true);

        return ScaleX;

    }



    private void MoveBar(float targetPosX) {
        LeanTween.moveLocalX(arrow.gameObject, targetPosX, 0.5f);
    }

    private void MoveColorBar(float scaleX) {
        LeanTween.scaleX(colorBar.gameObject, scaleX, 0.5f);
    }
}
