using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObjectItem : MonoBehaviour {

    public GameObject prefab;
    public GameObject item;
    public RectTransform destination;
    public Transform ObjectsArea;
    public GameObject cam;

    public GameObject obj;
    public GameObject objViewer;
    public GameObject camera;

    public void CreateObjectToWorld()
    {
        obj = Instantiate(prefab);
        obj.layer = 10;
        camera = Instantiate(cam);
        RenderTexture rt = camera.GetComponent<ObjectsCamera>().GetObjectImage(ref obj);
        objViewer = Instantiate(item);
        objViewer.transform.SetParent(destination);
        objViewer.transform.localPosition = Vector3.zero;
        objViewer.GetComponent<RawImage>().texture = rt;
        objViewer.transform.localScale = Vector3.one;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
