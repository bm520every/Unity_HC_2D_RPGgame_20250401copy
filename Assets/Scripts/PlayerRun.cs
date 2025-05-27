using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家奔跑
    /// </summary>
    public class PlayerRun : PlayerGround
    {
        public PlayerRun(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
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

            // 加速度
            player.SetVelocity(new Vector2(h * player.moveSpeed, player.rig.velocity.y));
            // 移動動畫
            player.ani.SetFloat("移動", Mathf.Abs(h));
            // 翻面
            player.Flip(h);

            // 如果 玩家水平值 等於 0 請就 狀態機 切換到 待機狀態
            if (h == 0) stateMachine.SwitchState(player.playerIdle);

        }
    }
}