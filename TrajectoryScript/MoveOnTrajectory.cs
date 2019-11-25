using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public sealed class MoveOnTrajectory : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreation;
    [SerializeField] private float speed;
    private float distance;

    public PathCreator SetMyPathCreator { set { pathCreation = value; } }
    public PathCreator GetMyPathCreator { get{ return pathCreation; } }
    public float SetSpeed { set { speed = value; } }
    public float GetSpeed { get { return speed; } }

    // Update is called once per frame
    void FixedUpdate()
    {
         distance += speed * Time.deltaTime;
         transform.position = pathCreation.path.GetPointAtDistance(distance);
         transform.rotation = pathCreation.path.GetRotationAtDistance(distance);
    }
}
