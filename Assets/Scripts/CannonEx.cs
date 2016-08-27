using UnityEngine;
using System.Collections;

public class CannonEx : MonoBehaviour {

    public GameObject Bullet;

        int _rotate_x = 0;

	// Use this for initialization
	void Start () {
        //
	}



	// Update is called once per frame
	void Update () {
	
	Vector3 position = transform.position;
	Quaternion rotation = transform.rotation;

		// 左に移動
		if (Input.GetKey(KeyCode.LeftArrow) ) {
			position.x -= 0.1f;
		}
		// 右に移動
		if (Input.GetKey(KeyCode.RightArrow) ) {
			position.x += 0.1f;
		}

		_rotate_x += 1;
/*
// 勝手にくるくる回ることにする
		// 上に回転
		if (Input.GetKey(KeyCode.UpArrow)) {
			rotation.x -= 0.01f;
			_rotate_x -= 1;
	
		}
		// 下に回転
		if (Input.GetKey(KeyCode.DownArrow)) {
			rotation.x += 0.01f;
			_rotate_x += 1;

		}
*/
		_rotate_x = _rotate_x % 360;


		transform.rotation = Quaternion.AngleAxis(_rotate_x, Vector3.left);

		// スマホの加速度センサー
		var dir = Vector3.zero;
		dir.x = Input.acceleration.x;
		dir.y = Input.acceleration.z;

		Debug.Log ("y" + dir.y);
		// clamp acceleration vector to the unit sphere
		if (dir.sqrMagnitude > 1)
			dir.Normalize();
		rotation.x += dir.y/5  ; 
		position.x += dir.x/20;
		// 移動範囲を制限
		if(position.x <-6){
			position.x =-6 ;
		}
		if(position.x >6){
			position.x = 6 ;
		}
		// 冗長しているがとりあえず
		transform.position = position;
		//transform.rotation = rotation;




		// 弾を発射
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton (0)) {
			GameObject f_bullet = GameObject.FindGameObjectWithTag("Bullet"); //弾が存在するか
			//弾がないときのみ発射！！ 連射防止
			if(f_bullet ==null){
				Vector3 forward  = transform.forward;
				Vector3 shot_position = transform.position + forward;
				GameObject bulletObj = Instantiate(Bullet, shot_position, Quaternion.identity) as GameObject;
				BulletEx bullet      = bulletObj.GetComponent<BulletEx>();
				Vector3 force = forward * 10f; //物体が向いている方向
				bullet.Shot(force);
				Destroy(bullet,5); 
			}
		}
	}



}
