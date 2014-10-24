using UnityEngine;
using System.Collections;

public class ColisionPJ : MonoBehaviour {
	

	public GameObject blood;
	//public GameObject coin;
	//public TextMesh counterCoins;
	public DetectDeadZone dead;
	public MoveConstructor move;
	//int counterCoinss = 0;
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy"){
			Debug.Log ("112");
			//Instanciar la sangre
			GameObject bl = (GameObject) Instantiate(blood, transform.position, Quaternion.identity); //crea un gameobject en escena
			
			//Restar vida
			//textLife.text = (int.Parse(textLife.text) - 25).ToString();
			//Destruir la sangre pasado un tiempo
			Destroy (bl, 1);
			
			//Destruir la piedra
			Destroy (other.gameObject);

			dead.GameOver ();
			
			
		}
		
		/*if (other.tag == "Coin") {
			GameObject cn = (GameObject) Instantiate (coin, transform.position, Quaternion.identity);
			
			Destroy (cn, 1);
			
			Destroy (other.gameObject);

			counterCoins.text = (counterCoinss += 1).ToString();
		}*/

		if (other.tag == "Dash" && move.dash == true)
			move.directionDash = new Vector3 (-move.directionDash.x, move.directionDash.y, move.directionDash.z); //rebote de direccion en el dash

		if ((other.tag == "Boss") || (other.tag == "Enemy")) {

			dead.GameOver ();

		}
	}
}