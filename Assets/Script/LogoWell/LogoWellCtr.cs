using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoWellCtr : MonoBehaviour {
    public List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
    public List<MeshRenderer> NullBlockMeshRenderers = new List<MeshRenderer>();
    List<int> intList = new List<int>();
    public int numPopOut=10;

    public Transform CameraTransPos;

    public static LogoWellCtr instance;
   // public Light light; 

    private List<float> ZmoveDis = new List<float>();
    private void OnEnable()
    {
        if (instance == null) {
            instance = this;
        }
         TurnOnLogoWell();
        DealWithUDPMessage.ToLogoWell += SetTargetPostition;
    }

    private void OnDisable()
    {

        DealWithUDPMessage.ToLogoWell -= SetTargetPostition;
    }



    public void SetTargetPostition() {
       // SetLight();
        foreach (var item in meshRenderers)
        {
            item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y + 15, item.transform.localPosition.z);
        }

        foreach (var item in NullBlockMeshRenderers)
        {
            item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y + 15, item.transform.localPosition.z);
        }




    }




    public void TurnOnLogoWell() {
        StopAllCoroutines();
        //foreach (var item in meshRenderers)
        //{
        //    item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y, -62.25f);
        //}
        this.gameObject.SetActive(true);
        StartCoroutine(Move(1f, .4f));


    }



    public void TurnOffLogoWell()
    {
        this.gameObject.SetActive(false);
        StopAllCoroutines();
    }


    public IEnumerator Move(float time,float waitTime)
    {

        List<int> currentintList = new List<int>();
        currentintList = CreateList();
        int i = 0;

        foreach (var item in currentintList)
        {
            
            yield return new  WaitForSeconds(.04f);
            float z = meshRenderers[item].gameObject.transform.localPosition.z - ZmoveDis[i];
            LeanTween.moveLocalZ(meshRenderers[item].gameObject, z, time);
            i++;
        }

        yield return new WaitForSeconds(time+ waitTime);

        i = 0;
        foreach (var item in currentintList)
        {
            yield return new WaitForSeconds(.04f);
            float z = meshRenderers[item].gameObject.transform.localPosition.z + ZmoveDis[i];
            LeanTween.moveLocalZ(meshRenderers[item].gameObject, z, time);
            i++;
        }
        yield return new WaitForSeconds(time+ waitTime);
        currentintList.Clear();
        
        StartCoroutine(Move(time, waitTime));
    }


    bool keepgoing = true;
    List<int> CreateList() {
        intList.Clear();
        ZmoveDis.Clear();
        for (int i = 0; i < numPopOut; i++)
        {    
        keepgoing = true;
        while (keepgoing) {

            int num = Random.Range(0, meshRenderers.Count - 1);
            float dis = Random.Range(-0.3f, 0f);
                if (!intList.Contains(num))
                {
                    keepgoing = false;
                    intList.Add(num);
                    ZmoveDis.Add(dis);
                }
            }

        }
        return intList;
    }
}
