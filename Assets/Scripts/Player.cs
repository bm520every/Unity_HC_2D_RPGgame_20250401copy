using UnityEngine;
// 命名空間的作用 : 分類腳本以及避免與其他共同開發者衝突
namespace Mr.Wonderful
{
    /// <summary>
    /// 玩家 : 儲存玩家資料與基本功能
    /// </summary>
    public class Player : MonoBehaviour
    {
        #region 變數
        [field : Header("基本資料")]
        [field : SerializeField, Range(0, 10)]
        public float moveSpeed { get; private set; } = 3.5f;
        [field : SerializeField, Range(0, 20)]
        public int jumpForce { get; private set; } = 3;
        [field: SerializeField, Range(0, 3)]
        public float attackBrekaTime { get; private set; } = 1;
        [field: SerializeField, Range(0, 1)]
        public float[] attackAnimationTime { get; private set; }

        // 唯讀屬性 : 允許外部取得帶是不能修改 (保護資料) (不顯示)
        public Animator ani { get; private set; }
        public Rigidbody2D rig { get; private set; }

        public bool canMove { get; set; } = false;
        public bool canJump { get; set; } = false;
        public bool canAttack { get; set; } = false;


        [Header("檢查地板資料")]
        [SerializeField]
        private Vector3 checkGroundSize = Vector3.one;
        [SerializeField]
        private Vector3 checkGroundOffset;
        [SerializeField]
        private LayerMask layerCanJump;
        #endregion

        #region 狀態資料
        public StateMachine stateMachine;
        public PlayerIdle playerIdle { get; private set; }
        public PlayerRun playerRun { get; private set; }
        public PlayerJump playerJump { get; private set; }
        public PlayerFall playerFall { get; private set; }
        public PlayerAttack playerAttack { get; private set; }
        public PlayerCrouch playerCrouch { get; private set; }
        public PlayerCrouchWalk playerCrouchWalk { get; private set; }
        public PlayerCrouchAttack playerCrouchAttack { get; private set; }
        public PlayerHangFall playerHangFall { get; private set; }
        public PlayerSlide playerSlide { get; private set; }
        public PlayerRoll playerRoll { get; private set; }
        public PlayerVault playerVault { get; private set; }
        public PlayerTurnBack playerTurnBack { get; private set; }
        #endregion
        private void OnDrawGizmos()
        {
            // 1. 決定顏色
            // new Color(紅, 綠, 藍, 透明度) 值 0 ~ 1
            Gizmos.color = new Color(0.5f, 1, 0.5f, 0.5f);
            // 2. 繪製圖式 (各種形狀)
            // 繪製方塊(座標，尺寸)
            // transform.position 此物件的座標
            Gizmos.DrawCube(transform.position + checkGroundOffset, checkGroundSize);
        }

        private void Awake()
        {
            //取得此物件身上的 Animator 元件 並存放到 ani 變數
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();

            //實例化狀態機 (產生一個狀態機物件在遊戲內開始執行，與掛在物件上相同)
            stateMachine = new StateMachine();
            // this 指的是此類別 (在這裡指的是Player)
            playerIdle = new PlayerIdle(this, stateMachine, "玩家待機");
            playerRun = new PlayerRun(this, stateMachine, "玩家跑步");
            playerJump = new PlayerJump(this, stateMachine, "玩家跳躍");
            playerFall = new PlayerFall(this, stateMachine, "玩家落下");
            playerAttack = new PlayerAttack(this, stateMachine, "玩家攻擊");
            playerCrouch = new PlayerCrouch(this, stateMachine, "玩家蹲下");
            playerCrouchWalk = new PlayerCrouchWalk(this, stateMachine, "玩家蹲下行走");
            playerCrouchAttack = new PlayerCrouchAttack(this, stateMachine, "玩家蹲下攻擊");
            playerHangFall = new PlayerHangFall(this, stateMachine, "玩家掛落");
            playerSlide = new PlayerSlide(this, stateMachine, "玩家滑鏟");
            playerRoll = new PlayerRoll(this, stateMachine, "玩家翻滾");
            playerVault = new PlayerVault(this, stateMachine, "玩家翻躍");
            playerTurnBack = new PlayerTurnBack(this, stateMachine, "玩家折返");

            // 狀態機 指定狀態 為 待機
            stateMachine.DefaultState(playerIdle);

            // 測試用 : 可以控制
            TestCanControl();
        }

        private void Update()
        {
            // 狀態機 更新狀態
            stateMachine.UpdateState();

           // Debug.Log($"<color=#ff9>是否碰到地板:{IsGrounded()}</color>");
        }

        /// <summary>
        /// 設定加速度
        /// </summary>
        /// <param name="velocity">加速度</param>
        public void SetVelocity(Vector3 velocity)
        {
            rig.velocity = velocity;
        }

        /// <summary>
        /// 翻面
        /// </summary>
        /// <param name="h">方向</param>
       
        public bool IsGrounded()
        {
            return Physics2D.OverlapBox(transform.position + checkGroundOffset,
           checkGroundSize, 0, layerCanJump);
        }

        public void Flip(float h)
        {
            if (Mathf.Abs(h) < 0.1f) return;
            float angle = h > 0 ? 0 : 180;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }

        /// <summary>
        /// 測試 : 可以控制移動、跳躍與攻擊
        /// </summary>
        private void TestCanControl()
        {
            canMove = true;
            canJump = true;
            canAttack = true;
        }
    }


}
