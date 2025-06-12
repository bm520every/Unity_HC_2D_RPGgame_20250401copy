using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// Npc狀態
    /// </summary>
    public class NpcState : State
    {
        protected Npc npc;

        public NpcState(Npc _npc, StateMachine _stateMachine, string _name)
        {
            npc = _npc;
            stateMachine = _stateMachine;
            name = _name;
        }
    }
}
