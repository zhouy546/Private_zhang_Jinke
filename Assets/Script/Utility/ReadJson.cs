using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using System.IO;

using LitJson;

using UnityEngine.UI;

public class ReadJson : MonoBehaviour {


    public static ReadJson instance;

  //  public  Ntext ntext;

    private JsonData itemDate;

    private string jsonString;

 


    public IEnumerator initialization() {
        if (instance == null)
        {

            instance = this;

        }

     yield return   StartCoroutine(readJson());
    }

    IEnumerator readJson() {
        string spath = Application.streamingAssetsPath + "/information.json";

        Debug.Log(spath);

        WWW www = new WWW(spath);

        yield return www;

        jsonString = System.Text.Encoding.UTF8.GetString(www.bytes);

        JsonMapper.ToObject(www.text);

       itemDate = JsonMapper.ToObject(jsonString.ToString());


        for (int i = 0; i < itemDate["information"].Count; i++)

        {
            SetupNodeList(i, ref ValueSheet.NodeList,"information",ref ValueSheet.NodeList_UDP_ID);

        }


        for (int i = 0; i < itemDate["information2"].Count; i++)

        {
            SetupNodeList(i, ref ValueSheet.NodeList2, "information2",ref ValueSheet.NodeList2_UDP_ID);

        }

        for (int i = 0; i < itemDate["information3"].Count; i++)

        {
            SetupNodeList(i, ref ValueSheet.NodeList3, "information3", ref ValueSheet.NodeList3_UDP_ID);

        }






        ValueSheet.BGMVolume = float.Parse(itemDate["Setup"][0]["BGMVolume"].ToString());
        ValueSheet.MainVideoUrl =itemDate["Setup"][0]["MainVideUrl"].ToString();

        foreach (var item in ValueSheet.NodeList3)
        {
            //Debug.Log(item.ID);
        }

      

    }

    void SetupNodeList(int i, ref List<Node> nodes,string SectionStr,ref Dictionary<string,int> UDP_ID_dic)
    {
        int id;
        string bigTitle;
        string VideoPath;
        string Udp;


        id = int.Parse(itemDate[SectionStr][i]["id"].ToString());//get id;

        bigTitle = itemDate[SectionStr][i]["BigTitle"].ToString();//get bigtitle;

        VideoPath = itemDate[SectionStr][i]["VideoPath"].ToString();//get video path;

        Udp = itemDate[SectionStr][i]["udp"].ToString();

        Node temp = new Node(id, bigTitle, VideoPath, Udp);

        nodes.Add(temp);

        UDP_ID_dic.Add(Udp, id);
    }
}
