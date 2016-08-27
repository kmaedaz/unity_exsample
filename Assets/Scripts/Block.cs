using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {



	float vx =1;
	float speed = 0.025f;


	//開始時の移動速度
	public float StartSpeed = 0.6f;


	// Use this for initialization
	void Start () {
	
	}

	//画面外になった自動的に消滅する
	void OnBecameInvisible()
	{
		Debug.Log("OnBecameInvisible");	
		Destroy (this.gameObject);
	}

	// トリガーイベントから離脱
	void OnCollisionEnter(Collision other)
	{
		string name = LayerMask.LayerToName(other.gameObject.layer);
		if(name=="wall")
		{
			vx *= -1; //移動方向反転
		}

	}

	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.x += vx *speed;

		transform.position = position;
	}
}
