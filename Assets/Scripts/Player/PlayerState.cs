using Unity.VisualScripting;
using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家狀態
    /// </summary>
    public class PlayerState : State
    {
        //建構子 : 實例化時會被呼叫，名稱與類別相同
        public PlayerState(Player _player, StateMachine _stateMachine, string _name)
        {
            player = _player;
            stateMachine = _stateMachine;
            name = _name;
        }
    }

}
