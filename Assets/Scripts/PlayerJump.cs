using UnityEngine;
namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家跳躍
    /// </summary>
    public class PlayerJump : State
    {
        public PlayerJump(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocity(new Vector3(player.rig.velocity.x, player.jumpForce));
            player.ani.SetBool("是否在地板上", false);
            player.ani.SetFloat("重力", 1);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            // 如果 剛體加速度的 Y 小於 0 就 切換到落下狀態
            if (player.rig.velocity.y < 0) stateMachine.SwitchState(player.playerFall);
        }
    }
}