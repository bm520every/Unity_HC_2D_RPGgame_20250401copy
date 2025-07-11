﻿using UnityEngine;

namespace Mr.Wonderful
{
    public class NpcQuesting : NpcState
    {
        public NpcQuesting(Npc _npc, StateMachine _stateMachine, string _name) : base(_npc, _stateMachine, _name)
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

            //　如果 玩家在範圍內 並且 按下 E 鍵 就傳訊息給蘑菇
            if(npc.playerInArea && Input.GetKeyDown(KeyCode.E))
            {
                npc.flowchart.SendFungusMessage("任務中");
            }

            //　如果 玩家當前道具數量　>=　道具需求數量 就切換到任務完成
            if (npc.itemCountCurrent >= npc.itemCountNeed)
                stateMachine.SwitchState(npc.qusetFinish);
        }
    }
}
