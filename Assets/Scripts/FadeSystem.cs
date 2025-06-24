using UnityEngine;
using System.Collections;

namespace Mr.Wonderful
{
    public class FadeSystem : MonoBehaviour
    {
        //　static 讓該成員不需要掛在物件上或實例化就可以用
        //使用方式：類別名稱.方法名稱 ex：FadeSystem.Fade
        /// <summary>
        /// 淡出淡入
        /// </summary>
        /// <param name="group">畫布群組元件</param>
        /// <param name="fadeIn">是否淡入</param>
        /// <returns></returns>
        public static IEnumerator Fade(CanvasGroup group, bool fadeIn = true)
        {
            //　增加值：是否淡入，是 +0.1，否 -0.1
            float increase = fadeIn ? +0.1f : -0.1f;

            //迴圈重複執行 10 次
            for (int i = 0; i < 10; i++)
            {
                //　更新畫布群組 的 透明度 每次遞增
                group.alpha += increase;
                //　等待 0.03 秒
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}
