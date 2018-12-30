using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangQunFuWuZhongXinNode : ICtr {
    public Animator m_animator;


    public override void ShowAll(float time = 1)
    {
        m_animator.SetBool("Show", true);
     
    }

    public override void HideAll(float time = 1)
    {
        m_animator.SetBool("Show", false);
    }
}
