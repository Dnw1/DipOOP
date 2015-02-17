using UnityEngine;
using System.Collections;

public class Tank : DestructableObject {
	private Transform[] transforms;
	protected Transform turret;
	protected Vector3 targetPos;

	public GameObject bulletPrefab;
	private GameObject Turret;
	private GameObject nozzle;
	// Use this for initialization
	void Start () {
		aimTurret ();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		findNozzleTurret ();
		aimTurret();
		firedBullet ();

		turret.LookAt( targetPos );
	}

	void findNozzleTurret() {
		Transform[] transforms = GetComponentsInChildren<Transform>();
		foreach(Transform t in transforms)
		{
			if(t.gameObject.name == "turret")
			{
				Turret = t.gameObject;
			}
			if(t.gameObject.name == "nozzle")
			{
				nozzle = t.gameObject;
			}
		}
	}

	void aimTurret() {
		bool turretFound = false;
		transforms = gameObject.GetComponentsInChildren<Transform>();
		foreach(Transform t in transforms)
		{
			if (t.gameObject.name == "turret")
			{
				turret = t;
				turretFound = true;
			}
		}
		
		if (!turretFound) 
		{
			print ("No turret was found in gameobject.");
		}
	}

	void firedBullet() {
		if (Input.GetButtonDown("Fire1"))
		{
			Quaternion rotation = Quaternion.Euler(Vector3.up * Turret.transform.rotation.eulerAngles.y);
			
			Instantiate(bulletPrefab, nozzle.transform.position, rotation);
		}
	}
}
