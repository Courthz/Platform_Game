using UnityEngine;
using System.Collections;

public class ButonBehaviour : MonoBehaviour {

	public string levelName;

	// ACTIVAMOS EL EVENTO ONDOWN
	void OnEnable(){
		GetComponent<InputBehaviour>().onDown += onDown;
	}
	
	// DESACTIVAMOS EL EVENTO ONDOWN
	void OnDisable(){
		GetComponent<InputBehaviour>().onDown -= onDown;
	}

	// QUÉ HACE EL EVENTO ONDOWN ???
	void onDown(int number){
		Debug.Log("Aprieto el Boton");

		if (levelName != "Menu") Application.LoadLevel(levelName);

		else Application.Quit();
	}	
}
