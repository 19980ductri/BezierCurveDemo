using System.Collections.Generic;
using UnityEngine;

public class CubicBezierCurve : MonoBehaviour
{

    public List<Vector3> lsPoints = new List<Vector3>();

    public float timeMove;
    float x = 0;
    float t;

    public float speed;

    public Vector3 gizMosPos;


    public bool jump = false;
    


    private void Awake()
    {

    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        x = x + Time.fixedDeltaTime;
        t = x / timeMove;
        if (t >= 1)
        {
            t = 1;
        }

        
        CheckJump();
        if (jump == true)
        {
            BezierMove();
        }

    }

    public void BezierMove()
    {
        for (int i = 0; i < lsPoints.Count - 1; i++)
        {
            lsPoints[i] = Vector3.MoveTowards(lsPoints[i], lsPoints[i + 1], Vector3.Distance(lsPoints[i], lsPoints[i + 1]) * Time.fixedDeltaTime);
        }
        transform.position = Vector3.MoveTowards(transform.position, lsPoints[0], Vector3.Distance(transform.position, lsPoints[0]) * Time.fixedDeltaTime);
    }

    public void CheckJump()
    {
        if ( Vector3.Distance(transform.position,lsPoints[lsPoints.Count - 1]) <= 0.1 )
        {
            jump = false;
            transform.position = lsPoints[lsPoints.Count - 1];
            
        }
        else
        {
            jump = true;
        }
    }



}

