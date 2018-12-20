using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ICtr : MonoBehaviour {
    public List<NImage> AllNimages = new List<NImage>();
    public List<Ntext> Alltexts = new List<Ntext>();


    public virtual void initialization()
    {
        NImage[] tempImages = GetComponentsInChildren<NImage>();
        AllNimages.AddRange(tempImages);

        Ntext[] temptexts = GetComponentsInChildren<Ntext>();
        Alltexts.AddRange(temptexts);
    }

    public virtual void ShowAll(float time = 1)
    {
        foreach (var item in AllNimages)
        {
            item.ShowAll(time);
            item.ChangeColor(item.DefaultColor, 1f);
        }


        foreach (var item in Alltexts)
        {
            item.ShowAll(time);
            item.ChangeColor(item.DefaultColor, 1f);
        }
    }

    public virtual void HideAll(float time = 1)
    {
        foreach (var item in AllNimages)
        {
            item.HideAll(time);
        }

        foreach (var item in Alltexts)
        {
            item.HideAll(time);
        }
    }

    public virtual IEnumerator TriggerFloating(float time) {
        yield return new WaitForSeconds(time);
    }

    public virtual IEnumerator show(float time) {
        yield return new WaitForSeconds(time);
    }

    public virtual void ShowOne(ICtr ctr) {

    }

    public virtual void HideOne(ICtr ctr)
    {

    }


    public virtual void PlayVideo(string str) {

    }


    public virtual void StopVideo() {

    }

    public virtual void ToggleMainPic(bool b, List<NodeCtr> nodeCtrs)
    {


    }

    public virtual Transform GetCameraPos() {
       
        return this.transform;
    }

    public virtual Image GetImage() {
        return this.GetComponent<Image>();
    }
    //public void InteractionToggle(bool b)
    //{
    //    foreach (var item in AllNimages)
    //    {
    //        if (item.isInteractionObject)
    //        {
    //            item.setRarCastTarget(b);
    //        }


    //    }

    //    foreach (var item in Alltexts)
    //    {
    //        if (item.isInteractionObject)
    //        {
    //            item.setRarCastTarget(b);
    //        }

    //    }
    //}

}
