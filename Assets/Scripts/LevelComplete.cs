using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour {

	public GameObject levelComplete;
	private bool levelCompletePlay;
	private LevelLogic levelLogic;

	// Use this for initialization
	void Start () {
		levelLogic = GameObject.FindGameObjectWithTag("LevelLogic").GetComponent<LevelLogic>();

		levelCompletePlay = false;

		levelComplete = Camera.main.transform.FindChild("LevelComplete").gameObject;

		levelComplete.SetActive (false);

	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Player"){

			LevelPass();

		}
	}

	void Update () {

		if (levelCompletePlay == true) {
			if (Input.GetButton("Jump")) {
				//Application.LoadLevel ("Main");
				levelLogic.LoadNextLevel();
			}
		}
	}

	public void LevelPass() {
	
		levelCompletePlay = true;

		levelComplete.SetActive(true);

	}
}