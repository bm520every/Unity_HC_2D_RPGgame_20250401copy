using UnityEngine;
using System.Collections;

namespace Mr.Wonderful
{
    /// <summary>
    /// 學習協同程序 Coroutine
    /// 作用：讓時間等待
    /// 條件：
    ///     1.　引用 System.Collection;
    ///     2.　宣告傳回 IEnumerator 方法
    ///     3.　方法內使用關鍵字 yield return 等待時間
    ///     4.　使用 StartCoroutine 啟動
    ///     /// </summary>
    public class LearnCoroutine : MonoBehaviour
    {

        private void Awake()
        {
            StartCoroutine(Test());
        }

        private IEnumerator Test()
        {
            Debug.Log("<color=#ff3>第一行</color>");
            yield return new WaitForSeconds(1);
            Debug.Log("<color=#ff3>第二行</color>");
            yield return new WaitForSeconds(2);
            Debug.Log("<color=#ff3>第三行</color>");
            yield return new WaitForSeconds(3);
            Debug.Log("<color=#ff3>第四行</color>");
            yield return new WaitForSeconds(4);
        }
    }
}
