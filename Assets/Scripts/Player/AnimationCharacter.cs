using UnityEngine;
using System.Collections;

public class AnimationCharacter : MonoBehaviour {

	private Animation animation;

	// Use this for initialization
	void Start () {
	
		animation = GetComponent<Animation>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetJump(){
		animation.Play("jump_pose");
	}

	public void SetRunRight(){
		animation.Play ("run");

		transform.eulerAngles = new Vector3(0,90,0);
	}

	public void SetRunLeft() {
		animation.Play ("run");

		transform.eulerAngles = new Vector3(0,-90,0);
	}

	public void SetIdle() {
		animation.Play ("idle");
		transform.eulerAngles = new Vector3(0,180,0);
	}
}
