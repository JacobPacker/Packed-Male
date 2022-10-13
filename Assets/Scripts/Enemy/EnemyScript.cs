using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;

namespace Enemy
{
    public class EnemyScript : MonoBehaviour
    {
        public Rigidbody rb;
        Collider col;
        UnityEngine.AI.NavMeshAgent agent;

        public bool onPlatform;

        public float xv, yv;

        // variables holding the different player states
        public IdleState idleState;

        public StateMachine sm;

        public float inputMagnitude;

        private void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            col = gameObject.AddComponent<Collider>();

            sm = gameObject.AddComponent<StateMachine>();

            // add new states here
            idleState = new IdleState(this, sm);


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
            rb.velocity = new Vector2(xv, yv);
        }

        public void SetIdleState()
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;
        }

        public void SetWalkState()
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 4;

        }

        public void SetRunState()
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 10;

        }
    }


}
