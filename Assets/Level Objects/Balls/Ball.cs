using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	#region Static
	
	private static int ballAmount = 0;
	public static bool ballExists { get { return ballAmount > 0; } }
	
	#endregion
	
	public TrailRenderer trail;
	private float trailTime;
	
	void Awake() {
		
		trailTime = trail.time;
		trail.time = 0;
		
	}
	
	void OnEnable() {
		
		ballAmount++;
		trail.time = trailTime;
		
	}
	
	void OnDisable() { // detach the trail
		
		ballAmount--;
		trail.transform.parent = null;
		trail.autodestruct = true;
		
	}
	
	public float selfDestructVelocity = 1f;
	public float selfDestructTime = 1f;
	bool selfDestructCountdown = false;
	float selfDestructStart = 0f;
	public float velocity;
	
	void Update() {
		
		velocity = rigidbody.velocity.magnitude;
		
		if (selfDestructCountdown) {
			
			if (velocity >= selfDestructVelocity)
				selfDestructCountdown = false;
			else if (Time.time - selfDestructStart > selfDestructTime)
				Destroy (gameObject);
			
		} else if (velocity < selfDestructVelocity) {
			
			selfDestructCountdown = true;
			selfDestructStart = Time.time;
			
		}	
		
	}
	
}
