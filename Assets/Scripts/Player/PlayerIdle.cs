﻿using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家待機
    /// </summary>
    public class PlayerIdle : PlayerGround
    {
        public PlayerIdle(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            // 🔁 再次保證動畫參數切回正常
            player.ani.SetBool("是否蹲下", false);
            player.SetVelocity(Vector2.zero);
            player.ani.SetFloat("移動", 0);
            player.rig.constraints = UnityEngine.RigidbodyConstraints2D.FreezeRotation;
        }

        public override void Exit()
        {
            base.Exit();
            player.rig.constraints = UnityEngine.RigidbodyConstraints2D.FreezeRotation;
        }

        public override void Update()
        {
            base.Update();


            // 如果 不能移動 就跳出
            if (!player.canMove) return;

            // 如果 玩家水平值 不等於 0 請就 狀態機 切換到 跑步狀態
            if (h != 0) stateMachine.SwitchState(player.playerRun);

            if (!player.isCrouching && h != 0)
            {
                stateMachine.SwitchState(player.playerRun);
            }
        }
    }
}