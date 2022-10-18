namespace Enemy
{
    public class WalkState : State
    {
        // constructor
        public WalkState(EnemyScript enemy, StateMachine sm) : base(enemy, sm) { }

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
            enemy.SetIdleState();
            enemy.SetRunState();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}