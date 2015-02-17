using UnityEngine;
using System.Collections;

public class RotateTurret : BaseRotateTurret {

	public Camera camera;

	// Update is called once per frame
	override protected void Update () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = camera.transform.position.y - turret.transform.position.y;

		Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);

		targetPos = worldPos;

		base.Update();
	}
}
