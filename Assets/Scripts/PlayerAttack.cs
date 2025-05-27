namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家攻擊
    /// </summary>
    public class PlayerAttack : State
    {
        public PlayerAttack(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }
    }
}