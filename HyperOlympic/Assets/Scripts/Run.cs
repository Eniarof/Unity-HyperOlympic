using UnityEngine;
using System.Collections;

public class Run : MonoBehaviour
{
		Animator animator;
		GameObject ground;
		TextMesh timer;
	
		float time = 0.0f;
		bool isRunning = true;
		public string whichKey = "space";
	
		void Start ()
		{
				animator = GetComponent<Animator> ();
				timer = transform.FindChild ("Timer").GetComponent<TextMesh> ();
				ground = transform.parent.FindChild ("Ground").gameObject;
				
				Screen.showCursor = false;
		}
	
		void Update ()
		{
				if (isRunning) {
						time += Time.deltaTime;
				}
				timer.text = time.ToString ("0.00");
	
				float speed = animator.GetFloat ("speed");
				if (isRunning && Input.GetKeyDown (whichKey)) {
						speed += 1.0f;
				}
				speed = speed * 0.975f;
				if (speed < 0.2f) {
						speed = 0.0f;
				}
				animator.SetFloat ("speed", speed);
				
				ground.transform.Translate (-speed * 0.05f, 0, 0);
		}
	
	
		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.name == "EndZone") {
						isRunning = false;
				}
		}

}
