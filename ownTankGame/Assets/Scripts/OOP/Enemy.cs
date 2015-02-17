using UnityEngine;
using System.Collections;

public class Enemy : Tank {

	public Transform player;
	private float reloadTime;
	public float timeToReload;
	private Transform turret;
	private Transform nozzle;
	public GameObject bulletPrefab;
	public float shootingRange;
	// Use this for initialization
	void Start () {
		determineTarget ();
	}
	
	// Update is called once per frame
	void Update () {
		reloadTimer();
	}

	void determineTarget() {
		reloadTime = 0;
		
		Transform[] transforms = this.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform t in transforms) {
			if(t.gameObject.name == "turret") {
				turret = t;
			}
			
			if(t.gameObject.name == "nozzle"){
				nozzle = t; 
			}
		}

		if (player != null) 
		{
			targetPos = player.position + Vector3.up * 1.33f;	    
			base.Update ();
		}
	} 

	void checkIfSeesPlayer() {
		Ray myRay = new Ray();
		myRay.origin = turret.position;
		myRay.direction = turret.forward;
		
		RaycastHit hitInfo;
		
		if (Physics.Raycast (myRay, out hitInfo, shootingRange)) {
			
			string hitObjectName = hitInfo.collider.gameObject.name;
			
			
			if (hitObjectName == "Tank"){
				Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);
				
				reloadTime = 0;
				
			}
		}
	}

	void reloadTimer() {
		reloadTime += Time.deltaTime;
		if (reloadTime >= timeToReload) {
			checkIfSeesPlayer();
		}
	}
}
