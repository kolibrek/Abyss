using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float maxJumpHeight = 4f;
	public float minJumpHeight = 1f;
	public float timeToJumpApex = .5f;
	public float moveSpeed = 6f;
	
	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallJumpLeap;
	public float wallSlideSpeedMax = 3;
	public float wallStickTime = 0.25f;
	float timeToWallUnstick;
	
	float accelerationTimeAirborne = 0.3f;
	float accelerationTimeGrounded = 0.1f;
	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	Vector3 heading;
	
	private GameObject player;
	private Controller2D controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Controller2D> ();
		player = GameObject.Find ("Player");
		heading = FindPlayer();

		gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex,2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
		
		print ("Enemy Gravity: " + gravity + "Jump Velocity: " + maxJumpVelocity);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 input = Vector2.zero;
		if (this.tag == "Seeker") {
			if (Vector2.Distance(transform.position, heading) >= 1) {
				float horizontalDistance = heading.x - transform.position.x;
				float verticalDistance = heading.y - transform.position.y;
				if (Mathf.Abs(verticalDistance) >= 1) {
					input.y = Mathf.Sign(verticalDistance);
				}
				if (Mathf.Abs(horizontalDistance) >= 1) {
					input.x = Mathf.Sign(horizontalDistance);
				}
			}

		}
		int wallDirX = (controller.collisions.left)? -1 : 1;
		float targetVelocityX = input.x * moveSpeed;

		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);

		if ((controller.collisions.left && input.x == -1) || (controller.collisions.right && input.x == 1)) {
			velocity.x = 0;
		}

		bool wallSliding = false;
		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0) {
			wallSliding = true;
			
			if (velocity.y < -wallSlideSpeedMax) {
				velocity.y = -wallSlideSpeedMax;
			}
			if (timeToWallUnstick > 0) {
				velocityXSmoothing = 0;
				velocity.x = 0;
				if (input.x != wallDirX && input.x != 0) {
					timeToWallUnstick -= Time.deltaTime;
				} else {
					timeToWallUnstick = wallStickTime;
				}
			} else {
				timeToWallUnstick = wallStickTime;
			}
		}
		if (input.y == 1) {
			if (wallSliding) {
				// if moving towards wall
				if (wallDirX == 1) {
					velocity.x = -wallDirX * wallJumpClimb.x;
					velocity.y = wallJumpClimb.y;
					// if not moving horizontally
				} else if (input.x == 0) {
					velocity.x = -wallDirX * wallJumpOff.x;
					velocity.y = wallJumpOff.y;
					// if moving away from wall
				} else {
					velocity.x = -wallDirX * wallJumpLeap.x;
					velocity.y = wallJumpLeap.y;
				}
			}
			if (controller.collisions.below){
				velocity.y = maxJumpVelocity;
			}
		}
		if (input.y != -1) {
			if (velocity.y > minJumpVelocity) {
				velocity.y = minJumpVelocity;
			}
		}
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime, input);
		
		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}
	}

	Vector3 FindPlayer() {
		return player.transform.position;
	}

	void FixedUpdate() {
		heading = FindPlayer();
		//print (Mathf.Sign(heading.x - transform.position.x));
	}
}
