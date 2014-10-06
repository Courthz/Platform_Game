using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (new Vector3 ( Time.deltaTime * 5.5f, 0, 0));

	}
}
