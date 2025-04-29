using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    //變數:儲存遊戲的資料，例如:血量、移動速度等等。
    //變數語法
    //修飾詞 資料類型 變數名稱;
    //ex:(private float moveSpeed;)
    //宣告一個變數，名稱叫做移動速度，類型是浮點數(可存放有小數點資料)
    private float moveSpeed;
    // 單行註解:說明、紀錄
    // 喚醒事件:第一個執行的事件，執行一次
    private void Awake()
    {
        Debug.Log("Hello~");
    }
    // 開始事件:在喚醒後執行一次
    private void Start()
    {
        Debug.Log("<color=red>開始事件</color>");
    }
    // 更新事件:在開始事件後每秒約執行60次
    private void Update()
    {
        Debug.Log("<color=yellow>更新事件</color>");
    }
}
