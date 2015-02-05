using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float Speed = 5.0f;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
	}

    void Move()
    {
        var value = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * value * Speed * Time.deltaTime);
        
    }
}
