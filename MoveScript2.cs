using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript2 : MonoBehaviour
{
	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);
	
	private Vector2 movement;
	
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
				ScoreScript.Instance.UpdateScore(2);
				ScoreScript.Instance.UpdateCoins(10);
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