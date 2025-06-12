using UnityEngine;
namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家落下
    /// </summary>
    public class PlayerFall : PlayerState
    {
        public PlayerFall(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.ani.SetFloat("重力", -1);
        }

        public override void Exit()
        {
            base.Exit();
            player.ani.SetBool("是否在地板上", true);
        }

        public override void Update()
        {
            base.Update();


            // 在空中可以控制左右
            player.SetVelocity(new Vector2(h * player.moveSpeed, player.rig.velocity.y));
            player.ani.SetFloat("移動", Mathf.Abs(h));
            player.Flip(h);
            // 如果 碰到地板 就切回待機
            if (player.IsGrounded()) stateMachine.SwitchState(player.playerIdle);
        }
    }
}