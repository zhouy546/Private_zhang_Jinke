using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultNodesCtr : ICtr {
    public static DefaultNodesCtr instance;
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


    public static void  showMainPic(){
        ShowMainPic?.Invoke();
    }

    public static void hideMainPic() {
        HideMainPic?.Invoke();
    }

    public static void ShowDescription(int id) {
        ValueSheet.nodeCtrs[id].ShowDescription();
    }


}
