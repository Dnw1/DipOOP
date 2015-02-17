using UnityEngine;
using System.Collections;

public class Player : Tank {

	public float rotationSpeed = 4f;
	public float moveSpeed = 0.3f;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		playerMovement ();
	}

	void FixedUpdate() {
		undoVelocity ();
	}

	void determineWorldPos () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = camera.transform.position.y - turret.transform.position.y;
		
		Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);
		
		targetPos = worldPos;
		
		base.Update();
	}

	void playerMovement () {
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector3.forward * moveSpeed);
			
		}
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.Translate(-Vector3.forward * moveSpeed);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.Rotate(-Vector3.up * rotationSpeed);
		}		
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.Rotate(Vector3.up * rotationSpeed);
		}
	}

	void undoVelocity () {
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
