using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour
{
	public static ScoreScript Instance;
	public GUIText scoreText;
	public GUIText coinsText;
	public int score=0;
	public int coins=50;
	private Animator animator;
	//current progress
	float origW =1280.0f;
	float origH =853.0f;
	float elapsed=0;
	void Start() {
				float scalex = (float)(Screen.width) / origW; //your scale x
				float scaley = (float)(Screen.height) / origH; //your scale y
				Vector2 pixOff = scoreText.pixelOffset;//your pixel offset on screen
				int origSizeText = scoreText.fontSize;
				scoreText.pixelOffset = new Vector2 (pixOff.x * scalex, pixOff.y * scaley);
				scoreText.fontSize = (int)(origSizeText * scalex);
		pixOff = coinsText.pixelOffset;//your pixel offset on screen
		origSizeText = coinsText.fontSize;
		coinsText.pixelOffset = new Vector2 (pixOff.x * scalex, pixOff.y * scaley);
		coinsText.fontSize = (int)(origSizeText * scalex);
		}


	void Awake()
	{
		if(Instance==null)
			Instance = this;
		animator = GetComponent<Animator>();
	}
	void Update()
	{
	   if (elapsed > 0)
						elapsed -= Time.deltaTime;
		else
			animator.SetBool ("Jump", false);

	}
	public void UpdateScore(int x)
	{
		//Debug.Log ("barDisplay is: " + barDisplay);
		score = score + x;
		scoreText.text = "Score:" + score.ToString();
		//scoreText.text = score.ToString ();
	}
	public void UpdateCoins(int x)
	{
		if (x > 0) {
						animator.SetBool ("Jump", true);
			elapsed=0.3f;
				}
		coins += x;
		if(coins>0)
			coinsText.text = coins.ToString ();
			else	
		transform.gameObject.AddComponent<GameOverScript> ();

	}
	
}