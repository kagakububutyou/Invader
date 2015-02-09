using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

    [SerializeField]
    private float Speed = 0.0f;     /// スピード
    private int Right = 1;
    private int Left = -1;

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
        var value = Input.GetAxisRaw("Horizontal");
        var velocity = value * Speed * Time.deltaTime;
        var screenPlayer = Camera.main.WorldToScreenPoint(transform.position);
        var scalePlayer = Camera.main.WorldToScreenPoint(transform.lossyScale);

        //print(screenPlayer - scalePlayer / 20);
        print(scalePlayer.x/20);

        transform.Translate(new Vector3(velocity, 0, 0));
        /// 右
        if (screenPlayer.x <= 0)
        {
            var screenPos = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));
            transform.position = new Vector3((int)screenPos.x, 0, 0);
            if (value == Right)
            {
                transform.Translate(new Vector3(velocity, 0, 0));
            }
        }
        
        /// 左
        if (screenPlayer.x >= Screen.width)
        {
            var screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
            transform.position = new Vector3((int)screenPos.x, 0, 0);
            if (value == Left)
            {
                transform.Translate(new Vector3(velocity, 0, 0));
            }
        }
        


    }
    /// <summary>
    /// 数値確認用
    /// </summary>
    void OnGUI()
    {
        GUI.Label(new Rect(10,10,100,100),transform.localScale.ToString());
        GUI.Label(new Rect(10, 40, 100, 100), transform.lossyScale.ToString());
        GUI.Label(new Rect(10, 60, 100, 100), transform.position.ToString());
        GUI.Label(new Rect(10, 80, 100, 100), Screen.width.ToString());
        GUI.Label(new Rect(10, 100, 100, 100), Screen.height.ToString());
    }
}
