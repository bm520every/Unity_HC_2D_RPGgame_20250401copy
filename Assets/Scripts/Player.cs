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
        [Header("基本資料")]
        [SerializeField, Range(0, 10)]
        private float moveSpeed = 3.5f;
        [SerializeField, Range(0, 20)]
        private int jumpForce = 3;
        [SerializeField]
        private Animator ani;
        [SerializeField]
        private Rigidbody2D rig;
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
        public PlayerIdle playerIdle;
        public PlayerRun playerRun;
        public PlayerJump playerJump;
        public PlayerFall playerFall;
        public PlayerAttack playerAttack;
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
            //實例化狀態機 (產生一個狀態機物件在遊戲內開始執行，與掛在物件上相同)
            stateMachine = new StateMachine();
            playerIdle = new PlayerIdle();
            playerRun = new PlayerRun();
            playerJump = new PlayerJump();
            playerFall = new PlayerFall();
            playerAttack = new PlayerAttack();

            // 狀態機 指定狀態 為 待機
            stateMachine.DefaultState(playerIdle);
        }

        private void Update()
        {
            // 狀態機 更新狀態
            stateMachine.UpdateState();
        }
    }


}
