using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroNodeCtr : ICtr {
    public static IntroNodeCtr instance;
    public Transform CameratransformPos;
    public IntroNodesGridCtr introNodesGridCtr;
    // Use this for initialization
    void Start () {
        initialization();

    }

    public override void initialization()
    {
        base.initialization();
        if (instance == null) {
            instance = this;
        }
        introNodesGridCtr.initialization();
    }

    public void OnEnable()
    {
        DealWithUDPMessage.ToIntro += introNodesGridCtr.show;
        DealWithUDPMessage.ToDefaultScene += introNodesGridCtr.hide;
        DealWithUDPMessage.ToLogoWell += introNodesGridCtr.hide;
        DealWithUDPMessage.ToScreenProtect +=introNodesGridCtr.hide;
        DealWithUDPMessage.ToStrategy += introNodesGridCtr.hide;
        DealWithUDPMessage.ToYeWuMoXing += introNodesGridCtr.hide;
        DealWithUDPMessage.ToCo += introNodesGridCtr.hide;
        DealWithUDPMessage.ToMatching += introNodesGridCtr.hide;
        DealWithUDPMessage.ToChinaMap += introNodesGridCtr.hide;
        DealWithUDPMessage.ToMainVideo +=introNodesGridCtr.hide;

        DefaultNodesCtr.HideMainPic += introNodesGridCtr.hide;
        DefaultNodesCtr.ShowMainPic += introNodesGridCtr.hide;

    }

    public void OnDisable()
    {
        DealWithUDPMessage.ToIntro -= introNodesGridCtr.show;

        DealWithUDPMessage.ToDefaultScene -= introNodesGridCtr.hide;
        DealWithUDPMessage.ToLogoWell -= introNodesGridCtr.hide;
        DealWithUDPMessage.ToScreenProtect -= introNodesGridCtr.hide;
        DealWithUDPMessage.ToStrategy -= introNodesGridCtr.hide;

        DealWithUDPMessage.ToYeWuMoXing -= introNodesGridCtr.hide;
        DealWithUDPMessage.ToCo -= introNodesGridCtr.hide;
        DealWithUDPMessage.ToMatching -=introNodesGridCtr.hide;
        DealWithUDPMessage.ToChinaMap -= introNodesGridCtr.hide;
        DealWithUDPMessage.ToMainVideo += introNodesGridCtr.hide;

        DefaultNodesCtr.HideMainPic -= introNodesGridCtr.hide;
        DefaultNodesCtr.ShowMainPic -= introNodesGridCtr.hide;
    }



    public Vector3 GetTargetCamPos(int id) {
        Vector3 temp = new Vector3(CameratransformPos.position.x + id * introNodesGridCtr.moveDisPreUnit, CameratransformPos.position.y, CameratransformPos.position.z);
        return temp;
    }


}
