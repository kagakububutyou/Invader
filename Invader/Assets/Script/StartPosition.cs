
using UnityEngine;
using System.Collections;

public class StartPosition : MonoBehaviour {

    /// <summary>
    /// 開始時の座標
    /// </summary>
	void Start () 
    {
        transform.position = new Vector3(-Screen.width / 100.0f + transform.localScale.x, -Screen.height / 100.0f + transform.localScale.y * Screen.height / 100.0f, 0.0f);
	}
}
