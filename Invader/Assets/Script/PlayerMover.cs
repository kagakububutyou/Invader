using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

    [SerializeField]
    private float Speed = 0.0f;
    [SerializeField]
    private float hoge = 0.0f;


    /// <summary>
    /// 初期化のためにこれを使用してください
    /// </summary>
    void Start()
    {
        Scale();
        StartPosition();
    }
    /// <summary>
    /// 更新は、フレームごとに一度と呼ばれている
    /// </summary>
    void Update()
    {
        Scale();
        Move();
        print(transform.position);
    }

    /// <summary>
    /// 開始時の座標
    /// </summary>
    void StartPosition()
    {
        transform.position = new Vector3(-Screen.width / 100.0f - transform.lossyScale.x * hoge, 0.0f, 0.0f);
    }
    /// <summary>
    /// 左右移動
    /// </summary>
    void Move()
    {
        //var value = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * value * Speed * Time.deltaTime);

        Vector3 temp;
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        transform.Translate(new Vector3(moveX, 0, 0));
        temp = transform.position;
        temp.x = Mathf.Clamp(temp.x, -Screen.width / 100.0f - transform.lossyScale.x * hoge, Screen.width / 100.0f + transform.lossyScale.x * hoge);
        transform.position = temp;
    }
    void Scale()
    {
        transform.localScale = new Vector3(Screen.width / 1000.0f, Screen.height / 1000.0f , 1);
    }
}
