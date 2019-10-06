using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
	//--------------------------------
	// 1 - Designer variables
	//--------------------------------
	
	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform shotPrefab;
	public bool CanAttack = false;
	private bool hasbeen = true;
	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public int id=1;
	private float cooldown=2;
	//--------------------------------
	// 2 - Cooldown
	//--------------------------------

	void Start()
	{
		hasbeen = false;
		CanAttack = false;

		}
	void Update()
	{
				if (CanAttack) {
						if (cooldown > 0) {
								cooldown -= Time.deltaTime;
								PreAttack (id);
				                hasbeen=true;
						} else {
				                cooldown=2;
								Attack (id);
				                hasbeen=false;
								CanAttack = false;
						}
				}
		}
	
	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------
	
	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	void PreAttack(int x)
	{
		Vector3 pos = new Vector3 (-5.8f, 5.8f, 0);
				if (!hasbeen) {
						switch (x) {
						case 1:
								SpecialEffectsHelper.Instance.Explosion (pos);
								break;
			case 2:
				pos = new Vector3 (-6.2f, -5.8f, 0);
				SpecialEffectsHelper.Instance.Explosion (pos);
				break;
			case 3:
				pos = new Vector3 (6.2f, -5.8f, 0);
				SpecialEffectsHelper.Instance.Explosion (pos);
				break;
			case 4:
				pos = new Vector3 (6.2f, 5.8f, 0);
				SpecialEffectsHelper.Instance.Explosion (pos);
				break;
			default:
				break;
						}
				}
		}
	void Attack(int x)
	{
		var shotTransform = Instantiate (shotPrefab) as Transform;
		Vector3 ion=new Vector3(0.45f,-0.6f,0);
		MoveScript2 move = shotTransform.gameObject.GetComponent<MoveScript2> ();
	switch (x) {
				case 1:
			shotTransform.position = transform.position+ion;
						shotTransform.Rotate (0, 0, 235);
						if (move != null) {
				ion=new Vector3(1.4f,0.0f,0);
								move.direction = this.transform.right+ion;
						}
						
			break;
		case 2:
			ion=new Vector3(0.55f,0.2f,0);
			shotTransform.position = transform.position+ion;
			shotTransform.Rotate (0, 0, 315);

			if (move != null) {
				ion=new Vector3(0f,1.4f,0);
				move.direction = this.transform.right+ion;
			}
			break;
		case 3:
			ion=new Vector3(-0.25f,0.5f,0);
			shotTransform.position = transform.position+ion;
			shotTransform.Rotate (0, 0, 50);
			
			if (move != null) {
				ion=new Vector3(-1.5f,0,0);
				move.direction = this.transform.right+ion;
			}
			break;
		case 4:
			ion=new Vector3(-0.55f,-0.3f,0);
			shotTransform.position = transform.position+ion;
			shotTransform.Rotate (0, 0, 140);
			
			if (move != null) {
				ion=new Vector3(0f,-1.4f,0);
				move.direction = this.transform.right+ion;
			}
			break;
		default:
			Debug.Log ("helloworld");
						break;
				}
	}
	
	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>

	
}