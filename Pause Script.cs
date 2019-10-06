using UnityEngine;

/// <summary>
/// Start or quit the game
/// </summary>
public class PauseScript : MonoBehaviour
{
	private GUISkin skin;

	void Start()
	{
		Time.timeScale = 0.0f;
		skin=Resources.Load("CircleButton") as GUISkin;
		//PlayerPrefs.SetInt("Highscore", ScoreScript.Instance.score);
	}
	void OnGUI()
	{
		const int buttonWidth = 350;
		const int buttonHeight = 150;
		GUI.skin = skin;
		if (
			GUI.Button(
			// Center in X, 1/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(1 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Resume"
			)
			)
		{
			// Reload the level
			Time.timeScale = 1.0f;
			Destroy(transform.gameObject.GetComponent<PauseScript>());
		}
		
		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Menu"
			)
			)
		{
			Time.timeScale = 1.0f;
			// Reload the level
			Application.LoadLevel("menuscene");
		}
	}
}