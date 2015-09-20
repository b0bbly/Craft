using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int curHealth = 100;

	public float healtbarLength;

	// Use this for initialization
	void Start () {
		healtbarLength = Screen.width / 4;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustCurrentHealth(0);
	}

	void OnGUI(){
		GUI.Box(new Rect(10, 10, Screen.width / 4 / (maxHealth / curHealth), 20), curHealth + "/" + maxHealth);
	}

	public void AdjustCurrentHealth(int adj){
		curHealth += adj;

		if (curHealth < 0)
			curHealth = 0;

		if (curHealth > maxHealth)
			curHealth = maxHealth;

		if (maxHealth < 1)
			maxHealth = 1;

		healtbarLength = (Screen.width / 4) * (curHealth / (float)maxHealth);
	}
}
