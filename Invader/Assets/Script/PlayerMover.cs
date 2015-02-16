using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

    [SerializeField]
    private float Speed = 0.0f;     /// スピード
    [SerializeField]
    private float Range = 0.0f;     /// 範囲上限                                 

    private float Right = 1.0f;     /// 右
    private float Left = -1.0f;     /// 左

    private float value = 0.0f;
    private float velocity = 0.0f;

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
        Move();
        RangeControl();
    }
    /// <summary>
    /// 左右移動
    /// </summary>
    void Move()
    {
        value = Input.GetAxisRaw("Horizontal");
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
        /// 右
        if (scrennPos.x <= -scrennScale.x * Screen.width / Range)
        {
            PushBack(-scrennScale.x * Screen.width / Range, Right);
        }

        /// 左
        if (scrennPos.x >= Screen.width + scrennScale.x * Screen.width / Range)
        {
            PushBack(Screen.width + scrennScale.x * Screen.width / Range, Left);
        }
    }
    /// <summary>
    /// 壁にあたったら戻す
    /// </summary>
    /// <param name="pos">座標</param>
    /// <param name="direction">方向</param>
    void PushBack(float pos,float direction)
    {
        /// 関数化する
        var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(pos, 0, 0));
        transform.position = new Vector3(worldPos.x, transform.position.y, 0);
        if (value == direction)
        {
            transform.Translate(new Vector3(velocity, 0, 0));
        }
    }
}
