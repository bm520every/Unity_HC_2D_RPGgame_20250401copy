using UnityEngine;
/// <summary>
/// 狀態 : 包含進入狀態、更新狀態與離開狀態
/// </summary>
namespace Mr.Wonderful
{
    public class State
    {
        public string name;

        protected Player player;
        protected StateMachine stateMachine;
        protected float h;

        //建構子 : 實例化時會被呼叫，名稱與類別相同
        public State(Player _player, StateMachine _stateMachine, string _name)
        {
            player = _player;
            stateMachine = _stateMachine;
            name = _name;
        }
        // virtual 虛擬 : 允許子類別覆寫 (override)
        public virtual void Enter()
        {
            Debug.Log($"<color=f69)>進入 <{name}> 狀態</color>");
        }

        public virtual void Update()
        {
            Debug.Log($"<color=f999)>更新 <{name}> 狀態</color>");
            h = Input.GetAxis("Horizontal");
        }

        public virtual void Exit()
        {
            Debug.Log($"<color=f33)>離開 <{name}> 狀態</color>");

        }
    }
}

