using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor.SceneManagement;
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

            // add new states here
            idleState = new IdleState(this, sm);
            walkState = new WalkState(this, sm);
            runState = new RunState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(idleState);
            nav = GetComponent<NavMeshAgent>();
            source = GetComponent<AudioSource>();
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
        }

        public void SetIdleState()
        {
            if (!nav.pathPending && nav.remainingDistance > detecRange)
            {
                sm.ChangeState(idleState);
                GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;
            }
            
        }

        public void SetWalkState()
        {
            if (!nav.pathPending && nav.remainingDistance < detecRange)
            {
                sm.ChangeState(walkState);
                GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 4;
                //nav.destination = player[destPoint].position;

                source.clip = screams[Random.Range(0, screams.Length)];
                source.Play();
            }
        }

        public void SetRunState()
        {
            if (!nav.pathPending && nav.remainingDistance < 5)
            {
                sm.ChangeState(runState);
                GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 8;

                source.clip = screams[Random.Range(0, screams.Length)];
                source.Play();
            }
        }
    }


}
