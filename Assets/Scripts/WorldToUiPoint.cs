using UnityEngine;

namespace Mr.Wonderful
{
    /// <summary>
    /// 世界座標 (物件座標) 轉為 介面座標
    /// </summary>
    public class WorldToUiPoint : MonoBehaviour
    {
        private RectTransform rect;

        private void Awake()
        {
            rect = GetComponent<RectTransform>();
        }

        /// <summary>
        /// 更新介面座標
        /// </summary>
        /// <param name="target">目標物件</param>
        /// <param name="offset">位移</param>
        public void UpdatePoint(Transform target, Vector3 offset)
        {
            // 計算目標座標與位移 : 目標座標 + 位移
            Vector3 point = target.position + offset;
            // 介面座標 : 透過主要攝影機轉換世界座標為介面座標
            Vector3 uiPoint = Camera.main.WorldToScreenPoint(point);
            // 更新此介面的座標
            rect.position = uiPoint;

        }
    }


}