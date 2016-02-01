using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class PlayerController : MonoBehaviour {

	public float maxJumpHeight = 4f;
	public float minJumpHeight = 1f;
	public float timeToJumpApex = .5f;
	public float moveSpeed = 6f;

	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallJumpLeap;
	public Vector2 throwBack;
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

	private Controller2D controller;
	private Inventory inventory;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Controller2D> ();
		inventory = GetComponent<Inventory>();

		gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex,2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);

		//print ("Player Gravity: " + gravity + "Jump Velocity: " + maxJumpVelocity);
	}

	// Update is called once per frame
	void Update () {
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		int wallDirX = (controller.collisions.left)? -1 : 1;

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);

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
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (wallSliding) {
					// if moving towards wall
				if (wallDirX == input.x) {
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
		if (Input.GetKeyUp(KeyCode.Space)) {
			if (velocity.y > minJumpVelocity) {
				velocity.y = minJumpVelocity;
			}
		}
		if (Input.GetKeyDown(KeyCode.I)) {
			inventory.UseCurrent();
		}
		if (controller.collisions.takingDamage) {
			if (controller.collisions.below) {
				velocity.x = controller.collisions.facingDirection * throwBack.x;
				velocity.y = throwBack.y;
			}
			if (controller.collisions.left || controller.collisions.right) {
				velocity.x = -wallDirX * throwBack.x;
				velocity.y = throwBack.y;
			}
			if (controller.collisions.above) {
				velocity.x = -wallDirX * throwBack.x;
				velocity.y = -throwBack.y;
			}
		}

		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime, input);

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}
	}

	void TakeDamage() {

	}
}
