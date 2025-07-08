using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家蹲下攻擊
    /// </summary>
    public class PlayerCrouchAttack : PlayerGround
    {
        public PlayerCrouchAttack(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            // 只有蹲下時可以攻擊
            player.canAttack = player.canCrouch;
            // 這裡可以加入攻擊動畫或攻擊邏輯
        }

        public override void Exit()
        {
            base.Exit();
            // 離開蹲下攻擊時恢復攻擊權限
            player.canAttack = false;
        }

        public override void Update()
        {
            base.Update();
            // 若玩家不再蹲下則不能攻擊，並切換回蹲下狀態
            if (!player.canCrouch)
            {
                stateMachine.SwitchState(player.playerCrouch);
            }
        }
    }
}