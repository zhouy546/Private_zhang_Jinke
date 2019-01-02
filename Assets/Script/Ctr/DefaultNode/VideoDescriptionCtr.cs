using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoDescriptionCtr : ICtr {
    public Animator animator;
    public MediaPlayer mediaPlayer;
    public NodeCtr nodeCtr;

    private bool isOpen;

    public override void initialization()
    {
        base.initialization();


    }



    public override void HideAll(float time = 1)
    {
        animator.SetBool("Show", false);
        StopVideo();
    }

    public override void ShowAll(List<Node> nodes,float time = 1)
    {
        animator.SetBool("Show", true);
        PlayVideo(nodes[int.Parse(nodeCtr.ID)].VideoName);
    }

    public override void PlayVideo(string str)
    {
        if (!isOpen) {
            mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, str, true);
            isOpen = true;

            //Debug.Log("打开视频");
        }
    }

    public override void StopVideo()
    {
        StartCoroutine(stopVideo());
    }

    private IEnumerator stopVideo() {

        if (isOpen) {

            mediaPlayer.Stop();

            yield return new WaitForSeconds(1f);

            mediaPlayer.CloseVideo();

            isOpen = false;

            //Debug.Log("关闭视频");
        }
    }
}
