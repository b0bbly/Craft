using UnityEngine;
using System.Collections;
using System; 

public class GameSettings : MonoBehaviour {

	void Awake(){
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SaveCharacterData(){
		GameObject pc = GameObject.Find("Player Character");
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();
		//PlayerPrefs.DeleteAll();


		PlayerPrefs.SetString("Player Name", pcClass.Name);
	
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++){
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString()+ " Base Value", pcClass.GetPrimaryAttribute(cnt).BaseValue);
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString() + " Exp to Level", pcClass.GetPrimaryAttribute(cnt).ExpToLevel);
		}

		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++){
			PlayerPrefs.SetInt(((VitalName)cnt).ToString()+ " Base Value", pcClass.GetVital(cnt).BaseValue);
			PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " Exp to Level", pcClass.GetVital(cnt).ExpToLevel);
			PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " Current Value", pcClass.GetVital(cnt).CurValue);

			//PlayerPrefs.SetString(((VitalName)cnt).ToString()+ " Mods", pcClass.GetVital(cnt).GetModifyingAttributeString());
		}

		for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++){
			PlayerPrefs.SetInt(((SkillName)cnt).ToString()+ " Base Value", pcClass.GetSkill(cnt).BaseValue);
			PlayerPrefs.SetInt(((SkillName)cnt).ToString() + " Exp to Level", pcClass.GetSkill(cnt).ExpToLevel);

			PlayerPrefs.SetString(((SkillName)cnt).ToString()+ " Mods", pcClass.GetSkill(cnt).GetModifyingAttributeString());

			
			//pcClass.GetSkill(cnt).GetModifyingAttributeString();
		}
	}

	public void LoadCharacterData(){
		GameObject pc = GameObject.Find("Player Character");
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();

		pcClass.Name = PlayerPrefs.GetString("Player Name", "Name Me");

		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++){
			pcClass.GetPrimaryAttribute(cnt).BaseValue = PlayerPrefs.GetInt(((AttributeName)cnt).ToString()+ " Base Value", 0 );
			pcClass.GetPrimaryAttribute(cnt).ExpToLevel = PlayerPrefs.GetInt(((AttributeName)cnt).ToString() + " Exp to Level", 0);
		}

		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++){
			pcClass.GetVital(cnt).BaseValue = PlayerPrefs.GetInt(((VitalName)cnt).ToString()+ " Base Value", 0);
			pcClass.GetVital(cnt).ExpToLevel = PlayerPrefs.GetInt(((VitalName)cnt).ToString() + " Exp to Level", 0);

			//make sure you call this so that the AdjustedBaseValue will be updated before you try to call to get the curValue
			pcClass.GetVital(cnt).Update();


			pcClass.GetVital(cnt).CurValue = PlayerPrefs.GetInt(((VitalName)cnt).ToString() + " Current Value", 10);
		}

		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++)
			{
				Debug.Log (((VitalName)cnt).ToString() + ": " + pcClass.GetVital(cnt).CurValue);
			}
		//pcClass.GetVital(cnt).GetModifyingAttributeString() = PlayerPrefs.GetString(((VitalName)cnt).ToString()+ " Mods", 0);

	}
}
