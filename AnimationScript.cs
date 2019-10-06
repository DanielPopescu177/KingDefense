using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class AnimationScript : MonoBehaviour
{
	private Animator animator;
	void Awake()
	{
		// Get the animator
		animator = GetComponent<Animator>();
		
		// Get the renderers in children
	}

	float ion=2;
	void Update()
	{
        if (ion > 0) {
						ion -= Time.deltaTime;
			animator.SetBool("Jump",false);
				}
				else {
						ion = 2;
						animator.SetBool ("Jump", true);
				}
		
	}
	
}