using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家地面狀態 : 可以從地面進入跳躍、攻擊、蹲下、滑鏟等狀態
    /// </summary>
    public class PlayerGround : PlayerState
    {
        private bool crouchToggle = false;
        private float lastCPressTime = 0f;

        public PlayerGround(Player _player, StateMachine _stateMachine, string _name)
            : base(_player, _stateMachine, _name)
        {
        }

        public override void Update()
        {
            base.Update();

            bool isGrounded = player.IsGrounded();

            // ✅ 若角色離地 → 進入落下狀態
            if (!isGrounded)
            {
                stateMachine.SwitchState(player.playerFall);
                return;
            }

            // ✅ 按空白鍵 → 跳躍
            if (player.canJump && Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.SwitchState(player.playerJump);
                return;
            }

            // ✅ 按左鍵 → 攻擊
            if (player.canAttack && Input.GetKeyDown(KeyCode.Mouse0))
            {
                stateMachine.SwitchState(player.playerAttack);
                return;
            }

            // ✅ 滑鏟：跑步中 + 按下 ↓/S 鍵觸發
            if (player.IsRunning && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                stateMachine.SwitchState(player.playerSlide);
                return;
            }

            // ✅ C 鍵切換蹲下狀態（可靜止或移動）
            if (Input.GetKeyDown(KeyCode.C))
            {
                crouchToggle = !crouchToggle;

                if (crouchToggle)
                    stateMachine.SwitchState(player.playerCrouch);
                else
                    stateMachine.SwitchState(player.playerIdle);
            }
        }
    }
}
