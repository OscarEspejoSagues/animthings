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
    public Transform child02;
    public Transform original;


    void Start()
    {

    }

    void Update()
    {
       
           

        if (active)
        {
            //solve your exercise here
            //parent.Rotate(Vector3.right, 1.2f);
            //child.Rotate(Vector3.up, 1.4f);
            //child02.Rotate(Vector3.forward, 0.3f);
            // if (child.transform.rotation.eulerAngles.y <= 90 && child.transform.rotation.eulerAngles.y >= 0)

            float angle = 2 * Mathf.Acos(child.rotation.w);
            //Debug.Log(angle);

            float comp0 = Mathf.Cos(angle / 2);//definicion del angulo teta
            float comp1 = child.rotation.x * Mathf.Sin(angle / 2);
            float comp2 = child.rotation.y * Mathf.Sin(angle / 2);
            float comp3 = child.rotation.z * Mathf.Sin(angle / 2);

            Vector4 Axis = new Vector4(comp0, comp1, comp2, comp3);
            Debug.Log(Axis);
            if (comp0 > 0.3 && comp0 <= 0.7)
            {
                transform.localRotation = original.transform.localRotation;
            }

           
        }
    }

    //add auxiliary functions, if needed, below




}
