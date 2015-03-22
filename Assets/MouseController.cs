using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

	public float jetpackForce = 75.0f;
	public float forwardMovementSpeed = 3.0f;

	public Transform groundCheckTransform;
	
	private bool grounded;
	
	public LayerMask groundCheckLayerMask;
	
	Animator animator;

	public ParticleSystem jetpack;

	public bool dead = false;

	// Use this for initialization
	void Start () {
		animator =  GetComponent<Animator>();
	}

	void UpdateGroundedStatus()
	{
		//1
		grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
		
		//2
		if (dead) {
			animator.SetBool ("dead", true);
		} else {
			animator.SetBool ("grounded", grounded);
		}
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		HitByLaser(collider);
	}
	
	void HitByLaser(Collider2D laserCollider)
	{
		dead = true;
	}


	// Update is called once per frame
	// all animation related code
	void Update () {
		bool jetpackActive = Input.GetButton("Fire1") && dead == false;
		
		if (jetpackActive) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jetpackForce));
			Vector2 newVelocity = GetComponent<Rigidbody2D> ().velocity;
			newVelocity.x = forwardMovementSpeed;
			GetComponent<Rigidbody2D> ().velocity = newVelocity;
			jetpack.enableEmission = true;
		} else {
			if(dead){
				jetpack.emissionRate = 100000;
				jetpack.enableEmission = true;
			
			}else{
				Vector2 newVelocity = GetComponent<Rigidbody2D> ().velocity;
				newVelocity.x = forwardMovementSpeed;
				GetComponent<Rigidbody2D> ().velocity = newVelocity;
				jetpack.enableEmission = false;
			}
		}

		UpdateGroundedStatus ();
	}

	// all physics related code
	void FixedUpdate () 
	{

	}
}
