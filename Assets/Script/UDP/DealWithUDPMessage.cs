
//*********************❤*********************
// 
// 文件名（File Name）：	DealWithUDPMessage.cs
// 
// 作者（Author）：			LoveNeon
// 
// 创建时间（CreateTime）：	Don't Care
// 
// 说明（Description）：	接受到消息之后会传给我，然后我进行处理
// 
//*********************❤*********************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

public class DealWithUDPMessage : MonoBehaviour {
    public static Action ToDefaultScene3;
    public static Action ToDefaultScene2;
    public static Action ToDefaultScene;
    
    public static Action ToScreenProtect;
   
    public static Action ToMainVideo;
    public static Action<string> PlayMainVideo;


    public static DealWithUDPMessage instance;
    // public GameObject wellMesh;
    public string dataTest;
    // public static char[] sliceStr;
    private Vector3 CamRotation;

    //public string tempstr = "4000";

    private static bool isInDefaultScreen, isInDefaultScreen2, isInDefaultScreen3;

    private string perviousData="4000";

    public string goBackStr ="4000";
    //private static bool isInScreenProtect=true;


    //public LogoWellCtr logoWellCtr;
    //private bool enterTrigger, exitTrigger;
    /// <summary>
    /// 消息处理
    /// </summary>
    /// <param name="_data"></param>
    public void MessageManage(string _data)
    {
        if (_data != ""&& _data!=perviousData)
        {
           // CataCtr.instance.HideAll();

            dataTest = _data;

            goBackStr = perviousData;
            Debug.Log(dataTest);


            if (dataTest == "4000")
            {
                toScreenProtect();
                CataCtr.instance.HideAll();
            }
            else if (ValueSheet.NodeList_UDP_ID.ContainsKey(dataTest))
            {//项目介绍
                toDefaultScene();
                CataCtr.instance.HideAll();
                Debug.Log(ValueSheet.ID_Node_keyValuePairs.Count);

                OverriderCameraMove.instance.Go(ValueSheet.NodeList_UDP_ID[dataTest], ValueSheet.ID_Node_keyValuePairs, DefaultNodesCtr.instance);

            }
            else if (ValueSheet.NodeList2_UDP_ID.ContainsKey(dataTest))
            {
                toDefaultScene2();
                CataCtr.instance.HideAll();
                OverriderCameraMove.instance.Go(ValueSheet.NodeList2_UDP_ID[dataTest], ValueSheet.ID_Node2_keyValuePairs, DefaultNodesCtr2.instance, 200);
            }
            else if (ValueSheet.NodeList3_UDP_ID.ContainsKey(dataTest)) {
                toDefaultScene3();
                CataCtr.instance.HideAll();
                OverriderCameraMove.instance.Go(ValueSheet.NodeList3_UDP_ID[dataTest], ValueSheet.ID_Node3_keyValuePairs, DefaultNodesCtr3.instance, -200);
            }

            else if (dataTest == "1000") {
                //CataCtr.instance.HideAll();
                //CataCtr.instance.CataNodes[0].ShowAll();
                toDefaultScene();
                OverriderCameraMove.instance.moveToDefaultNodes();
            }
            else if (dataTest == "2000") {
               // CataCtr.instance.HideAll();
               // CataCtr.instance.CataNodes[1].ShowAll();
                toDefaultScene2();
                OverriderCameraMove.instance.moveToDefaultNodes2();
            }
            else if (dataTest == "3000")
            {
              //  CataCtr.instance.HideAll();
             //   CataCtr.instance.CataNodes[2].ShowAll();
                toDefaultScene3();
                OverriderCameraMove.instance.moveToDefaultNodes3();
            } else if (dataTest=="5000") {
                toMainVideo();
            }

        }

        perviousData = dataTest;

    }



    private void Awake()
    {

    }

    public IEnumerator Initialization() {
        if (instance == null)
        {
            instance = this;
        }
        yield return new  WaitForSeconds(0.01f);
    }

    public void Start()
    {

    }


    private void Update()
    {


        //Debug.Log("数据：" + dataTest);  
    }

    public static void toDefaultScene() {
        if (!isInDefaultScreen) {
            CataCtr.instance.CataNodes[0].ShowAll();
            CataCtr.instance.CataNodes[1].HideAll();
            CataCtr.instance.CataNodes[2].HideAll();

            Debug.Log("去项目集锦");
            ToDefaultScene?.Invoke();
          //  isInDefaultScreen = true;
            isInDefaultScreen3 = isInDefaultScreen2 = false;
        }
    }

    public static void toDefaultScene2()
    {
        if (!isInDefaultScreen2)
        {
            Debug.Log("去项目集锦");
            CataCtr.instance.CataNodes[1].ShowAll();
            CataCtr.instance.CataNodes[0].HideAll();
            CataCtr.instance.CataNodes[2].HideAll();
            ToDefaultScene2?.Invoke();
           //  isInDefaultScreen2 = true;
            isInDefaultScreen3 = isInDefaultScreen= false;
        }
    }

    public static void toDefaultScene3()
    {
        if (!isInDefaultScreen3)
        {
            CataCtr.instance.CataNodes[2].ShowAll();
            CataCtr.instance.CataNodes[0].HideAll();
            CataCtr.instance.CataNodes[1].HideAll();
            Debug.Log("去项目集锦");
            ToDefaultScene3?.Invoke();
        //     isInDefaultScreen3 = true;
            isInDefaultScreen2 = isInDefaultScreen= false;
        }
    }


    public static void toMainVideo() {
        ToMainVideo?.Invoke();
        isInDefaultScreen2 = isInDefaultScreen = isInDefaultScreen3 = false;

        playMainVideo(ValueSheet.MainVideoUrl);
    }




    public static void toScreenProtect()
    {
        //if (!isInScreenProtect) {
            ToScreenProtect?.Invoke();
        //isInScreenProtect = true;
        isInDefaultScreen2= isInDefaultScreen = isInDefaultScreen3 = false;
        //}
    }



    public static void playMainVideo(string str = " ") {
        PlayMainVideo?.Invoke(str);
    }

}
