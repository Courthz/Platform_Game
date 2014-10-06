using UnityEngine;
using System.Collections;

public class MoveConstructor : MonoBehaviour {
	
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private AnimationCharacter animation;
	private BoxCollider colision;
	private bool godMode;

	private DataLogic dataLogic;

	void Start() {

		godMode = false;
		dataLogic = GameObject.FindGameObjectWithTag("DataLogic").GetComponent<DataLogic>();
		animation = transform.FindChild("Constructor").GetComponent<AnimationCharacter>();
		colision = transform.FindChild("Collider").GetComponent<BoxCollider>();
	}

	void Update() { //Actualiza los frames

		Camera.main.transform.position = new Vector3 (transform.position.x, transform.position.y + 1.5f, -6);
		
		CharacterController controller = GetComponent<CharacterController>();
		if (godMode == false) {
			gravity = 20.0F;
			if (Input.GetKey ("o")) godMode = true;
			if (controller.isGrounded) { //controla si esta pisando el suelo
				//Debug.Log ("PISANDO");
				
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;

				if (moveDirection.x>0) animation.SetRunRight();
				else if (moveDirection.x<0) animation.SetRunLeft();
				else animation.SetIdle();
				
				if (Input.GetButton("Jump")) {
					dataLogic.Play (dataLogic.jump);
					moveDirection.y = jumpSpeed;
					animation.SetJump();
				}
			}
		} 
		if (godMode == true) {
			gravity = 0F;
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis ("Vertical"), 0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			
			if (moveDirection.x>0) animation.SetRunRight();
			else if (moveDirection.x<0) animation.SetRunLeft();
			else animation.SetIdle();

			if (Input.GetKey ("o")) godMode = false;
			
			/*if (Input.GetButton("Jump")) {
				moveDirection.y *= speed;
			}*/
		
		}
		if (Input.GetKey ("p")) colision.enabled = !colision.enabled;
		//speed += 0.01f;
		moveDirection.y -= gravity * Time.deltaTime; //El delta time controla los frames por segundo
		moveDirection.z = 0;
		//moveDirection.x = 100 * Time.deltaTime*speed;
		controller.Move(new Vector3(moveDirection.x * Time.deltaTime,moveDirection.y * Time.deltaTime,0)); //se mueve el personaje
		
	}
}