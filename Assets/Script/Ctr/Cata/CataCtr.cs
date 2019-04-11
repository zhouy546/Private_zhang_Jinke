using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CataCtr : MonoBehaviour {
    public List<CataNode> CataNodes = new List<CataNode>(); 
        public static CataCtr instance;

	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HideAll() {
        foreach (var item in CataNodes)
        {
            item.HideAll();
        }
    }
}
