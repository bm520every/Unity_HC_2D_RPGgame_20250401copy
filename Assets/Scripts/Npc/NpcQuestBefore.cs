using UnityEngine;

namespace Mr.Wonderful
{
    public class NpcQuestBefore : NpcState
    {
        public NpcQuestBefore(Npc _npc, StateMachine _stateMachine, string _name) : base(_npc, _stateMachine, _name)
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
            // 如果 玩家在範圍內 並且 按下 E 鍵 就傳訊息蘑菇
            if (npc.playerInArea && Input.GetKeyDown(KeyCode.E))
            {
                npc.flowchart.SendFungusMessage("任務前");
            }

            //　如果 計時器 > 1 秒 就切換到任務進行中
            // if (timer > 1) stateMachine.SwitchState(npc.questing);

            //　如果 有在任務錢進行對話過 就 切換到任務進行中
            if (npc.isTalkingBefore) stateMachine.SwitchState(npc.questing);
        }
    }
}
