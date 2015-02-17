using UnityEngine;
using System.Collections;

public class TempObject : MonoBehaviour {

	public float delta = Time.deltaTime;
	public float lifeTime = 0f;
	public float maxLifeTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void removeAfterTime() {
		lifeTime += delta;
		if (lifeTime > maxLifeTime) {
			Destroy(this.gameObject);
		}
	}
}
