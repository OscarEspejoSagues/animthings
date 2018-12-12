using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IK_FABRIK2 : MonoBehaviour
{
    public Transform[] joints;
    public Transform target;

    private Vector3[] copy;
    private float[] distances;
    private bool done;

    private float tolerance;

    void Start()
    {
        distances = new float[joints.Length - 1];
        copy = new Vector3[joints.Length];

        for (int i = 0; i < distances.Length; i++)
        {
            distances[i] = (joints[i].position - joints[i + 1].position).magnitude;
        }

        done = false;

        tolerance = 0.001f;
    }

    void Update()
    {
        // Copy the joints positions to work with
        //TODO

        for(int i = 0; i < joints.Length; i++)
        {
            copy[i] = joints[i].position;
        }

        //done = TODO
        if (!done)
        {
            float targetRootDist = Vector3.Distance(copy[0], target.position);

            // Update joint positions
            if (targetRootDist > distances.Sum())
            {
                // The target is unreachable
                for (int i = 0; i < copy.Length - 1; i++)
                {
                    float r = (target.position - copy[i]).magnitude;
                    float lambda = distances[i] / r;
                    copy[i + 1] = (1 - lambda) * copy[i] + lambda * target.position;

                }
            }
            else
            {
                // The target is reachable
                Vector3 b = copy[0];
                float difA = (copy[copy.Length - 1] - target.position).magnitude;
                //while (TODO)
                while(difA > tolerance)
                {
                    // STAGE 1: FORWARD REACHING
                    //TODO
                    copy[copy.Length - 1] = target.position;

                    for(int i = copy.Length - 2; i >= 0; i--)
                    {
                        float r = (copy[i + 1] - copy[i]).magnitude;
                        float lambda = distances[i] / r;
                        copy[i] = (1 - lambda) * copy[i + 1] + lambda * copy[i];
                    }

                    // STAGE 2: BACKWARD REACHING
                    //TODO
                    copy[0] = b;

                    for(int i = 0; i < copy.Length - 1; i++)
                    {
                        float r = (copy[i + 1] - copy[i]).magnitude;
                        float lambda = distances[i] / r;
                        copy[i + 1] = (1 - lambda) * copy[i] + lambda * copy[i + 1];
                    }
                    difA = (copy[copy.Length - 1] - target.position).magnitude;
                }
            }

            // Update original joint rotations
            for (int i = 0; i <= joints.Length - 2; i++)
            {
                //TODO 
                float angle = Vector3.Angle(joints[i + 1].position - joints[i].position, copy[i + 1] - joints[i].position);
                Vector3 axis = Vector3.Cross(joints[i + 1].position - joints[i].position, copy[i + 1] - joints[i].position);
                Debug.Log("rotation to apply to first joint is: " + angle);
                joints[i].rotation = Quaternion.AngleAxis(angle, axis);

            }          
        }
    }

}
