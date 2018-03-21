using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReturnRawImage : MonoBehaviour {

    Transform PrefabsArea;
    public GameObject prefab;
    public GameObject cam;
    Texture rt;
    RawImage rimg;
	// Use this for initialization
	void Start () {
        PrefabsArea = GameObject.Find("PrefabsArea").GetComponent<Transform>();
        rimg = GetComponent<RawImage>();
	}
	
    public void RealTimeImage()
    {
        GameObject c = Instantiate(cam);    //Create Camera
        Debug.Log(c.name);
        GameObject p = Instantiate(prefab);
        Debug.Log(p.name);
        PrefabsArea.GetComponent<AddCameraToArea>().AddCamera(ref c);
        Debug.Log(c.transform.position + "__" + p.transform.position);


        rt = c.GetComponent<PrefabsCamera>().GetObjectImage(ref p);    //get the 
        rimg.texture = rt;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
