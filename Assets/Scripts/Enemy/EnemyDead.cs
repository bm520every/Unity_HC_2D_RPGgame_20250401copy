using UnityEngine;

namespace Mr.Wonderful
{
    public class EnemyDead : EnemyState
    {
        public EnemyDead(Enemy _enemy, StateMachine _stateMachine, string _name) : base(_enemy, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
        }
    }

}

