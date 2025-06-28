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
        public bool playerInArea { get; private set; }

        /// <summary>
        /// 是否在任務前對話過
        /// </summary>
        public bool isTalkingBefore { get; set; }

        public int itemCountCurrent { get; private set; }
        public int itemCountNeed { get; private set; } = 10;

        [SerializeField]
        private Vector3 offsetInteraction;

        private CanvasGroup groupInteraction;
        private WorldToUiPoint uiInteraction;

        private void Awake()
        {
            flowchart = GetComponent<Flowchart>();
            groupInteraction = GameObject.Find("群組_互動介面").GetComponent<CanvasGroup>();
            uiInteraction = GameObject.Find("群組_互動介面").GetComponent<WorldToUiPoint>();
            stateMachine = new StateMachine();
            questBefore = new NpcQuestBefore(this, stateMachine, "NPC 村民_女任務進行前");
            questing = new NpcQuesting(this, stateMachine, "NPC 村民_女任務進行前");
            qusetFinish = new NpcQusetFinish(this, stateMachine, "NPC 村民_女任務進行前");
            stateMachine.DefaultState(questBefore);
        }

        private void Update()
        {
            stateMachine.UpdateState();
            //　如果 玩家在範圍內 就更新互動介面座標
            if (playerInArea) uiInteraction.UpdatePoint(transform, offsetInteraction);
#if UNITY_EDITOR
            Test_AddItemCount();
#endif
        }

        // OTE2 觸發事件：有勾選　is Trigger 才能使用
        // Enter 進入時執行
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // 如果 碰到物件標籤是 玩家 就設定為 就設定為玩家在區域內
            if (collision.CompareTag("Player"))
            {
                playerInArea = true;
                SwitchInteractionUI(playerInArea);
            }
           
        }

        // Exit 離開時執行一次
        private void OnTriggerExit2D(Collider2D collision)
        {
            // 如果 碰到物件標籤是 玩家 就設定為 就設定為玩家在區域內
            if (collision.CompareTag("Player"))
            {
                playerInArea = false;
                SwitchInteractionUI(playerInArea);
            }
           
        }

        /// <summary>
        /// 切換互動介面
        /// </summary>
        /// <param name="fadeIn">是否要淡入</param>
        public void SwitchInteractionUI(bool fadeIn)
        {
            //　如果此物件不在階層面板上(停止遊戲或被刪除時) 就跳出
            if(!gameObject.activeInHierarchy) return;
            //　先停止所有協程在啟動避免錯誤
            StopAllCoroutines();
            StartCoroutine(FadeSystem.Fade(groupInteraction, fadeIn));
        }

#if UNITY_EDITOR
        /// <summary>
        /// 測試：添加道具數量
        /// </summary>
        private void Test_AddItemCount()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                itemCountCurrent++;
                Debug.Log($"<color=#7f7>道具數量{itemCountCurrent}</color");
            }
        }
#endif
    }
}
