using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家地面狀態 : 可以從地面進入跳躍與攻擊狀態
    /// </summary>
    public class PlayerGround : State
    {
        public PlayerGround(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
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

            // 如果 玩家在地面上 並且 按空白建 就切換到跳躍狀態
            if (player.IsGrounded() && Input.GetKeyDown(KeyCode.Space))
                stateMachine.SwitchState(player.playerJump);
        }
    }
}