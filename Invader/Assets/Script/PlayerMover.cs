using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

    [SerializeField]
    private float Speed = 0.0f;     /// スピード
   
    private int Right = 1;
    private int Left = -1;

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
    }
    /// <summary>
    /// 左右移動
    /// </summary>
    void Move()
    {
        value = Input.GetAxisRaw("Horizontal");
        velocity = value * Speed * Time.deltaTime;
        var scrennPos = Camera.main.WorldToScreenPoint(transform.position);

        transform.Translate(new Vector3(velocity, 0, 0));
        /// 右
        if (scrennPos.x <= 0)
        {
            PushBack(scrennPos,Right);
        }

        /// 左
        if (scrennPos.x >= Screen.width)
        {
            PushBack(scrennPos,Left);
        }
    }
    /// <summary>
    /// 壁にあたったら戻す
    /// </summary>
    /// <param name="pos">座標</param>
    /// <param name="direction">方向</param>
    void PushBack(Vector3 pos,float direction)
    {
        /// 関数化する
        var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, 0, 0));
        transform.position = new Vector3(worldPos.x, transform.position.y, 0);
        if (value == direction)
        {
            transform.Translate(new Vector3(velocity, 0, 0));
        }
    }
}
