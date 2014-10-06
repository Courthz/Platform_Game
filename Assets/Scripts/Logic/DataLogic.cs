using UnityEngine;
using System.Collections;

public class DataLogic : MonoBehaviour {

	public AudioClip jump;
	public int continueCounter = 3;
	private int currentLevel;
	private int nextLevel;

	public void SetCurrentLevel(int levelAux){
		currentLevel = levelAux;
	}

	public int GetCurrentLevel(){
		return currentLevel;
	}

	public void SetNextLevel(int levelNext){
		nextLevel = levelNext;
	}

	public int GetNextLevel(){
		return nextLevel;
	}

	void Awake() {

		DontDestroyOnLoad (transform.gameObject);
	
	}

	// Use this for initialization
	void Start () {

		Application.LoadLevel("Menu");


	}
	
	// Update is called once per frame
	void Update() {



	}

	public void Play(AudioClip audio){

		AudioSource audioSource = gameObject.AddComponent<AudioSource>();

		audioSource.clip = audio; //equivalente a content.load..
		audioSource.volume = 1;
		audioSource.Play();
		Destroy (audioSource, audio.length);
	}


}

