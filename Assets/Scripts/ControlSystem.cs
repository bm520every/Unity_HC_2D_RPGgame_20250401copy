using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class ControlSystem : MonoBehaviour
{
    //變數:儲存遊戲的資料，例如:血量、移動速度等等。
    //變數語法
    //修飾詞 資料類型 變數名稱;
    //ex:(private float moveSpeed;)
    //宣告一個變數，名稱叫做移動速度，類型是浮點數(可存放有小數點資料)
    //私人 private:僅限此腳本存取此變數，隱藏在面板上 (預設)
    //序列化欄位:將私人變數顯示在面板
    //範圍 Range:限制數值變數最大最小值
    //標題 Header:添加標題在屬性面板
    [Header("基本資料")]
    [SerializeField, Range(0,10)]
    private float moveSpeed = 3.5f;
    [SerializeField, Range(0,20)]
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

    // 繪製圖式事件 ODG 快速完成
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

    private void Update()
    {
        // Input 只能在 Game 輸入並要用英文輸入法
        // 浮點數 名稱 = 輸入 的 取得軸向(軸向名稱)
        // Horizontal 水平 : 獲得左右與 AD 兩組按鍵的輸入
        // 左或A -1 | 右或D 1 | 沒按 0
        float h = Input.GetAxis("Horizontal");
        //Debug.Log($"水平值:{h}");

        // 剛體 的 加速度=新的二維向量(X,Y)
        rig.velocity = new Vector2(h*moveSpeed, rig.velocity.y);

        // 動畫 的 設定浮點數(參數，值) - ani.SetFloat(,)
        // 數學函式 的 絕對值(數值) - Mathf.Abs()
        ani.SetFloat("移動", Mathf.Abs(h));

        // 布林值 有沒有碰撞 2D 物理 的 方形覆蓋(座標,尺寸,角度,圖層)
        bool isGrounded = Physics2D.OverlapBox(transform.position + checkGroundOffset, 
            checkGroundSize, 0, layerCanJump);

        ani.SetBool("是否在地板上", isGrounded);
        ani.SetFloat("重力", rig.velocity.y);

        // Debug.Log($"<color=f#33>是否碰到地板:{isGrounded}</color>");

        // 如果 在地板上 並且 按下空白建 就往上跳 (剛體的加速度)
        // && 並且 Shift + 7
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) rig .velocity = new(0, jumpForce);

        // 如果 h 取絕對值 < 0.1f 就 跳出
        // return 跳出 : 不執行下方程式
        //基本寫法 添加判斷式與跳出(輸入 if 從提示列選取會自動完成)
        if (Mathf.Abs(h) < 0.1f)
        {
            return;
        }

        // 判斷式內如果只有一行可以省略大括號
        // ex :  if (Mathf.Abs(h) < 0.1f) return;

        // 宣告區域變數 angle (只能在這個大括號內存取)
        // 當 h 大於 0 角度設定為 0 否則設定為 180
        float angle = h > 0 ? 0 : 180;
        //更新角色的角度 (歐拉角) = 新的 三維向量(X,Y,Z)
        transform.eulerAngles = new Vector3(0, angle, 0);

    }



}
