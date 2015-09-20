using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxDistance;

	private Transform myTransform;
	private bool hasTarget = false;

	void Awake(){
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {

		//TODO BELOW
		//change the below to be able to target anything alive and unfriendly?
		GameObject go = GameObject.FindGameObjectWithTag("Player");

		//TODO BELOW
		//check if player in range and in LOS and within level boundaries
		if ((Vector3.Distance(go.transform.position, myTransform.position) < 10))
		    {
			hasTarget = true;
			target = go.transform;
		}

		maxDistance = 2;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		//TODO BELOW
		//check if player in range and in LOS and within level boundaries
		if (!hasTarget)
		{
			if ((Vector3.Distance(go.transform.position, myTransform.position) < 10))
			{
				hasTarget = true;
				target = go.transform;
			}
		}

		if (hasTarget)
		{
			Debug.DrawLine(target.position, myTransform.position, Color.yellow);
		
			//look at target
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

			//move to target

			if ((Vector3.Distance(go.transform.position, myTransform.position) > maxDistance))
			{
				myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			}
		}
	}
}
