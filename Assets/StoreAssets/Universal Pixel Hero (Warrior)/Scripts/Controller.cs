using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	Animator animator;
	public float speed = 1f;

	void Start () {
		animator = GetComponent<Animator> ();
		animator.SetTrigger(idle2);
	}
	
	void Update () {
		animator.speed = speed;
	}

	public void run() {
		animator.SetTrigger ("run");
	}

	public void jump() {
		animator.SetTrigger ("jump");
	}

	public void attack1() {
		animator.SetTrigger ("attack1");
	}

	public void attack2() {
		animator.SetTrigger ("attack2");
	}

	public void attack3() {
		animator.SetTrigger ("attack3");
	}

	public void skill() {
		animator.SetTrigger ("skill");
	}

		public void idle2() {
		animator.SetTrigger ("idle2");
	}
}
