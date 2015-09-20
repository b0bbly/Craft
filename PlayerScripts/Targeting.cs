using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targeting : MonoBehaviour {

	public List<Transform> targets;

	public Transform selectedTarget;

	private Transform myTransform;

	// Use this for initialization
	void Start () {
		targets = new List<Transform>();
		selectedTarget = null;
		AddAllEnemies();
		myTransform = transform;
	}

	public void AddAllEnemies()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemy in go)
		{
			AddTarget(enemy.transform);
		}
	}

	public void AddTarget(Transform enemy)
	{
		targets.Add(enemy);
	}

	private void SortTargetsByDistance()
	{
		targets.Sort (delegate(Transform t1, Transform t2) 
		{ 
			return Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position));
		});
	}


	private void TargetEnemy()
	{
		if (selectedTarget == null)
		{
			SortTargetsByDistance();
			selectedTarget = targets[0];
		}
		else
		{
			int index = targets.IndexOf(selectedTarget);
			if (index < (targets.Count - 1))
			{
				index++;
			}
			else
			{
				index = 0;
			}
			DeselectTarget();
			selectedTarget = targets[index];
		}
		SelectTarget();   //TODO SelectTarget and Deselecttarget will cause a red circle to appear or disappear around the enemy's feet.
	}

	private void SelectTarget()
	{
		selectedTarget.GetComponent<Renderer>().material.color = Color.red;

		PlayerInput pa = (PlayerInput)GetComponent("PlayerInput");
		pa.target = selectedTarget.gameObject;
	}

	private void DeselectTarget()
	{
		selectedTarget.GetComponent<Renderer>().material.color = Color.blue;
		selectedTarget = null;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			TargetEnemy();
		}
	}
}
