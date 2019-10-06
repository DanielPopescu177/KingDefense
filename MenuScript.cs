using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	public GUISkin MenuSkin;
	float origW =1280.0f;
	float origH =853.0f;
	float scaley;
	float scalex;
	int highscore=0;
	float screenwidth,screenheight;
	void Start() {
		screenwidth = Screen.width/15;
		screenheight = Screen.height / 30;
		scalex	 = (float)(Screen.width) / origW; //your scale x
		scaley = (float)(Screen.height) / origH; //your scale yxt * scalex);
		highscore = PlayerPrefs.GetInt ("highscore");
	}
	void OnGUI() {
		GUI.skin = MenuSkin;
		GUI.Box(new Rect(screenwidth,screenheight,Screen.width - 2*screenwidth,Screen.height-screenheight*2),"King Defense");
		
		GUI.BeginGroup(new Rect(screenwidth,screenheight,Screen.width - 2*screenwidth,Screen.height-screenheight*2));



		if (GUI.Button (new Rect (400*scalex, 175*scaley, 300*scalex, 200*scaley), "Play"))
			Application.LoadLevel ("gamescene");
		
		GUI.Button(new Rect(400*scalex,395*scaley,300*scalex,200*scaley),"Tutorial");
		GUI.Label (new Rect (250*scalex,600*scaley,1000*scalex,200*scaley), "Highscore:"+highscore.ToString());
/*		

		//GUI.Label (new Rect (0, 50, 100, 20), "I'm a Label!");
		
		//toggleTxt = GUI.Toggle(new Rect(0, 75, 200, 30), toggleTxt, "I am a Toggle button");

		//toolbarInt = GUI.Toolbar (new Rect (0, 110, 250, 25), toolbarInt, toolbarStrings);
		
       //		selGridInt = GUI.SelectionGrid (new Rect (0, 170, 200, 40), selGridInt, selStrings, 2);
		

*/
		
		GUI.EndGroup ();
		
	}
		
	}
