using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	//This class controls the minimap camera rendering.

	public Transform Target;
	

	// Update is called once per frame
	void LateUpdate ()
	{
		transform.position = new Vector3(Target.position.x, transform.position.y, Target.position.z);
	}
}
