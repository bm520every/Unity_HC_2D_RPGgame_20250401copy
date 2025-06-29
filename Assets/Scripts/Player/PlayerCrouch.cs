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
            
            player.ani.SetBool("是否蹲下", true);
            player.rig.constraints = RigidbodyConstraints2D.FreezeRotation;

        }

        public override void Exit()
        {
            base.Exit();
            player.ani.SetBool("是否蹲下", false);
        }

        public override void Update()
        {

            base.Update();

            // 左右移動就切蹲下行走
            if (Mathf.Abs(h) > 0)
                stateMachine.SwitchState(player.playerCrouchWalk);

            // 攻擊鍵
            if (Input.GetMouseButtonDown(0))
                stateMachine.SwitchState(player.playerCrouchAttack);
        }
    }
}