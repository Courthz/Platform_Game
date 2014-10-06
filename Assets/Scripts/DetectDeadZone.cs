using UnityEngine;
using System.Collections;

public class DetectDeadZone : MonoBehaviour {

	private GameObject gameOver;
	private bool gameOverPlay;
	private LevelLogic levelLogic;
	private DataLogic dataLogic;

	// Use this for initialization
	void Start () {
		levelLogic = GameObject.FindGameObjectWithTag("LevelLogic").GetComponent<LevelLogic>();

		dataLogic = GameObject.FindGameObjectWithTag("DataLogic").GetComponent<DataLogic>();
		gameOverPlay = false;

		gameOver = Camera.main.transform.FindChild("GameOver").gameObject;

		/*if ((PlayerPrefs.GetInt ("Coins")) == null) {
			PlayerPrefs.SetInt ("Coins", 0);
		}

		if ((PlayerPrefs.GetFloat("Distance")) == null) {
			PlayerPrefs.SetFloat("Distance", 0);
		}*/

		gameOver.SetActive (false);

	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Player"){

			GameOver();

		}
	}

	void Update () {

		if (gameOverPlay == true) {
			if (Input.GetButton("Jump")) {
				//Application.LoadLevel ("Main");
				levelLogic.LoadCurrentLevel();
			}
		}

		if (Input.GetKey ("escape")) {
			Application.Quit();
		}
	}

	public void GameOver() {
	
		gameOverPlay = true;

		gameOver.SetActive(true);

		dataLogic.continueCounter -= 1;

		if (dataLogic.continueCounter == 0) Application.Quit();
		
		/*float distance = playerTransform.position.x;
		
		textDistance.text = "Distance: " + distance.ToString() + "m";
		
		textCoins.text = "Coins: " + textCoinsGameplay.text;
		
		if(int.Parse (textCoinsGameplay.text) > PlayerPrefs.GetInt ("Coins")) {
			PlayerPrefs.SetInt ("Coins", int.Parse(textCoinsGameplay.text));
		}
		textCoinsMax.text = "Max Coins: " + PlayerPrefs.GetInt("Coins").ToString();
		
		if(distance > PlayerPrefs.GetFloat("Distance")) {
			PlayerPrefs.SetFloat ("Distance", distance);
		}
		textDistanceMax.text = "Max Distance: " + PlayerPrefs.GetFloat ("Distance").ToString() + "m";
*/
	}
}