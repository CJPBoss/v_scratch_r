using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadObject : MonoBehaviour {
    
    public GameObject[] objsList;
    public GameObject cam;
    public Transform prefabWorld;
    public Transform objectWorld;
    public RectTransform PrefabsItem;
    public RectTransform destination;
    public RectTransform content;

    private int length;
    public string address;

    // Use this for initialization
    void Start () {
        address = "Objects/";
        content = GameObject.Find("PrefabContenter").GetComponent<RectTransform>();
        LoadPrefabFromFiles();
        length = objsList.Length;
        ShowPrefabsInArea();

    }

    void ShowPrefabsInArea()
    {
        foreach (GameObject i in objsList)
        {
            GameObject temp = Instantiate(i);   //prefab view 
            temp.layer = 9;                     //layer
            GameObject camtemp = Instantiate(cam);  //camera only for prefab
            prefabWorld.GetComponent<AddCameraToArea>().AddCamera(ref camtemp); 
            RenderTexture objTexture = camtemp.GetComponent<PrefabsCamera>().GetObjectImage(ref temp);

            RawImage itemImg = Instantiate(PrefabsItem).GetComponent<RawImage>();
            itemImg.texture = objTexture;
            itemImg.rectTransform.SetParent(content);
            itemImg.transform.localPosition = Vector3.zero;
            itemImg.transform.localScale = Vector3.one;

            itemImg.GetComponent<CreateObjectItem>().prefab = i;
            itemImg.GetComponent<CreateObjectItem>().destination = destination;
            itemImg.GetComponent<CreateObjectItem>().ObjectsArea = objectWorld;
        }
    }

    void LoadPrefabFromFiles()
    {
        objsList = Resources.LoadAll<GameObject>(address);
        foreach (GameObject i in objsList)
        {
            Debug.Log(i.name);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
