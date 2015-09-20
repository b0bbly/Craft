using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public GameObject target;

	public float attackTimer;
	public float coolDown;

	// Use this for initialization
	void Start () {
		attackTimer = 0;
		coolDown = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTimer > 0)
		{
			attackTimer -= Time.deltaTime;
		}
		if (attackTimer < 0)
		{
			attackTimer = 0;
		}
		if (Input.GetKeyUp(KeyCode.Alpha1))
		{
			if (attackTimer ==0)
			{
				Attack();
				// attackTimer = coolDown;  //Moved this down to the attack class so cooldown doesn't trigger if you can't attack
			}
		}
	}

	private void Attack()
	{
		if (target.ToString() != "None(UnityEngine.GameObject)")
		{
			float distance = Vector3.Distance(target.transform.position, transform.position);
			Vector3 dir = (target.transform.position - transform.position).normalized;

			float direction = Vector3.Dot(dir, transform.forward);

			if (distance < 2.5f) {  //checks melee range
				if (direction > 0) //checks if target is in front of you
				{
					EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
					eh.AdjustCurrentHealth(-10);
					Debug.Log ("Did 10 points of damage to " + target);
					attackTimer = coolDown;
				}
				if (direction < 0)
				{
					Debug.Log("Target must be in front of you");
				}
			} else
			{
				Debug.Log ("Target too far away");
			}
		}
		else
		{
			Debug.Log("Nothing Targeted");
		}
	}
}
