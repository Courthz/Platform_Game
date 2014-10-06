using UnityEngine;
using System.Collections;

public class LevelLogic : MonoBehaviour {

	private DataLogic dataLogic;
	private int totalLevels;

	// Use this for initialization
	void Start () {
		dataLogic = GameObject.FindGameObjectWithTag("DataLogic").GetComponent <DataLogic>();

		dataLogic.SetCurrentLevel(Application.loadedLevel);

		if (dataLogic.GetCurrentLevel() + 1 < Application.levelCount) dataLogic.SetNextLevel (dataLogic.GetCurrentLevel() + 1);
		else dataLogic.SetNextLevel (1);
	}
	
	// Update is called once per frame
	public void LoadCurrentLevel(){
		Application.LoadLevel (dataLogic.GetCurrentLevel());
	}

	public void LoadNextLevel(){
		Application.LoadLevel(dataLogic.GetNextLevel());
	}

	void Update(){

		if (Input.GetKey ("n")) LoadNextLevel();
		if (Input.GetKey("b")) Application.LoadLevel (dataLogic.GetCurrentLevel() - 1);
	}
}
