using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExB : MonoBehaviour {

    public Transform plane;
    public Transform child;

    

    private Vector3 v1;
    private Vector3 v2;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        v1 = plane.up;
        v2 = child.position;

        Vector3 projection = Vector3.Dot(v2-this.transform.position,v1)*v1;
        Vector3 projectionPoint = (v2-this.transform.position) - projection;

        Vector3 axis = Vector3.Normalize(Vector3.Cross((v2 - this.transform.position), (projectionPoint - this.transform.position)));

        float sin = Vector3.Cross((v2 - this.transform.position), (projectionPoint-this.transform.position)).magnitude;
        float cos = Vector3.Dot((v2 - this.transform.position), (projectionPoint - this.transform.position));
        float angle = Mathf.Atan2(sin, cos);

        Quaternion Quad;
        Quad.w = Mathf.Cos(angle * Mathf.Deg2Rad);
        Quad.x = Mathf.Sin(angle * Mathf.Deg2Rad);
        Quad.y = Mathf.Sin(angle * Mathf.Deg2Rad);
        Quad.z = Mathf.Sin(angle * Mathf.Deg2Rad);

        this.transform.rotation = Quad;

	}
}
