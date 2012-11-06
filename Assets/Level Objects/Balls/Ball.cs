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
	
}
