using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAngles : MonoBehaviour {

    public Transform Joint0;
    public Transform Joint1;
    public Transform Joint2;
    public Transform Joint3;
    public Transform Joint4;
    public Transform HAND;

    [Range(0.0f, 180.0f)]
    public float maxAngle;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Joint0.Rotate(Vector3.up, maxAngle);
        Joint1.Rotate(Vector3.up, maxAngle);
        Joint2.Rotate(Vector3.right, maxAngle);
        Joint3.Rotate(Vector3.right, maxAngle);
        Joint4.Rotate(Vector3.down, maxAngle);

        Debug.Log(HAND.position);
    }
}
