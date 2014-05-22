using UnityEngine;
using System.Collections;

public class Run : MonoBehaviour
{

		public string whichKey;
		
		Animator animator;
		GameObject ground;
	
		void Start ()
		{
	
				animator = GetComponent<Animator> ();
				ground = transform.FindChild ("Ground").gameObject;
	
		}
	
		void Update ()
		{
	
				float speed = animator.GetFloat ("speed");
		
				if (Input.GetKeyDown (whichKey)) {
						speed += 1.0f;
				}
		
				speed = speed * 0.975f;
		
				if (speed < 0.2f) {
						speed = 0.0f;
				}
		
				animator.SetFloat ("speed", speed);
				
				ground.transform.Translate (-speed * 0.05f, 0, 0);
	
		}

}
