using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour {
    public GameObject[] parent;

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
        CreateIntroNode();
        CreateYeWuMoXingNode();
        CreateCoNode();
        CreateMatchinNode();
        CreateStrategyNode();
    }



    private void CreateDefaultNode() {
        for (int j = 0; j < ValueSheet.NodeList.Count; j++)
        {
            if (j % 2 == 0)
            {
                Vector3 pos = new Vector3(-20, 16.3f, j * ValueSheet.NodeDistance);
                if (j == 0 || j == 2)
                {
                    CreateObject<NodeCtr>(NodeL_TwoRing, j, pos, parent[0], ValueSheet.nodeCtrs);
                }
                else {
                    CreateObject<NodeCtr>(NodeL_Default, j, pos, parent[0], ValueSheet.nodeCtrs);
                }

              
            }
            else
            {
                Vector3 pos = new Vector3(20, 16.3f, j * ValueSheet.NodeDistance);

                if (j == 1)
                {
                    CreateObject<NodeCtr>(NodeR_TwoRing, j, pos, parent[0], ValueSheet.nodeCtrs);
                }
                else
                {
                    CreateObject<NodeCtr>(NodeR_Default, j, pos, parent[0], ValueSheet.nodeCtrs);
                }

            }
            ValueSheet.ID_Node_keyValuePairs.Add(ValueSheet.NodeList[j].ID, ValueSheet.nodeCtrs[j].gameObject);
        }
    }

    private void CreateIntroNode() {
        CreateObject<IntroNodeCtr>(SunNode_Intro, 0, Vector3.zero, parent[1], ValueSheet.introNodeCtr);
    }

    private void CreateYeWuMoXingNode()
    {
        CreateObject<YeWuMoXingNodeCtr>(SunNode_YeWuMoXing, 0, Vector3.zero, parent[2], ValueSheet.yeWuMoXingNodeCtr);
    }

    private void CreateCoNode()
    {
        CreateObject<CoNodeCtr>(SunNode_Co, 0, Vector3.zero, parent[3], ValueSheet.coNodeCtr);
    }

    private void CreateMatchinNode()
    {
        CreateObject<MatchingNodeCtr>(SunNode_Matching, 0, Vector3.zero, parent[4], ValueSheet.matchingNodeCtr);
    }

    private void CreateStrategyNode()
    {
        CreateObject<StrategyNodeCtr>(SunNode_Strategy, 0, Vector3.zero, parent[5], ValueSheet.strategyNodeCtr);
    }

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
