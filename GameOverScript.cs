using UnityEngine;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{
	private GUISkin skin;
	float origW =1280.0f;
	float origH =853.0f;
	float scaley;
	float scalex;
	float screenwidth,screenheight;
	int highscore=0;
	int thisscore=0;
	void Start()
	{
		screenwidth = Screen.width/15;
		screenheight = Screen.height / 30;
		scalex	 = (float)(Screen.width) / origW; //your scale x
		scaley = (float)(Screen.height) / origH;
		Time.timeScale = 0.0f;
		skin=Resources.Load("CircleButton") as GUISkin;
		highscore = PlayerPrefs.GetInt ("highscore");
		thisscore = ScoreScript.Instance.score;
		if (thisscore> highscore) {
			highscore=thisscore;
			PlayerPrefs.SetInt("highscore",highscore);
				}
		for(int i=1;i<=4;i++)
			Destroy(GameObject.Find("longrange"+i.ToString()));
		GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");   
		foreach (GameObject enemy in go)
						Destroy (enemy.gameObject);
		//PlayerPrefs.SetInt("Highscore", ScoreScript.Instance.score);
	}
	void OnGUI()
	{
		GUI.skin = skin;
		string yscore = "Your score:" + thisscore.ToString ();
		GUI.Box(new Rect(screenwidth,screenheight,Screen.width - 2*screenwidth,Screen.height-screenheight*2),yscore.ToString());
		GUI.BeginGroup(new Rect(screenwidth,screenheight,Screen.width - 2*screenwidth,Screen.height-screenheight*2));

		if (GUI.Button (new Rect (400 * scalex, 175 * scaley, 300 * scalex, 200 * scaley), "Play")) {
                        
              			Time.timeScale = 1.0f;
						Application.LoadLevel ("gamescene");
		

				}
		if(GUI.Button(new Rect(400*scalex,395*scaley,300*scalex,200*scaley),"Menu"))
		{
			Time.timeScale = 1.0f;
			// Reload the level
			Application.LoadLevel("menuscene");

				}
		GUI.Label (new Rect (250*scalex,600*scaley,1000*scalex,200*scaley), "Highscore:"+highscore.ToString());
		GUI.EndGroup ();
	}
}