using UnityEngine;
using System.Collections;

public class Enemyupdownbehaviour : MonoBehaviour {

	public enum StatesEnemy {DOWN, UP}
	
	public StatesEnemy state;
	
	private float currentTime;
	public float currentTimeIni;
	public float speed;
	
	void Start () {
		
		setUp ();
		
	}
	
	void Update () {
		
		switch (state) {
		case StatesEnemy.UP:
			UpBehaviour();
			break;
			
		case StatesEnemy.DOWN:
			DownBehaviour();
			break;
		}
		
	}
	
	private void setUp() {
		
		currentTime = currentTimeIni;
		state = StatesEnemy.UP;
		
	}
	
	private void setDown() {
		
		currentTime = currentTimeIni;
		state = StatesEnemy.DOWN;
		
	}
	
	private void UpBehaviour() {
		
		transform.Translate (0, Time.deltaTime * speed, 0);
		currentTime -= Time.deltaTime;

		if (currentTime < 0){
			setDown ();
		}
		
	}
	
	private void DownBehaviour() {
		
		transform.Translate (0, -Time.deltaTime *speed, 0);
		currentTime -= Time.deltaTime;

		if (currentTime < 0) {
			setUp ();
		}
	}

}
