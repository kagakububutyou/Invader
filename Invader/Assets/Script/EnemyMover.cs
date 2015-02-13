using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour {

    [SerializeField]
    private float Speed = 0.0f;     /// スピード

    private float Right = 1.0f;     /// 右
    private float Left = -1.0f;     /// 左

    private float value = 1.0f;
    private float velocity = 0.0f;  /// 速度

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
        Move();
	}

    /// <summary>
    /// 左右移動
    /// </summary>
    void Move()
    {
        velocity = value * Speed * Time.deltaTime;

        transform.Translate(new Vector3(velocity, 0, 0));
        var scrennPos = Camera.main.WorldToScreenPoint(transform.position);

        /// 右
        if (scrennPos.x <= 0)
        {
            value = Right;
        }

         /// 左
        if (scrennPos.x >= Screen.width)
        {
            value = Left;
        }
    }
}
