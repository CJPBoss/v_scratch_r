using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallCodeArea : MonoBehaviour {

    public KeyCode CallInterfaceKey = KeyCode.P; //hold  + drop
    public KeyCode HoldInterfaceKey = KeyCode.I; //hold
    public KeyCode DropInterfaceKey = KeyCode.O; //drop
    public Transform player;
    public Transform library;
    private Vector3 localPos = new Vector3(0f, 1f, 0.8f);
    private Quaternion localRot = Quaternion.Euler(30.0f, 0, 0);
    private Transform m_transform;
    private bool isHolding;
	// Use this for initialization
	void Start () {
		if (player != null)
        {
            player = GameObject.Find("Player").GetComponent<Transform>();
        }
        if (library != null)
        {
            library = GameObject.Find("Library").GetComponent<Transform>();
        }
        m_transform = GetComponent<Transform>();
        HoldInterface();
        DropInterface();
        isHolding = false;
        Debug.Log(localRot.x + ", " + localRot.y + ", " + localRot.z + ", " + localRot.w);
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInterfacePosition();
	}

    void ProcessInterfacePosition()
    {
        if (Input.GetKey(CallInterfaceKey))
        {
            if (!isHolding)
            {
                HoldInterface();
            }
            DropInterface();
            isHolding = false;
        }
        else if(Input.GetKey(HoldInterfaceKey))
        {
            if (!isHolding)
            {
                HoldInterface();
                isHolding = true;
            }
        }
        else if(Input.GetKey(DropInterfaceKey))
        {
            if (isHolding)
            {
                DropInterface();
                isHolding = false;
            }
        }
    }

    void HoldInterface()
    {
        m_transform.SetParent(player);
        m_transform.localPosition = localPos;
        m_transform.localRotation = localRot;
    }

    void DropInterface()
    {
        m_transform.SetParent(library);
    }
}
