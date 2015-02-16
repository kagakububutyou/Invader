
using UnityEngine;
using System.Collections;

public class StartPosition : MonoBehaviour {

    [SerializeField]
    private float width = 0.0f;
    [SerializeField]
    private float height = 0.0f;

    /// <summary>
    /// 開始時の座標
    /// </summary>
	void Start () 
    {
        Vector3 pos;
        pos = Camera.main.ScreenToWorldPoint((new Vector3(transform.lossyScale.x * width, transform.lossyScale.y * height, 0.0f)));

        transform.position = new Vector3(pos.x, pos.y, 0.0f);
	}
}
