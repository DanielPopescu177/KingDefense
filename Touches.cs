using System.Collections.Generic;
using UnityEngine;

public class Touches : MonoBehaviour
{
	
	RaycastHit hit;
	GameObject fadeit;
	GameObject selectedwall;
	int selected=0;
	int m1, m2;
	//public GUIText showtxt;
	//public GUIText showtx;
	//public GUITexture guitxt;
	void Start()
	{
		//showtxt.text = "Showtxt";
		//showtx.text = "PLM";
	}
	public Transform playerref;
	void Update ()
	{	//int x = 1;
		for (int i = 0; i < Input.touchCount; i++) {
			Touch touch = Input.GetTouch (i);
			if (touch.phase == TouchPhase.Ended) {
				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
				if (hit.collider != null) {
					//	D		
					if (hit.collider.tag == "Player") {   
						#region Hit Player
						
						//	Destroy (GameObject.Find ("FadePlayer" + x.ToString ()));
						WallScript wallsc = hit.transform.GetComponent<WallScript> ();
						if (wallsc) { 
							selectedwall = hit.transform.gameObject;
							selected=wallsc.id;
							fadeeverything ();
							m1 = wallsc.PossibleLeftMove ();
							m2 = wallsc.PossibleRightMove ();
							
							fadeit = GameObject.Find ("FadePlayer" + m1.ToString ());
							FaderScript fadescript = fadeit.GetComponent<FaderScript> ();
							WallScript tofade = fadeit.GetComponent<WallScript> ();
							if(wallsc.owner==0)
							{
								if (tofade.owner == wallsc.id || tofade.owner == 0)
									fadescript.fading = true;
								fadeit = GameObject.Find ("FadePlayer" + m2.ToString ());
								tofade = fadeit.GetComponent<WallScript> ();
								fadescript = fadeit.GetComponent<FaderScript> ();
								if (tofade.owner == wallsc.id || tofade.owner == 0)
									fadescript.fading = true;
							}
							else
							{
								if (tofade.owner == wallsc.id)
									fadescript.fading = true;
								fadeit = GameObject.Find ("FadePlayer" + m2.ToString ());
								tofade = fadeit.GetComponent<WallScript> ();
								fadescript = fadeit.GetComponent<FaderScript> ();
								if (tofade.owner == wallsc.id)
									fadescript.fading = true;
								
							}
							
						}
					}
					#endregion
					#region Hit RedWall
					else if (hit.collider.tag == "Redwall"&&selectedwall!=null) {
						WallScript ownerid = selectedwall.GetComponent<WallScript> ();
						WallScript getid = hit.collider.gameObject.GetComponent<WallScript> ();
						if (ownerid.owner == 0) {
							
							if (getid.owner == 0) {
								

								if (getid.id == m1 || getid.id == m2) {
									getid.owner = selected;
									ownerid.owner = 1;
									Vector3 savepos = selectedwall.transform.position;
									selectedwall.transform.position = hit.collider.transform.position;
									hit.collider.transform.position = savepos;
								} else {
									selected = 0;
									//		m1 = 0;
									//		m2 = 0;
									fadeeverything ();
								}
							} else if (getid.owner == selected) {   
								
								getid.owner = 0;
								if (getid.id == m1 || getid.id == m2) {
									ownerid.owner = 1;
									Vector3 savepos = selectedwall.transform.position;
									selectedwall.transform.position = hit.collider.transform.position;
									hit.collider.transform.position = savepos;
								} else {
									//selected = 0;
									//	m1 = 0;
									//	m2 = 0;
									fadeeverything ();
								}
								
							}
						} else {
							if (getid.owner == selected) {   
								
								getid.owner = 0;
								if (getid.id == m1 || getid.id == m2) {
									ownerid.owner = 0;
									Vector3 savepos = selectedwall.transform.position;
									selectedwall.transform.position = hit.collider.transform.position;
									hit.collider.transform.position = savepos;
									
								}	
							}
							
						}
						
					}
					#endregion
				}
				else  {
					//	selectedwall=null;
					fadeeverything();
				}
			}
			else { 
				if (touch.phase == TouchPhase.Began)
				{
					Debug.Log("I'm Here");
					Ray ray = Camera.main.ScreenPointToRay (touch.position);
					RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
					if (hit.collider != null) {
						//	D		
						if (hit.collider.tag == "Player") {   						
							//	Destroy (GameObject.Find ("FadePlayer" + x.ToString ()));
							WallScript wallsc = hit.transform.GetComponent<WallScript> ();
							if (wallsc) { 
								selectedwall = hit.transform.gameObject;
								selected=wallsc.id;
								fadeeverything ();
								m1 = wallsc.PossibleLeftMove ();
								m2 = wallsc.PossibleRightMove ();
								
								fadeit = GameObject.Find ("FadePlayer" + m1.ToString ());
								FaderScript fadescript = fadeit.GetComponent<FaderScript> ();
								WallScript tofade = fadeit.GetComponent<WallScript> ();
								if(wallsc.owner==0)
								{
									if (tofade.owner == wallsc.id || tofade.owner == 0)
										fadescript.fading = true;
									fadeit = GameObject.Find ("FadePlayer" + m2.ToString ());
									tofade = fadeit.GetComponent<WallScript> ();
									fadescript = fadeit.GetComponent<FaderScript> ();
									if (tofade.owner == wallsc.id || tofade.owner == 0)
										fadescript.fading = true;
								}
								else
								{
									if (tofade.owner == wallsc.id)
										fadescript.fading = true;
									fadeit = GameObject.Find ("FadePlayer" + m2.ToString ());
									tofade = fadeit.GetComponent<WallScript> ();
									fadescript = fadeit.GetComponent<FaderScript> ();
									if (tofade.owner == wallsc.id)
										fadescript.fading = true;
									
								}
								
							}
						}	
					}
				}
				else if (touch.phase == TouchPhase.Moved)
				{
					// Move the trail
					Ray ray = Camera.main.ScreenPointToRay (touch.position);
					RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
					if (hit.collider != null) {
						//	D		
						if (hit.collider.tag == "Redwall"&&selectedwall!=null) {
							WallScript ownerid = selectedwall.GetComponent<WallScript> ();
							WallScript getid = hit.collider.gameObject.GetComponent<WallScript> ();
							if (ownerid.owner == 0) {
								
								if (getid.owner == 0) {
									

									if (getid.id == m1 || getid.id == m2) {
										getid.owner = selected;
										ownerid.owner = 1;
										Vector3 savepos = selectedwall.transform.position;
										selectedwall.transform.position = hit.collider.transform.position;
										hit.collider.transform.position = savepos;
									} else {
										selected = 0;
										//m1 = 0;
										//m2 = 0;
										fadeeverything ();
									}
								} else if (getid.owner == selected) {   
									
									getid.owner = 0;
									if (getid.id == m1 || getid.id == m2) {
										ownerid.owner = 1;
										Vector3 savepos = selectedwall.transform.position;
										selectedwall.transform.position = hit.collider.transform.position;
										hit.collider.transform.position = savepos;
									} else {
										//selected = 0;
										//	m1 = 0;
										//	m2 = 0;
										fadeeverything ();
									}
									
								}
							} else {
								if (getid.owner == selected) {   
									
									getid.owner = 0;
									if (getid.id == m1 || getid.id == m2) {
										ownerid.owner = 0;
										Vector3 savepos = selectedwall.transform.position;
										selectedwall.transform.position = hit.collider.transform.position;
										hit.collider.transform.position = savepos;
										
									}
									
									
									
								}
								
							}
							
						}
						
					}
				}
				else if (touch.phase == TouchPhase.Ended)
				{
					// Clear known trails
					
					
				}
				
				
				
			}	
		}
		
	}
void fadeeverything()
{
	for(int j=1;j<=7;j+=2)
	{
		fadeit=GameObject.Find("FadePlayer"+j.ToString());
			WallScript wallsc2 = fadeit.GetComponent<WallScript>();
		FaderScript fadescript = fadeit.GetComponent<FaderScript>();
			Debug.Log ("ID: "+wallsc2.id.ToString()+" owner: "+wallsc2.owner.ToString());
		fadescript.TotalFade();
	}
}

}