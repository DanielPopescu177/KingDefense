using UnityEngine;

/// <summary>
/// Player controller and behavior
/// </summary>
public class GameplayScript : MonoBehaviour
{
	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	private float r1=4f;
	private float r2=7f;
	private float p1=7f;
	private float p2=10f;
	public Transform enemy;
	float randoms=0,randoms2=0;
	int enemypos=0,rangerpos=0;
	void Start()
	{
        
		PlayerPrefs.SetInt("score",0);
		randoms=Random.Range(0.0F, 2.0F);
		randoms2=Random.Range(0.0F, 2.0F);
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
						transform.gameObject.AddComponent<PauseScript> ();
		if (randoms > 0) {
						if (r1 > 1f) {
								r1 -= Time.fixedDeltaTime / 20;
				      r2 = r1+3f;
						}
						randoms -= Time.deltaTime;
				} else {
						randoms = Random.Range (r1, r2);
						enemypos = Random.Range (1, 5);
						SpawnEnemy (enemypos);
				}
		if (randoms2 > 0) {
			if (p1 > 3f) {
				p1 -= Time.fixedDeltaTime / 20;
				p2 = p1+3f;
			}
			randoms2 -= Time.deltaTime;
		} else {
			randoms2 = Random.Range (p1, p2);
			rangerpos = Random.Range (1, 5);
			RangerAttack(rangerpos);
		}
	}
	void RangerAttack(int x)
	{
		GameObject selranger = GameObject.Find ("longrange" + x.ToString());
		WeaponScript weapsc = selranger.GetComponent<WeaponScript>();
		if (weapsc)
						weapsc.CanAttack = true;


	}
	void SpawnEnemy(int x)
	{
		Vector3 ion = new Vector3 ();
		var enemyy = Instantiate(enemy) as Transform;
		switch (x)
		{
		case 1:
			ion= new Vector3(-14,0,0);
			break;
		case 2:
			ion=new Vector3(0,7,0);
			break;
		case 3:
			ion=new Vector3(14,0,0);
			break;
		case 4:
			ion=new Vector3(0,-7,0);
			break;
		default:
			Debug.Log ("error");
			break;

		}
		enemyy.position=ion;
	}
}
	