using UnityEngine;

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

        // 宣告區域變數 angle (只能在這個大括號內存取)
        // 當 h 大於 0 角度設定為 0 否則設定為 180
        float angle = h > 0 ? 0 : 180;
        //更新角色的角度 (歐拉角) = 新的 三維向量(X,Y,Z)
        transform.eulerAngles = new Vector3(0, angle, 0);

    }

}
