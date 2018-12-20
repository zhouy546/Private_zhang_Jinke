using RenderHeads.Media.AVProVideo;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainVideoNodeCtr : ICtr {

    //public static Action OnVideFinished;
    public MediaPlayer medialPlayer;
    public Animator animator;
    private bool isMainVideo;

    public override void initialization()
    {
        base.initialization();
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
        DealWithUDPMessage.ToMatching += hide;
        DealWithUDPMessage.ToChinaMap += hide;
        DealWithUDPMessage.ToMainVideo += show;
        DealWithUDPMessage.PlayMainVideo += PlayVideo;
        //DefaultNodesCtr.HideMainPic += hide;
        //DefaultNodesCtr.ShowMainPic += hide;
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
        DealWithUDPMessage.ToChinaMap -= hide;
        DealWithUDPMessage.ToMainVideo -= show;
        DealWithUDPMessage.PlayMainVideo -= PlayVideo;

        //DefaultNodesCtr.HideMainPic -= hide;
        //DefaultNodesCtr.ShowMainPic -= hide;
    }

    public void CheckIsFinish() {
      //  Debug.Log("finished");
        hide();

        SendUPDData.instance.udp_Send("10000", "192.168.1.32", 29020);

        DealWithUDPMessage.instance.MessageManage(DealWithUDPMessage.instance.tempstr);

    }

    //public static void onvideFinished() {
    //    OnVideFinished?.Invoke();
    //}




    public override void PlayVideo(string str)
    {
        isMainVideo = true;
        medialPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, str, true);
    }

    public override void StopVideo()
    {
        medialPlayer.Stop();
    }

    public void show()
    {

        ShowAll();
    }

    public void hide()
    {
        HideAll();

        if (isMainVideo)
        {
            SoundMangager.instance.PlayBGM();
            isMainVideo = false;
        }
        
    }

    public override void HideAll(float time = 1)
    {
        animator.SetBool("Show", false);
        StopVideo();

    }

    public override void ShowAll(float time = 1)
    {
        animator.SetBool("Show", true);

        //PlayVideo(ValueSheet.MainVideoUrl);
    }

}
