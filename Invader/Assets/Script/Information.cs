using UnityEngine;
using System.Collections;

public class Information : MonoBehaviour {

    /// <summary>
    /// 初期化のためにこれを使用してください
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// 更新は、フレームごとに一度と呼ばれている
    /// </summary>
    void Update()
    {
        ScreenSize();
    }

    /// <summary>
    /// 画面の大きさ
    /// 画面の解像度
    /// </summary>
    void ScreenSize()
    {
        Debug.Log(Screen.width + ", " + Screen.height);
    }
}
