using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour {

    [SerializeField]
    private float Speed = 0.0f;     /// スピード
    [SerializeField]
    private float Range = 0.0f;     /// 範囲上限   

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
        RangeControl();
	}

    /// <summary>
    /// 左右移動
    /// </summary>
    void Move()
    {
        velocity = value * Speed * Time.deltaTime;

        transform.Translate(new Vector3(velocity, 0, 0));
        
    }
    /// <summary>
    /// 移動範囲
    /// </summary>
    void RangeControl()
    {
        var scrennPos = Camera.main.WorldToScreenPoint(transform.position);
        var scrennScale = Camera.main.ScreenToWorldPoint(transform.lossyScale);

        Direction(scrennPos, scrennScale);
    }
    /// <summary>
    /// 壁にあたったら方向を変える
    /// </summary>
    /// <param name="pos">座標</param>
    /// <param name="scale">大きさ</param>
    void Direction(Vector3 pos, Vector3 scale)
    {
        /// 右
        if (pos.x <= -scale.x * Screen.width / Range)
        {
            value = Right;
        }

        /// 左
        if (pos.x >= Screen.width + scale.x * Screen.width / Range)
        {
            value = Left;
        }
    }
}
