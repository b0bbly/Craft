using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int curHealth = 100;
	
	public float healthbarLength;
	
	// Use this for initialization
	void Start () {
		healthbarLength = Screen.width / 4;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustCurrentHealth(0);
	}
	
	void OnGUI(){
		GUI.Box(new Rect(10, 40, healthbarLength, 20), curHealth + "/" + maxHealth);
	}
	
	public void AdjustCurrentHealth(int adj){
		curHealth += adj;
		
		if (curHealth < 0)
			curHealth = 0;
		
		if (curHealth > maxHealth)
			curHealth = maxHealth;
		
		if (maxHealth < 1)
			maxHealth = 1;
		
		healthbarLength = (Screen.width / 4) * (curHealth / (float)maxHealth);
	}
}

