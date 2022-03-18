using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{
    // move transform.position -> endPos using Quadratic Bezier Curve
    public List<Vector3> lsPos = new List<Vector3>();
    public Transform posPoint;

    //public float height;
    //public float length;
    public float timeMove;
    private float x = 0;
    public float interpolateRatio;

    // Start is called before the first frame update
    void Start()
    {
        //DrawCurve();
    }

    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime;

        interpolateRatio = x / timeMove;

        if (interpolateRatio <= 1)
        {
            for (int i = 0; i < lsPos.Count; i++)
            {
                lsPos[i] = Lerp(interpolateRatio, lsPos[i], lsPos[i + 1]);
            }

            transform.position = Lerp(interpolateRatio, transform.position,  lsPos[0]);
        }

        Debug.Log("x: " + transform.position.x + "y: " + transform.position.y + "z: " + transform.position.z);
    }


    //private Vector3 MoveWithQuadCurve(float t, List<Transform> lsPos,  Vector3 transform)
    //{
    //    for (int i = 0; i <= lsPos.Count; i++)
    //    {
    //        lsPos[i].position = Lerp(t, lsPos[i].position, lsPos[i + 1].position);
    //    }
    //    transform = Lerp(t, transform, lsPos[1].position);
    //    return transform;
    //}

    private Vector3 Lerp(float t, Vector3 point0, Vector3 point1)
    {
        Vector3 linearCuvre = point0 + t * (point1 - point0);

        return linearCuvre;
    }
}

   