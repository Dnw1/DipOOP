using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public GameObject bulletPrefab;
	private GameObject turret;
	private GameObject nozzle;
	// Use this for initialization
	void Start () {
		Transform[] transforms = GetComponentsInChildren<Transform>();
		foreach(Transform t in transforms)
		{
			if(t.gameObject.name == "turret")
			{
				turret = t.gameObject;
			}
			if(t.gameObject.name == "nozzle")
			{
				nozzle = t.gameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	   if (Input.GetButtonDown("Fire1"))
		{
			Quaternion rotation = Quaternion.Euler(Vector3.up * turret.transform.rotation.eulerAngles.y);

			Instantiate(bulletPrefab, nozzle.transform.position, rotation);
		}
	}
}
