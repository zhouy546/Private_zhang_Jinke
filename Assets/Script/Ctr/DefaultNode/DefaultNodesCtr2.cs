using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultNodesCtr2 : ICtr {
    public static DefaultNodesCtr2 instance;
    public static Action HideMainPic;
    public static Action ShowMainPic;

    public override void initialization()
    {
        base.initialization();
        if (instance == null)
        {
            instance = this;
        }
    }


    public override void showMainPicDe()
    {
        ShowMainPic?.Invoke();
    }

    public override void hideMainPicDe()
    {
        HideMainPic?.Invoke();
    }

    public override void ShowDescriptionDe(int id)
    {
        ValueSheet.nodeCtrs2[id].ShowDescription();
    }

}
