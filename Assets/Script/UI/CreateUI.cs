using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour {
    public GameObject[] parent;

    public GameObject NodeL_Default02;
    public GameObject NodeR_Default02;

    public GameObject NodeL_Default;
    public GameObject NodeR_Default;

    public GameObject NodeL_TwoRing;
    public GameObject NodeR_TwoRing;

    public GameObject SunNode_Intro;
    public GameObject SunNode_YeWuMoXing;
    public GameObject SunNode_Co;
    public GameObject SunNode_Matching;

    public GameObject SunNode_Strategy;




    // Use this for initialization
    public void Initialization() {
        CreateDefaultNode();
        CreateDefaultNode2();
        CreateDefaultNode3();
        //CreateIntroNode();
        //CreateYeWuMoXingNode();
        //CreateCoNode();
        //CreateMatchinNode();
        //CreateStrategyNode();
    }



    private void CreateDefaultNode() {
        for (int j = 0; j < ValueSheet.NodeList.Count; j++)
        {
            if (j % 2 == 0)
            {
                Vector3 pos = new Vector3(-20, 16.3f, j * ValueSheet.NodeDistance);

                CreateObject<NodeCtr>(NodeL_Default, j, pos, parent[0], ValueSheet.nodeCtrs);

              
            }
            else
            {
                Vector3 pos = new Vector3(20, 16.3f, j * ValueSheet.NodeDistance);

                CreateObject<NodeCtr>(NodeR_Default, j, pos, parent[0], ValueSheet.nodeCtrs);


            }

            ValueSheet.ID_Node_keyValuePairs.Add(ValueSheet.NodeList[j].ID, ValueSheet.nodeCtrs[j].gameObject);
            ValueSheet.nodeCtrs[j].initialization(ValueSheet.MainUIsprites, ValueSheet.DescriptionkeyValuePairs);
        }
        
        
    }


    private void CreateDefaultNode2() {
        for (int i = 0; i < ValueSheet.NodeList2.Count; i++)
        {
            if (i % 2 == 0)
            {
                Vector3 pos = new Vector3(-20, 16.3f, i * ValueSheet.NodeDistance);
                CreateObject<NodeCtr>(NodeL_Default, i, pos, parent[6], ValueSheet.nodeCtrs2);

            }
            else {
                Vector3 pos = new Vector3(20, 16.3f, i * ValueSheet.NodeDistance);
                CreateObject<NodeCtr>(NodeR_Default, i, pos, parent[6], ValueSheet.nodeCtrs2);
            }

            ValueSheet.ID_Node2_keyValuePairs.Add(ValueSheet.NodeList2[i].ID, ValueSheet.nodeCtrs2[i].gameObject);
            ValueSheet.nodeCtrs2[i].initialization(ValueSheet.MainUI2sprites, ValueSheet.Description2keyValuePairs);

        }
    }

    private void CreateDefaultNode3()
    {
        for (int i = 0; i < ValueSheet.NodeList3.Count; i++)
        {
            if (i % 2 == 0)
            {
                Vector3 pos = new Vector3(-20, 16.3f, i * ValueSheet.NodeDistance);
                CreateObject<NodeCtr>(NodeL_Default02, i, pos, parent[7], ValueSheet.nodeCtrs3);

            }
            else
            {
                Vector3 pos = new Vector3(20, 16.3f, i * ValueSheet.NodeDistance);
                CreateObject<NodeCtr>(NodeR_Default02, i, pos, parent[7], ValueSheet.nodeCtrs3);
            }
            ValueSheet.ID_Node3_keyValuePairs.Add(ValueSheet.NodeList3[i].ID, ValueSheet.nodeCtrs3[i].gameObject);

           // Debug.Log(ValueSheet.nodeCtrs3[i]);
            ValueSheet.nodeCtrs3[i].initialization(ValueSheet.MainUI3sprites, ValueSheet.Description3keyValuePairs);
        }

        //Debug.Log(ValueSheet.nodeCtrs3.Count);
    }



    //private void CreateIntroNode() {
    //    CreateObject<IntroNodeCtr>(SunNode_Intro, 0, Vector3.zero, parent[1], ValueSheet.introNodeCtr);
    //}

    //private void CreateYeWuMoXingNode()
    //{
    //    CreateObject<YeWuMoXingNodeCtr>(SunNode_YeWuMoXing, 0, Vector3.zero, parent[2], ValueSheet.yeWuMoXingNodeCtr);
    //}

    //private void CreateCoNode()
    //{
    //    CreateObject<CoNodeCtr>(SunNode_Co, 0, Vector3.zero, parent[3], ValueSheet.coNodeCtr);
    //}

    //private void CreateMatchinNode()
    //{
    //    CreateObject<MatchingNodeCtr>(SunNode_Matching, 0, Vector3.zero, parent[4], ValueSheet.matchingNodeCtr);
    //}

    //private void CreateStrategyNode()
    //{
    //    CreateObject<StrategyNodeCtr>(SunNode_Strategy, 0, Vector3.zero, parent[5], ValueSheet.strategyNodeCtr);
    //}

    private void CreateObject<t>(GameObject g, int i, Vector3 pos, GameObject parent, List<t> nodeCtr)
    {

        GameObject MgameObject = Instantiate(g);

        MgameObject.name = i.ToString();

        nodeCtr.Add(MgameObject.GetComponent<t>());

        MgameObject.transform.SetParent(parent.transform);

        MgameObject.transform.localPosition = pos;

        MgameObject.transform.rotation = Quaternion.identity;

    }
}
