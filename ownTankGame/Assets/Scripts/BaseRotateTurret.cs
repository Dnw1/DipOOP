using UnityEngine;
using System.Collections;

public class BaseRotateTurret : MonoBehaviour {
	private Transform[] transforms;
	protected Transform turret;
	protected Vector3 targetPos;
	// Use this for initialization
	protected virtual void Start () {

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
	
	// Update is called once per frame
	protected virtual void Update () {
		turret.LookAt( targetPos );
	}
}
