using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PelletDefender : MonoBehaviour
{
    public Transform[] points;
    
    public GameObject player;
    public GameObject defender;
    public float distance;

    public float detecDis;

    //public Animator anim;

    private NavMeshAgent nav;
    [HideInInspector]
    public int destPoint;

    public AudioClip[] screams;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        source = GetComponent<AudioSource>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(player.transform.position, defender.transform.position);

        if (distance > detecDis)
        {
            if (!nav.pathPending && nav.remainingDistance < 0.5f)
            {
                GoToNextPoint();
            }
        }
        if (distance <= detecDis)
        {
            FollowPlayer();
        }
        if (distance < 10)
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
        print(nav.destination);
    }
    void FollowPlayer()
    {
        source.clip = screams[Random.Range(0, screams.Length)];
        source.Play();

        nav.destination = player.transform.position;
        print(nav.destination);
    }
    void AttackPlayer()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 10;

        //anim.SetBool("Run", true);
    }
}
