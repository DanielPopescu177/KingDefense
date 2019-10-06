using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
	public int id;
	public bool red=false;
	public int owner=0;
	bool selected;
	Vector2 movement=new Vector2(0,0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public int PossibleLeftMove()
	{
		if (id < 8)
						return id + 1;
				else
						return 1;
	}
	public int PossibleRightMove()
	{
						return id - 1;
				
	}
	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = movement;
	}

}
