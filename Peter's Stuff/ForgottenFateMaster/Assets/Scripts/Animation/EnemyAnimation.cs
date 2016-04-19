using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {
	
	// Animation purposes
	private Animator anim;
	
	private Vector3 Enemy;
	private Vector2 EnemyDirection;
	private int Ground;
	
	// The speed of the enemy
	public Vector2 speed = new Vector2(1, 1);
	
	// Store the movement
	private Vector2 movement;
	
	// Use this for initialization
	void Start () 
	{
		anim = this.GetComponent<Animator>();
		Ground = 1 << 12;


		anim.SetBool ("Right", true);
		anim.SetBool ("Left", true);
		anim.SetBool ("Up", true);
		anim.SetBool ("Down", true);
	}
	
	void Update () 
	{
		Enemy = GameObject.Find ("Player").transform.position;
		
		// Retrieve axis information
		var horizontal = Enemy.x - transform.position.x;
		var vertical = Enemy.y - transform.position.y;
		
		EnemyDirection = new Vector2(horizontal, vertical);
		
		// Movement per direction
		movement = new Vector2(speed.x * horizontal, speed.y * vertical);
		print (vertical);
		
		// directional control
		if (vertical > .2f)
		{
			//animator.SetInteger("Direction", 2);
			//animator.SetFloat("Speed", 1.0f);
			//GetComponent<Animation>().Stop();
			anim.Play("WalkUp"); 
			anim.SetBool ("WalkUp", true);
			anim.SetBool ("WalkDown", false);
			anim.SetBool ("WalkRight", false);
			anim.SetBool ("WalkLeft", false);
		}
		else if (vertical < -.2f)
		{
			//animator.SetInteger("Direction", 0);
			//animator.SetFloat("Speed", 1.0f);
			//GetComponent<Animation>().Stop();
			anim.Play("WalkDown"); 
			anim.SetBool ("WalkDown", true);
			anim.SetBool ("WalkRight", false);
			anim.SetBool ("WalkUp", false);
			anim.SetBool ("WalkLeft", false);
		}
		else if (horizontal < -.2f)  //greater or less than 0 .
		{
			//animator.SetInteger("Direction", 1);
			//animator.SetFloat("Speed", 1.0f);
		//	GetComponent<Animation>().Stop();
			anim.Play("WalkLeft"); 
			anim.SetBool ("WalkLeft", true);
			anim.SetBool ("WalkRight", false);
			anim.SetBool ("WalkUp", false);
			anim.SetBool ("WalkDown", false);
		}
		else if (horizontal > .2f)
		{
			//animator.SetInteger("Direction", 3);
			//animator.SetFloat("Speed", 1.0f);
			//GetComponent<Animation>().Stop();
			anim.Play("WalkRight"); 
			anim.SetBool ("WalkRight", true);
			anim.SetBool ("WalkDown", false);
			anim.SetBool ("WalkUp", false);
			anim.SetBool ("WalkLeft", false);
		}
		else 
		{
			//GetComponent<Animation>().Stop();
		

		}
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Hit " + other.gameObject);
			anim.speed = 0f;

		}
	}
		void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject.tag == "Player") 
			{

				anim.speed = 1f;
				
			}
	}
}