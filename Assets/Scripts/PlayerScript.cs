using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float speed = 150;
	public float addForce = 7;
	public bool isFacingRight = true;
	public float timeBtwJumpPadenie;

	private KeyCode leftButton = KeyCode.A;
	private KeyCode rightButton = KeyCode.D;
	private KeyCode addForceButton = KeyCode.Space;

	private float vertical;
	private float horizontal;
	private bool jump;

	private float timeBtw;
	private Vector3 direction;
	private Rigidbody2D body;
	private Animator anim;

	void Start()
	{
		timeBtw = timeBtwJumpPadenie;
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.transform.tag == "Ground")
		{
			body.drag = 10;
			jump = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.transform.tag == "Ground")
		{
			body.drag = 0;
			jump = false;
		}
	}

	void FixedUpdate()
	{
		body.AddForce(direction * body.mass * speed);
		
		if (Mathf.Abs(body.velocity.x) > speed / 100f)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);
		}
		if (Input.GetKey(addForceButton) && jump)
			body.velocity = new Vector2(0, addForce);
	}

	void Flip()
	{
			isFacingRight = !isFacingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
	}

	void Update()
	{
		if (jump == false) 
		{
			timeBtw -= Time.deltaTime;
			if (timeBtw >= timeBtwJumpPadenie / 2) anim.SetInteger("FormAnim", 2);
			else anim.SetInteger("FormAnim", 3);
		}
		if (jump == true) timeBtw = timeBtwJumpPadenie;
		if (Input.GetKey(leftButton)) { horizontal = -1; if (jump == true) { anim.SetInteger("FormAnim", 1); } }
		else if (Input.GetKey(rightButton)) { horizontal = 1; if (jump == true) { anim.SetInteger("FormAnim", 1); } } else { horizontal = 0; if (jump == true) { anim.SetInteger("FormAnim", 0); } }

		direction = new Vector2(horizontal, 0);

		if (horizontal > 0 && !isFacingRight) Flip(); else if (horizontal < 0 && isFacingRight) Flip();
	}
}