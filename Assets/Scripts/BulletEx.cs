using UnityEngine;
using System.Collections;

public class BulletEx : MonoBehaviour {

    public GameObject Detonator;

   //画面外になった自動的に消滅する
   void OnBecameInvisible()
  {
	Debug.Log("OnBecameInvisible");	
	Destroy (this.gameObject);
   }
    // 発射
    public void Shot(Vector3 force)
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(force, ForceMode.Impulse);
    }

    // 他のオブジェクトとぶつかったときの処理
    void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.tag == "block") {
			Destroy (other.gameObject);//ブッロクを消す 
		} 
		GameObject detonator = Instantiate(Detonator, transform.position, Quaternion.identity) as GameObject;// 爆発
		Destroy(gameObject); //消滅
		Destroy(detonator,3); //爆発の演出後に自己消滅
    }
}
