using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 狀態機 : 預設狀態與狀態切換管理
    /// </summary>
    public class StateMachine
    {
        /// <summary>
        /// 當前狀態
        /// </summary>
        private State currentState;

        /// <summary>
        /// 指定當前狀態
        /// </summary>
        /// <param name="defaultState">要指定的預設狀態</param>
        public void DefaultState(State defaultState)
        {
            // 當前狀態 指定為 預設狀態
            currentState = defaultState;
            // 進入 當前狀態
            currentState.Enter();
        }

        /// <summary>
        /// 更新狀態
        /// </summary>
        public void UpdateState()
        {
            // 更新 當前狀態
            currentState.Update();
        }

        /// <summary>
        /// 切換狀態
        /// </summary>
        /// <param name="newState">要切換的新狀態</param>
        public void SwitchState(State newState)
        {
            // 離開 當前狀態
            currentState.Exit();
            // 當前狀態 指定為 新的狀態
            currentState = newState;
            // 進入 當前狀態
            currentState.Enter();
        }
    }
}

