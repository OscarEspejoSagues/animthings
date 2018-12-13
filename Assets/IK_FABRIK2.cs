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

        //las distancias entre joints son siempre las mismas no varian
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
                /*Vector3 vec = copy[i + 1] - copy[i];
                vec.Normalize();
                joints[i].up = vec;*/

                Vector3 a, b;

                a = joints[i + 1].position - joints[i].position;
                b = copy[i + 1] - copy[i];

                Vector3 axis = Vector3.Cross(a, b).normalized;

                float cosa = Vector3.Dot(a, b) / (a.magnitude * b.magnitude);
                float sina = Vector3.Cross(a.normalized, b.normalized).magnitude;

                float alpha = Mathf.Atan2(sina, cosa);

                Quaternion q = new Quaternion(axis.x * Mathf.Sin(alpha / 2), axis.y * Mathf.Sin(alpha / 2), axis.z * Mathf.Sin(alpha / 2), Mathf.Cos(alpha / 2));
                joints[i].position = copy[i];
                joints[i].rotation = q * joints[i].rotation;

            }          
        }
    }

}
