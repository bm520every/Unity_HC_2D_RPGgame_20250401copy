using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家蹲下
    /// </summary>
    public class PlayerCrouch : PlayerGround
    {
        public PlayerCrouch(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
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
            // 如果 玩家水平值 等於 0 請就 狀態機 切換到 蹲下行走狀態
            if (h == 0) stateMachine.SwitchState(player.playerCrouchWalk);
        }
    }
}