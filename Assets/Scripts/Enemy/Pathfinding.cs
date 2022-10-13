using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public Transform[] points;

    private NavMeshAgent nav;
    [HideInInspector]
    public int destPoint;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }
    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        nav.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}
