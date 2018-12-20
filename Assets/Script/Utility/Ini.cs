using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Ini : MonoBehaviour {
    private ReadJson readJson;
    private OverriderCameraMove OverridecameraMover;
    private DealWithUDPMessage dealWithUDPMessage;
    private CreateUI createUI;
    private ScreenProtectCtr screenProtectCtr;
    private ChinaMapNodeCtr chinaMapNodeCtr;

    private SoundMangager soundMangager;


    private void  Start() {
         StartCoroutine(initialization());
    }

    IEnumerator initialization()
    {
        Screen.SetResolution(2432, 960, false);

        dealWithUDPMessage = FindObjectOfType<DealWithUDPMessage>();

        readJson = FindObjectOfType<ReadJson>();

        OverridecameraMover = FindObjectOfType<OverriderCameraMove>();

        createUI = FindObjectOfType<CreateUI>();

        screenProtectCtr = FindObjectOfType<ScreenProtectCtr>();

        chinaMapNodeCtr = FindObjectOfType<ChinaMapNodeCtr>();

        soundMangager = FindObjectOfType<SoundMangager>();

        yield return StartCoroutine(readJson.initialization());

        yield return StartCoroutine(ReadAssetImage());

        yield return StartCoroutine(dealWithUDPMessage.Initialization());

        soundMangager.initialization();

        screenProtectCtr.initialization();

        createUI.Initialization();

        chinaMapNodeCtr.initialization();

        OverridecameraMover.initializtion(new Vector3(0, 15.3f, 300f), new Vector3(0, 15.3f, -30f));
    }

    IEnumerator ReadAssetImage()
    {
        yield return StartCoroutine(ReadMainUIsprites());

        yield return StartCoroutine(ReadDescription());

        yield return StartCoroutine(ReadIntroUIsprites());

        yield return StartCoroutine(ReadYeWuMoXingUIsprites());

        yield return StartCoroutine(ReadCoNodeUIsprites());

        yield return StartCoroutine(ReadMatchingUIsprites());

        yield return StartCoroutine(ReadStrategyUIsprites());

        yield return StartCoroutine(ReadChinaMapUIsprites());
    }


    IEnumerator ReadDescription()
    {
        for (int i = 0; i < ValueSheet.NodeList.Count; i++)
        {
            List<Sprite> sp = new List<Sprite>();
            string path = "/UI/Description/" + i.ToString() + "/";
            // Debug.Log(path);
            yield return GetSpriteListFromStreamAsset(path, "png", sp);

            ValueSheet.DescriptionkeyValuePairs.Add(i, sp);
        }

        //  Debug.Log(ValueSheet.DescriptionkeyValuePairs.Count);
    }



    IEnumerator ReadMainUIsprites()
    {
        string path = "/UI/MainPage/";
        yield return GetSpriteListFromStreamAsset(path, "jpg", ValueSheet.MainUIsprites);
        //foreach (var item in ValueSheet.MainUIsprites)
        //{
        //    Debug.Log(item.name);
        //}
       
    }

    IEnumerator ReadIntroUIsprites()
    {
        string path = "/UI/Intro/";
        yield return GetSpriteListFromStreamAsset(path, "png", ValueSheet.IntroUIsprites);
    }

    IEnumerator ReadYeWuMoXingUIsprites()
    {
        string path = "/UI/YeWuMoXing/";
        yield return GetSpriteListFromStreamAsset(path, "png", ValueSheet.YeWuMoXingUIsprites);
    }

    IEnumerator ReadCoNodeUIsprites()
    {
        string path = "/UI/Co/";
        yield return GetSpriteListFromStreamAsset(path, "png", ValueSheet.CoNodeUIsprites);
    }

    IEnumerator ReadMatchingUIsprites()
    {
        string path = "/UI/Matching/";
        yield return GetSpriteListFromStreamAsset(path, "png", ValueSheet.MatchingUIsprites);
    }

    IEnumerator ReadStrategyUIsprites()
    {
        string path = "/UI/Strategy/";
        yield return GetSpriteListFromStreamAsset(path, "png", ValueSheet.StrategyUIsprites);
    }

    IEnumerator ReadChinaMapUIsprites()
    {
        string path = "/UI/ChinaMap/";
        yield return GetSpriteListFromStreamAsset(path, "png", ValueSheet.ChinaMapUIsprites);
    }

    IEnumerator GetSpriteListFromStreamAsset(string path, string suffix, List<Sprite> sprites)
    {
        List<Texture> texturesList = new List<Texture>();
        string streamingPath = Application.streamingAssetsPath + path;
        DirectoryInfo dir = new DirectoryInfo(streamingPath);

        GetAllFiles(dir, path, suffix);

        foreach (string de in jpgName)
        {
            WWW www = new WWW(Application.streamingAssetsPath + path + de);
            yield return www;
            if (www != null)
            {
                Texture texture = www.texture;
                texture.name = de;
                texturesList.Add(texture);
            }
            if (www.isDone)
            {
                www.Dispose();
            }
        }

        foreach (var texture in texturesList)
        {
            Sprite sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            sprite.name = texture.name;
            sprites.Add(sprite);
        }

        jpgName.Clear();
    }

    List<string> jpgName = new List<string>();

    public void GetAllFiles(DirectoryInfo dir, string Filepath, string suffix)
    {
        FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();   //初始化一个FileSystemInfo类型的实例
        foreach (FileSystemInfo i in fileinfo)              //循环遍历fileinfo下的所有内容
        {
            if (i is DirectoryInfo)             //当在DirectoryInfo中存在i时
            {
                GetAllFiles((DirectoryInfo)i, Filepath, suffix);  //获取i下的所有文件
            }
            else
            {
                string str = i.FullName;        //记录i的绝对路径
                string path = Application.streamingAssetsPath + Filepath;
                string strType = str.Substring(path.Length);

                if (strType.Substring(strType.Length - 3).ToLower() == suffix)
                {
                    if (jpgName.Contains(strType))
                    {
                    }
                    else
                    {
                        jpgName.Add(strType);
                    }
                }
            }
        }
    }
}
