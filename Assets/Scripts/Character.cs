using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 角色：翻面與加速度或者角色共通功能
    /// </summary>
    public class Character : MonoBehaviour
    {

        // 唯讀屬性 : 允許外部取得但是不能修改 (保護資料) (不顯示)
        public Animator ani { get; private set; }
        public Rigidbody2D rig { get; private set; }

        protected virtual void Awake()
        {
            //取得此物件身上的 Animator 元件 並存放到 ani 變數
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
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
        public void Flip(float h)
        {
            if (Mathf.Abs(h) < 0.1f) return;
            float angle = h > 0 ? 0 : 180;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }




    }

}

