using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCameraToArea : MonoBehaviour {

    Transform m_transform;
    private float ypos = -5;
    // Use this for initialization

    private void Awake()
    {
        m_transform = GetComponent<Transform>();

    }

    void Start ()
    {

	}
	
    public void AddCamera(ref GameObject cam)
    {
        cam.transform.SetParent(m_transform);
        cam.transform.localPosition = new Vector3(0, ypos, 0);
        ypos -= 10;
        cam.transform.localRotation = Quaternion.identity;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
