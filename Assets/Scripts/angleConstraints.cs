using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angleConstraints : MonoBehaviour
{
    public bool active;

    [Range(0.0f, 180.0f)]
    public float maxAngle;

    [Range(0.0f, 180.0f)]
    public float minAngle;

    public Transform parent;
    public Transform child;
    private Vector3 v1, v2;
    private Quaternion newRotation;
    private Vector3 e;
    private float angle;


    void Start()
    {
    }

    void LateUpdate()
    {


        Debug.DrawLine(transform.position, transform.position + e, Color.red);
        if (active)
        {
            angle = Mathf.Acos(transform.localRotation.w) * 2.0f;
            Debug.Log(angle * Mathf.Rad2Deg);
            if (angle * Mathf.Rad2Deg > maxAngle)
            {
                Debug.Log("maxangle");
                v1 = parent.position - transform.position;
                v2 = transform.position - child.position;

                e = Vector3.Cross(v1, v2);
                e.Normalize();
                newRotation.w = Mathf.Cos(maxAngle * Mathf.Deg2Rad / 2.0f);
                newRotation.x = Mathf.Sin(maxAngle * Mathf.Deg2Rad / 2.0f) * e.x;
                newRotation.y = Mathf.Sin(maxAngle * Mathf.Deg2Rad / 2.0f) * e.y;
                newRotation.z = Mathf.Sin(maxAngle * Mathf.Deg2Rad / 2.0f) * e.z;

                transform.localRotation = newRotation;
            }

            else if (angle * Mathf.Rad2Deg < minAngle)
            {
                Debug.Log("minangle");
                v1 = parent.position - transform.position;
                v2 = transform.position - child.position;

                e = Vector3.Cross(v1, v2);
                e.Normalize();
                newRotation.w = Mathf.Cos(minAngle * Mathf.Deg2Rad / 2.0f);
                newRotation.x = Mathf.Sin(minAngle * Mathf.Deg2Rad / 2.0f) * e.x;
                newRotation.y = Mathf.Sin(minAngle * Mathf.Deg2Rad / 2.0f) * e.y;
                newRotation.z = Mathf.Sin(minAngle * Mathf.Deg2Rad / 2.0f) * e.z;

                transform.localRotation = newRotation;
            }


        }
    }

    private float ComputeAngle(Vector3 ToParent, Vector3 ToChild)
    {

        return 0.0f;
    }
}