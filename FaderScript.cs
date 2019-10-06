using UnityEngine;
using System.Collections;

public class FaderScript : MonoBehaviour {
	public bool fading=false;
	private bool ion=true;
		public float fadespeed = 2;
	void Start()
	{
		Color color = this.GetComponent<Renderer>().material.color;
		color.a = 0.0f;
		this.GetComponent<Renderer>().material.color = color;
	}
	void Update()
	{
				if (fading) {
						Color color = this.GetComponent<Renderer>().material.color;
						//Renderer tempRenderer;
						//tempRenderer = this.renderer;
						if (color.a > 0.1 && !ion) {
								
								color.a = Mathf.Lerp (color.a, 0, Time.deltaTime * fadespeed);
						} else if (color.a < 0.1)
								ion = true;
			        
						if (color.a < 0.6 && ion) {
								color.a = Mathf.Lerp (color.a, 10, Time.deltaTime * fadespeed);
						} else if (color.a > 0.5)
								ion = false;
						this.GetComponent<Renderer>().material.color = color;
				}
		}
	public void TotalFade()
	{
		fading = false;
		ion=false;
		Color color = this.GetComponent<Renderer>().material.color;
		color.a = 0.0f;
		this.GetComponent<Renderer>().material.color = color;
	}
			             
	
	/*void Start()
	{
		Sprite = this.gameObject;
	}

		void Update(){
		if(fading)
		{
			//if hit with particles
			if(Sprite){
				Sprite.renderer.material.color.a = Mathf.Lerp(Sprite.renderer.material.color.a,0,Time.deltaTime * fadespeed);
				if(Sprite.renderer.material.color.a==0){
					FadeIn();
				}
			}
			if(Spriteb){
				Spriteb.color.a = Mathf.Lerp(Spriteb.color.a,0,Time.deltaTime * fadespeed);
				
				if(Spriteb.color.a ==0){
					FadeIn();
				}
			}
		}
		IEnumerator FadeIn(){
			yield WaitForSeconds(2);
			if(Spriteb){
				Spriteb.color.a = Mathf.Lerp(Spriteb.color.a,1,Time.deltaTime * fadespeed);
			}
			//if hit with particles
			if(Sprite){
				Sprite.renderer.material.color.a = Mathf.Lerp(Sprite.renderer.material.color.a,1,Time.deltaTime * fadespeed);
			}
		}
	}
	}
*/

}