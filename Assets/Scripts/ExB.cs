using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExB : MonoBehaviour {

    public Transform plane;
    

    private Vector3 v1;
    private Vector3 v2;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        v1 = plane.up;
        
	}
}
