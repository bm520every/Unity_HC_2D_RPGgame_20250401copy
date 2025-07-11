﻿using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家翻躍
    /// </summary>
    public class PlayerVault : PlayerGround
    {
        public PlayerVault(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
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

        }
    }
}