namespace Enemy
{
    public class RunState : State
    {
        // constructor
        public RunState(EnemyScript enemy, StateMachine sm) : base(enemy, sm) { }

        public override void Enter()
        {
            base.Enter();

        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            enemy.SetWalkState();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}

