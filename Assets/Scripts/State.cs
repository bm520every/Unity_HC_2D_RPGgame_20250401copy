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
        public void Enter()
        {
            Debug.Log($"<color=f69)>進入 <{name}> 狀態</color>");
        }

        public void Update()
        {
            Debug.Log($"<color=f999)>更新 <{name}> 狀態</color>");

        }

        public void Exit()
        {
            Debug.Log($"<color=f33)>離開 <{name}> 狀態</color>");

        }
    }
}

