using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 敵人狀態
    /// </summary>
    public class EnemyState : State
    {
        protected Enemy enemy;

        public EnemyState(Enemy _enemy, StateMachine _stateMachine, string _name)
        {
            enemy = _enemy;
            stateMachine = _stateMachine;
            name = _name;
        }
    }

}
