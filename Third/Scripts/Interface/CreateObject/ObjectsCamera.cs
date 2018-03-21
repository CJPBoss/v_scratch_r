using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCamera : MonoBehaviour
{

    Transform ObjPosition;
    GameObject Obj = null;
    RenderTexture ObjImg = null;
    Camera m_cam;

    private void Awake()
    {
        ObjPosition = GetComponent<Transform>().Find("ObjectPosition");
        m_cam = GetComponent<Camera>();
    }

    // Use this for initialization
    void Start()
    {

    }

    public RenderTexture GetObjImg()
    {
        return ObjImg;
    }

    public RenderTexture GetObjectImage(ref GameObject obj)
    {
        m_cam.targetTexture = new RenderTexture(m_cam.pixelHeight, m_cam.pixelHeight, 10);

        obj.layer = 10;
        obj.transform.SetParent(ObjPosition);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        ObjImg = m_cam.targetTexture;

        return ObjImg;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
