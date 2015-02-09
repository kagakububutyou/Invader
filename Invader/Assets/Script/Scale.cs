using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {

    [SerializeField]
    private float Magnification = 0.0f;

    /// <summary>
    /// 初期化のためにこれを使用してください
    /// </summary>
	void Start () 
    {
	
	}

    /// <summary>
    /// 更新は、フレームごとに一度と呼ばれている
    /// </summary>
	void Update () 
    {
        /// 画面の大きさに応じてサイズを変える
        transform.localScale = new Vector3(Screen.width / Magnification, Screen.height / Magnification, 1);
	}
}
