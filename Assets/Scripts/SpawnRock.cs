using UnityEngine;
using System.Collections;

public class SpawnRock : MonoBehaviour {
	
	public GameObject rock;
	public GameObject suelo1;
	public GameObject suelo2;
	public GameObject coiny;
	public float temp;
	public float temp2;
	public float temp3;
	
	// Use this for initialization
	void Start () {
		temp = 3;
		temp2 = 1.5f;
		temp3= Random.Range (0, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
		temp -= Time.deltaTime;
		temp2 -= Time.deltaTime;
		temp3 -= Time.deltaTime;
		if (temp < 0) {
			Instantiate (suelo1, new Vector3 (transform.position.x, Random.Range (-2, 1), transform.position.z), Quaternion.identity);
			temp = 3;
		}
		
		if (temp2 < 0) {
			Instantiate (suelo2, new Vector3 (transform.position.x, Random.Range (-1, 1), transform.position.z), Quaternion.identity);	
			temp2 = 3;
		}
		
		if (temp3 < 0) {
			Instantiate (coiny, new Vector3 (transform.position.x, Random.Range (0, 3), transform.position.z), Quaternion.identity);
			temp3 = 3;
		}
		
		//Instantiate (suelo1, new Vector3 (transform.position.x, Random.Range (0,5), transform.position.z), Quaternion.identity);
		//Instantiate (suelo2, new Vector3 (transform.position.x, Random.Range (0,5), transform.position.z), Quaternion.identity);;
	}
}
