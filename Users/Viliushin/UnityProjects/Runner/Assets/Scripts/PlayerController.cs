using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public float moveSpeed;
	public float jumpForce;
	public bool ifOnGround;
	public LayerMask groundLayer;


	private Rigidbody2D playerRigidBody;
	private Collider2D playerCollider;

	private Animator animator;

	// Use this for initialization
	void Start () {

		playerRigidBody = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<Collider2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		ifOnGround = Physics2D.IsTouchingLayers (playerCollider, groundLayer);


		playerRigidBody.velocity = new Vector2 (moveSpeed, playerRigidBody.velocity.y);

		if (ifOnGround && (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))) {
			playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, jumpForce);
		}
		animator.SetFloat ("Speed", playerRigidBody.velocity.x);
		animator.SetBool ("ifOnGround", ifOnGround);
	}
}
