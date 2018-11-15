using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExB : MonoBehaviour {

    public Transform plane;
    public Transform child;

    

    private Vector3 planeNormal;
    private Vector3 childPosition;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
        planeNormal = plane.up;
        childPosition = child.position;

        float projectionValue = Vector3.Dot(childPosition-this.transform.position, plane.position + planeNormal);
        Vector3 projection = projectionValue * planeNormal;

        Debug.Log(projectionValue);
        Vector3 projectionPoint = (childPosition-this.transform.position) - projection;

        Debug.DrawLine(transform.position, projectionPoint, Color.yellow);

        Vector3 axis = Vector3.Normalize(Vector3.Cross((childPosition - this.transform.position), (projectionPoint - this.transform.position)));

        float sin = Vector3.Cross((childPosition - this.transform.position), (projectionPoint-this.transform.position)).magnitude;
        float cos = Vector3.Dot((childPosition - this.transform.position), (projectionPoint - this.transform.position));
        float angle = Mathf.Atan2(sin, cos);

        Quaternion Quad;
        Quad.w = Mathf.Cos(angle * Mathf.Deg2Rad);
        Quad.x = Mathf.Sin(angle * Mathf.Deg2Rad);
        Quad.y = Mathf.Sin(angle * Mathf.Deg2Rad);
        Quad.z = Mathf.Sin(angle * Mathf.Deg2Rad);

        this.transform.rotation = Quad;

	}
}
