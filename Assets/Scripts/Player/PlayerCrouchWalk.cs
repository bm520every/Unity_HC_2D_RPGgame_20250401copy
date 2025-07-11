﻿using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家蹲下行走
    /// </summary>
    public class PlayerCrouchWalk : PlayerGround
    {
        public PlayerCrouchWalk(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.ani.SetBool("是否蹲下", true);
        }

        public override void Exit()
        {
            base.Exit();
            player.ani.SetBool("是否蹲下", false);

        }

        public override void Update()
        {
            base.Update();

            player.SetVelocity(new Vector2(h * player.crouchSpeed, player.rig.velocity.y));
            // 移動動畫
            player.ani.SetFloat("蹲下移動", Mathf.Abs(h));
            // 翻面
            player.Flip(h);

            // 如果 玩家水平值 等於 0 請就 狀態機 切換到 蹲下狀態
            if (h == 0) stateMachine.SwitchState(player.playerCrouch);
        }
    }
}