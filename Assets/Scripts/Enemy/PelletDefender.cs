using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PelletDefender : MonoBehaviour
{
    public Transform[] points;
    
    public Transform[] player;
    public float detecDis;

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
        while (player.Length > detecDis)
        {
            if (!nav.pathPending && nav.remainingDistance < 0.5f)
            {
                GoToNextPoint();
            }
        }
        if (player.Length <= detecDis)
        {
            AttackPlayer();
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
    void AttackPlayer()
    {
        nav.destination = player[destPoint].position;
    }
}
