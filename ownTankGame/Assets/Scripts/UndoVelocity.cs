using UnityEngine;
using System.Collections;

public class UndoVelocity : MonoBehaviour {
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(rb.velocity != Vector3.zero)
		{
			rb.velocity = Vector3.zero;
		}
		if(rb.angularVelocity != Vector3.zero)
		{
			rb.angularVelocity = Vector3.zero;
		}
	}
}
