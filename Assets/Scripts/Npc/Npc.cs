using Fungus;
using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// Npc 腳本 : 管理 Npc 資料與行為
    /// </summary>
    public class Npc : MonoBehaviour
    {
        public StateMachine stateMachine;
        public NpcQuestBefore questBefore { get; private set; }
        public NpcQuesting questing { get; private set; }
        public NpcQusetFinish qusetFinish { get; private set; }

        public Flowchart flowchart { get; private set; }

        private void Awake()
        {
            flowchart = GetComponent<Flowchart>();
            stateMachine = new StateMachine();
            questBefore = new NpcQuestBefore(this, stateMachine, "NPC 村民_女任務進行前");
            questing = new NpcQuesting(this, stateMachine, "NPC 村民_女任務進行前");
            qusetFinish = new NpcQusetFinish(this, stateMachine, "NPC 村民_女任務進行前");
            stateMachine.DefaultState(questBefore);
        }

        private void Update()
        {
            stateMachine.UpdateState();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.name);
        }
    }

}
