using UnityEngine;
namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家攻擊
    /// </summary>
    public class PlayerAttack : State
    {
        /// <summary>
        /// 當前攻擊段數
        /// </summary>
        private int attackIndex;
        /// <summary>
        /// 攻擊最大段數 (與動畫控制器相同)
        /// </summary>
        private float attackIndexMax = 2;
        /// <summary>
        /// 攻擊結束時間
        /// </summary>
        private float attackFinishTime;

        public PlayerAttack(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {

        }

        public override void Enter()
        {
            base.Enter();
            if (Time.time > attackFinishTime + player.attackBrekaTime) attackIndex = 0;
            // 累加攻擊段數
            attackIndex++;
            // 如果 攻擊段數 超過 最大段數 就還原為 1 (循環)
            if (attackIndex > attackIndexMax) attackIndex = 1;
            // 更新攻擊段數動畫參數
            player.ani.SetFloat("攻擊段數", attackIndex);
            player.ani.SetTrigger("觸發攻擊");
            // 凍結剛體全部
            player.rig.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public override void Exit()
        {
            base.Exit();
            // 恢復只勾選 Z 軸
            player.rig.constraints = RigidbodyConstraints2D.FreezeRotation;
            // 紀錄攻擊結束時間
            attackFinishTime = Time.time;

           // Debug.Log($"<color=#f88>攻擊結束時間:{attackFinishTime}</color>");
        }

        public override void Update()
        {
            base.Update();
            Debug.Log($"<color=#ff3>計時器:{timer}</color>");
            // 移動動畫歸零
            player.ani.SetFloat("移動", 0);
            // 如果 計時器 >= 攻擊動畫時間 就切回待機
            if (timer >= player.attackAnimationTime[attackIndex -1])
                stateMachine.SwitchState(player.playerIdle);
        }
    }
}