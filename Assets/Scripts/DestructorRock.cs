using UnityEngine;
using System.Collections;

public class DestructorRock : MonoBehaviour {

		void OnTriggerEnter(Collider other) {
			if (other.tag == "Enemy") {
				Destroy (other.gameObject);
			}
			if (other.tag == "suelomoneda") {
				Destroy (other.gameObject);
			}
		}
}
