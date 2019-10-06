using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	private Vector2 speed = new Vector2(2f, 2f);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	private Vector2 direction = new Vector2(-1, 0);
	
	private Vector2 movement;
	void Start()
	{
		if (Mathf.Abs (transform.position.y - 2) < 3) {
			if(transform.position.x<0)
			{
				direction=new Vector2(1,0);
			}
				else
			{	
				direction=new Vector2(-1,0); transform.Rotate(0,0,180); }
				}
		else
		{
			speed=new Vector2(0.5f,0.5f);
			if(transform.position.y>0)
			{direction=new Vector2(0,-1); transform.Rotate(0,0,270); }
			else
			{
				direction=new Vector2(0,1); transform.Rotate(0,0,90); }
		}

	}
	void Update()
	{
		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		GetComponent<Rigidbody2D>().velocity = movement;
	}
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Collision with enemy
		WallScript wallsc = otherCollider.gameObject.GetComponent<WallScript>();
		if (wallsc != null)
		{
			// Kill the enemy
			if(!wallsc.red)
			{
				Destroy(gameObject);
				ScoreScript.Instance.UpdateScore(1);
				ScoreScript.Instance.UpdateCoins(5);
			}
			else
				speed+=new Vector2(5f,5f);
		}
		else if (otherCollider.tag == "Chest") {
			
			Destroy (gameObject);
			ScoreScript.Instance.UpdateCoins(-50);
		}

	}
}
