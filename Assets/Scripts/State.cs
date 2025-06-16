using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 狀態 : 包含進入狀態、更新狀態與離開狀態
    /// </summary>
    public class State
    {
        protected string name;

        protected Player player;
        protected StateMachine stateMachine;
        protected float h;

        /// <summary>
        /// 計時器
        /// </summary>
        protected float timer;

        
        
        // virtual 虛擬 : 允許子類別覆寫 (override)
        public virtual void Enter()
        {
            Debug.Log($"<color=f69)>進入 <{name}> 狀態</color>");
            // 計時器歸零
            timer = 0;
        }

        public virtual void Update()
        {
           // Debug.Log($"<color=f999)>更新 <{name}> 狀態</color>");
            h = Input.GetAxis("Horizontal");
            //Time.deltaTime 一個影格的時間
            timer += Time.deltaTime;
        }

        public virtual void Exit()
        {
           // Debug.Log($"<color=f33)>離開 <{name}> 狀態</color>");

        }
    }
}

