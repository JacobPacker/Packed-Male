using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyScript : MonoBehaviour
    {
        UnityEngine.AI.NavMeshAgent agent;

        // variables holding the different player states
        public IdleState idleState;
        public WalkState walkState;
        public RunState runState;

        public StateMachine sm;

        public GameObject player;
        public GameObject defender;
        public float distance;

        private NavMeshAgent nav;

        public float detecRange;

        public AudioClip[] screams;
        public AudioSource source;

        [HideInInspector]
        public int destPoint;

        // Start is called before the first frame update
        void Start()
        {
            sm = gameObject.AddComponent<StateMachine>();
            nav = GetComponent<NavMeshAgent>();
            source = GetComponent<AudioSource>();

            // add new states here
            idleState = new IdleState(this, sm);
            walkState = new WalkState(this, sm);
            runState = new RunState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(idleState);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.HandleInput();
            sm.CurrentState.LogicUpdate();
        }

        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
            distance = Vector3.Distance(player.transform.position, defender.transform.position);
        }

        public void SetIdleState()
        {

            if (!nav.pathPending && distance > detecRange)
            {
                GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;

                sm.ChangeState(idleState);
            }
            
        }

        public void SetWalkState()
        {

            if (!nav.pathPending && distance <= detecRange && distance >= 15)
            {
                GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 4;

                nav.destination = player.transform.position;

                source.clip = screams[Random.Range(0, screams.Length)];
                source.Play();

                sm.ChangeState(walkState);
            }
        }

        public void SetRunState()
        {
            if (!nav.pathPending && distance < 15)
            {
                GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 8;

                nav.destination = player.transform.position;

                source.clip = screams[Random.Range(0, screams.Length)];
                source.Play();

                sm.ChangeState(runState);
            }
        }
    }


}
