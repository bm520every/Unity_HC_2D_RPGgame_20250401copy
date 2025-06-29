using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家滑鏟
    /// </summary>
    public class PlayerSlide : PlayerGround
    {

        private float startTime;

        public PlayerSlide(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();

            // 播放動畫、設定速度、記錄時間
            player.ani.SetTrigger("是否滑鏟");
            player.SetVelocity(new Vector3(player.faceDir * player.slideSpeed, player.rig.velocity.y, 0));
            // 可加 invincible timer / 滑鏟聲音等
        }

        public override void Exit()
        {
            base.Exit();
            player.ani.SetBool("isCrouching", true); // ✅ 保險起見補設
        }

        public override void Update()
        {
            base.Update();

            // 經過一段時間後自動回到 Idle
            if (Time.time - startTime > player.slideDuration)
            {
                stateMachine.SwitchState(player.playerIdle);
            }

        }
    }
}