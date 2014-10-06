using UnityEngine;
using System.Collections;

public class PlatformStates : MonoBehaviour {

	public enum StatesPlatform {DOWN, UP}
	
	public StatesPlatform state;
	
	private float currentTime;
	public float currentTimeIni;
	
	void Start () {
		
		setUp ();
		
	}
	
	void Update () {
		
		switch (state) {
		case StatesPlatform.UP:
			UpBehaviour();
			break;
			
		case StatesPlatform.DOWN:
			DownBehaviour();
			break;
		}
		
	}
	
	private void setUp() {
		
		currentTime = currentTimeIni;
		state = StatesPlatform.UP;
		
	}
	
	private void setDown() {
		
		currentTime = currentTimeIni;
		state = StatesPlatform.DOWN;
		
	}
	
	private void UpBehaviour() {
		
		transform.Translate (0, Time.deltaTime * 1.5f, 0);
		currentTime -= Time.deltaTime;

		if (currentTime < 0){
			setDown ();
		}
		
	}
	
	private void DownBehaviour() {
		
		transform.Translate (0, -Time.deltaTime *1.5f, 0);
		currentTime -= Time.deltaTime;

		if (currentTime < 0) {
			setUp ();
		}
	}

}
