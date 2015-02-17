using UnityEngine;
using System.Collections;

public class Bullet : TempObject {

	public float speed;
	public GameObject explosionPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoveBullet ();
		removeAfterTime ();
	}

	void MoveBullet () {
		transform.Translate (Vector3.forward * speed * delta);
	}

	void OnCollisionEnter(Collision coll) {
		removeOnImpact (coll);
	}

	void removeOnImpact(Collision coll){
		Instantiate (explosionPrefab, this.transform.position, this.transform.rotation);
		Destroy (this.gameObject);
	}
}
