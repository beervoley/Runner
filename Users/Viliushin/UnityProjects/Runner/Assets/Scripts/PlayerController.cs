using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;

	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float jumpForce;
	public bool ifOnGround;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float groundCheckRadius;

	public float jumpTime;
	private float jumpTimeCounter;


	private Rigidbody2D playerRigidBody;
	//private Collider2D playerCollider;

	private Animator animator;

	public GameManager gameManager;

	// Use this for initialization
	void Start () {

		playerRigidBody = GetComponent<Rigidbody2D> ();
		//playerCollider = GetComponent<Collider2D> ();
		animator = GetComponent<Animator> ();
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
	}
	
	// Update is called once per frame
	void Update () {

		//ifOnGround = Physics2D.IsTouchingLayers (playerCollider, groundLayer);

		ifOnGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);



		if (transform.position.x > speedMilestoneCount) {
			moveSpeed *= speedMultiplier;
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone *= speedMultiplier;
		}


		playerRigidBody.velocity = new Vector2 (moveSpeed, playerRigidBody.velocity.y);

		if (ifOnGround && (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))) {
			
			playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, jumpForce);
		}

		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0))) {

			if (jumpTimeCounter > 0) {
				playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
			
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
			jumpTimeCounter = 0;
		}

		if (ifOnGround) {
			jumpTimeCounter = jumpTime;
		}

		animator.SetFloat ("Speed", playerRigidBody.velocity.x);
		animator.SetBool ("ifOnGround", ifOnGround);
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "killBox") {
			gameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
		}
		
	}
}
