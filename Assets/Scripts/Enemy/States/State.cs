using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Enemy
{
    public abstract class State
    {
        protected EnemyScript enemy;
        protected StateMachine sm;


        // base constructor
        protected State(EnemyScript enemy, StateMachine sm)
        {
            this.enemy = enemy;
            this.sm = sm;
        }

        // These methods are common to all states
        public virtual void Enter()
        {
            //Debug.Log("This is base.enter");
        }

        public virtual void HandleInput()
        {
            //player.ReadInputKeys();
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {
        }

    }

}