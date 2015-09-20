using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GameObject playerCharacter;
	public GameObject gameSettings;
	public Camera mainCamera;

	//temp camera variables
	public float zOffset;
	public float yOffset;
	public float xRotOffset;

	private GameObject _pc;
	private PlayerCharacter _pcScript;

	// Use this for initialization
	void Start () {

		/*The below line spawns the character
		 * _pc = Instantiate(playerCharacter, new Vector3(40f, 4.2f, 40f), Quaternion.identity) as GameObject;
		 *  Possibly load the (X, Y + 0.2, Z) to make sure the char spawns above ground instead of falling through
		 * remember to assign the player transform (the character model's prefab) to the script
		 */
		_pc = Instantiate(playerCharacter, new Vector3(40f, 4.2f, 40f), Quaternion.identity) as GameObject;
		_pc.name = "Player Character";

		_pcScript = _pc.GetComponent<PlayerCharacter>();

		zOffset = -2.5f;
		yOffset = 2.5f;
		xRotOffset = 22.5f;

		mainCamera.transform.position = new Vector3(_pc.transform.position.x, _pc.transform.position.y + yOffset, _pc.transform.position.z + zOffset);
		mainCamera.transform.Rotate (xRotOffset, 0, 0);

		LoadCharacter();
	}
	
	// Update is called once per frame
	void Update () {
		mainCamera.transform.position = new Vector3(_pc.transform.position.x, _pc.transform.position.y + yOffset, _pc.transform.position.z + zOffset);

	}

	public void LoadCharacter(){
		GameObject gs = GameObject.Find("__GameSettings");
		if (gs == null){
			GameObject gs1 = Instantiate(gameSettings, Vector3.zero, Quaternion.identity) as GameObject;
			gs1.name = "__GameSettings";
		}
		GameSettings gsScript = GameObject.Find ("__GameSettings").GetComponent<GameSettings>();
		
		
		//Load the character data from registry
		gsScript.LoadCharacterData();
	}
}
