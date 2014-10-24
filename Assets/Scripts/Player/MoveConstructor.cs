using UnityEngine;
using System.Collections;

public class MoveConstructor : MonoBehaviour {
	
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private int framesCounter;
	private int counterDash;
	private Vector3 moveDirection = Vector3.zero;
	public Vector3 directionDash;
	//private AnimationCharacter animation;
	private BoxCollider colision;
	private bool godMode;

	public bool dash;

	private float vertVel = 0;

	private DataLogic dataLogic;

	void Start() {

		dash = false;
		godMode = false;
		dataLogic = GameObject.FindGameObjectWithTag("DataLogic").GetComponent<DataLogic>();
		//animation = transform.FindChild("Constructor").GetComponent<AnimationCharacter>();
		colision = transform.FindChild("Collider").GetComponent<BoxCollider>();
	}

	void Update() { //Actualiza los frames

		framesCounter++;
		Camera.main.transform.position = new Vector3 (transform.position.x, 2F, -12F); //el "bueno"
		//Camera.main.transform.position = new Vector3 (transform.position.x, 2F, -30F); //para comprobar cosas de lejos.
		CharacterController controller = GetComponent<CharacterController>();
		if (godMode == false) {
			gravity = 20.0F;
			speed = 6.0F;
			if (Input.GetKey ("o")) godMode = true;
			if (Input.GetKeyDown("e")) dash = true;

			moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			moveDirection = transform.TransformDirection(moveDirection) * speed;
			vertVel -= gravity * Time.deltaTime; //El delta time controla los frames por segundo
			moveDirection.y = vertVel;
			moveDirection.z = 0;


			//moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			//moveDirection = transform.TransformDirection(moveDirection) * speed;
			if (dash == false){
				if (Input.GetKey(KeyCode.DownArrow)) directionDash = new Vector3 (0,-1,0);
				if (Input.GetKey (KeyCode.UpArrow)) directionDash = new Vector3 (0, 1, 0);
				if (Input.GetKey (KeyCode.RightArrow)){
					directionDash = new Vector3 (1, 0, 0);
					if (Input.GetKey (KeyCode.UpArrow)) directionDash = new Vector3 (1,1,0);
				}
				//if (Input.GetKey (KeyCode.RightArrow) && Input.GetKey (KeyCode.UpArrow)) directionDash = new Vector3 (1, 1, 0);

				//if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.LeftArrow)) directionDash = new Vector3 (-1, 1, 0);
				if (Input.GetKey (KeyCode.LeftArrow)){
					directionDash = new Vector3 (-1, 0, 0);
					if (Input.GetKey (KeyCode.UpArrow)) directionDash = new Vector3 (-1,1,0);
				}

				if (framesCounter % 15 == 0) directionDash = new Vector3 (0, 0, 0);
			}
			if (dash == true){ //MIRAR COMO COMPARAR QUE UN VECTOR 3 NO SEA UNO EN CONCRETO.
				if (directionDash == new Vector3 (0, 0, 0)) dash = false;
				counterDash++;
				gravity = 0F;
				vertVel = 0F;


				/*if (Input.GetKey (KeyCode.RightArrow)) directionDash = new Vector3 (1, 0, 0);
				else if (Input.GetKey (KeyCode.RightArrow) && Input.GetKey (KeyCode.UpArrow)) directionDash = new Vector3 (1, 1, 0);
				else if (Input.GetKey (KeyCode.UpArrow)) directionDash = new Vector3 (0, 1, 0);
				else if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.LeftArrow)) directionDash = new Vector3 (-1, 1, 0);
				else if (Input.GetKey (KeyCode.LeftArrow)) directionDash = new Vector3 (-1, 0, 0);
				else dash = false;*/
				speed = 30.0F;
				moveDirection = directionDash;
				moveDirection = transform.TransformDirection(moveDirection) * speed;

				if (counterDash >= 30){
					directionDash = new Vector3 (0, 0, 0);
					counterDash = 0;
				}

			}

			if (controller.isGrounded) { //controla si esta pisando el suelo
				//Debug.Log ("PISANDO");
				//speed = 6.0F;

				//moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
				//moveDirection = transform.TransformDirection(moveDirection);
				//moveDirection *= speed;

				/*if (moveDirection.x>0) animation.SetRunRight();
				else if (moveDirection.x<0) animation.SetRunLeft();
				else animation.SetIdle();*/
				
				if (Input.GetButton("Jump")) {
					dataLogic.Play (dataLogic.jump);
					vertVel = jumpSpeed;
					//moveDirection.y = jumpSpeed;

					//animation.SetJump();
				}
			}
			/*else {
				speed = 5.0F;
					if (Input.GetKeyDown(KeyCode.RightArrow)) moveDirection.x += speed;
					if (Input.GetKeyDown (KeyCode.LeftArrow)) moveDirection.x -= speed;
			}*/
		} 
		if (godMode == true) {
			gravity = 0F;
			vertVel = jumpSpeed;
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis ("Vertical"), 0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			
			/*if (moveDirection.x>0) animation.SetRunRight();
			else if (moveDirection.x<0) animation.SetRunLeft();
			else animation.SetIdle();*/

			if (Input.GetKey ("o")) godMode = false;
			
			/*if (Input.GetButton("Jump")) {
				moveDirection.y *= speed;
			}*/
		
		}
		if (Input.GetKey ("p")) colision.enabled = !colision.enabled;
		//speed += 0.01f;
		/*vertVel -= gravity * Time.deltaTime; //El delta time controla los frames por segundo
		moveDirection.y = vertVel;
		moveDirection.z = 0;*/

		//moveDirection.x = 100 * Time.deltaTime*speed;

		//controller.Move(new Vector3(moveDirection.x * Time.deltaTime,moveDirection.y * Time.deltaTime,0)); //se mueve el personaje
		controller.Move(moveDirection * Time.deltaTime);
	}
}