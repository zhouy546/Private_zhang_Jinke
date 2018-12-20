using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoDescriptionCtr : ICtr {
    public Animator animator;
    public MediaPlayer mediaPlayer;
    public NodeCtr nodeCtr;

    public override void initialization()
    {
        base.initialization();


    }



    public override void HideAll(float time = 1)
    {
        animator.SetBool("Show", false);
        StopVideo();
    }

    public override void ShowAll(float time = 1)
    {
        animator.SetBool("Show", true);
        PlayVideo(ValueSheet.NodeList[int.Parse(nodeCtr.ID)].VideoName);
    }

    public override void PlayVideo(string str)
    {
        mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, str, true);
    }

    public override void StopVideo()
    {
        mediaPlayer.Stop();
    }
}
