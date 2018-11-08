using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentScript : MonoBehaviour
{

    public Transform target1;
    public Transform target2;
    public Transform head;

	public int exercise = 1;

    private Vector3 offsetAxis;
    private Quaternion offset;
    private Quaternion offsetHead;
    private Quaternion offsetEx5;
    private float offsetAngle;

    // Use this for initialization
    void Start ()
    {
        offset = Quaternion.Inverse(transform.rotation) * target2.rotation; //Ex3
        offsetHead = Quaternion.Inverse(transform.rotation) * head.rotation; //Ex4
        offsetEx5 = Quaternion.Inverse(offset);

    }

    void Update()
    {
        switch(exercise)
        {
            case 1:
            {
               offsetAxis = Vector3.Cross(transform.right, target1.right).normalized;
               offsetAngle = -Mathf.Acos(Vector3.Dot(transform.right, target1.right)) * Mathf.Rad2Deg;
               Debug.Log(offsetAxis);
               Debug.Log(offsetAngle);
               target1.Rotate(offsetAxis, offsetAngle, Space.World);
            } break;

          

            case 2:
            {
              offsetAxis = Vector3.Cross(transform.right, target1.right).normalized;
              target1.rotation = Quaternion.Lerp(target1.rotation, target2.rotation, Time.time*0.02f);
            } break;

            case 3:
            {
              target2.rotation = transform.rotation*offset; //conserva su rotacion y luego le añadimos la del otro objecto
            } break;

            case 4:
            {
              head.rotation = transform.rotation * offsetHead;
            } break;

            case 5:
            {
              target1.rotation = transform.rotation * offsetEx5; //conserva su rotacion y luego le añadimos la del otro objecto
              target2.rotation = target1.rotation * offset;
              
            }break;
        }
    }
}
